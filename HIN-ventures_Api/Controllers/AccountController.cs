using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using HIN_ventures.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using HIN_ventures.Models;
using HIN_ventures.Common;
using HIN_ventures.DataAccess.Entities;
using HIN_ventures_Api.Helper;
using Microsoft.IdentityModel.Tokens;

namespace HIN_ventures_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly APISettings _aPISettings;

        public AccountController(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, 
            IOptions<APISettings> options)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _aPISettings = options.Value;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserRequestDto userRequestDTO)
        {
            if (userRequestDTO == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = new ApplicationUser
            {
                UserName = userRequestDTO.Email,
                Email = userRequestDTO.Email,
                LastName = userRequestDTO.Name,
                PhoneNumber = userRequestDTO.PhoneNo,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, userRequestDTO.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new RegistrationResponseDto
                    { Errors = errors, IsRegisterationSuccessful = false });
            }

            if (userRequestDTO.IsFreelanser)
            {
                var freelancerRoleResult = await _userManager.AddToRoleAsync(user, SD.Role_Freelancer);
                if (!freelancerRoleResult.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDto
                        { Errors = errors, IsRegisterationSuccessful = false });
                }
            }

            if (userRequestDTO.IsCustomer)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, SD.Role_Customer);
                if (!roleResult.Succeeded)
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new RegistrationResponseDto
                        { Errors = errors, IsRegisterationSuccessful = false });
                }
            }
            //muligens her vi må inn med egen logikk knyttet til prosjektoppgave 2. Skal velge Customer eller Freelancer rolle basert på valg i UI.
            // if customer valgt i UI på klienten, sett role.customer. 
            //else if freelancer valgt i klienten  
            
            return StatusCode(201);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthenticationDto authenticationDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(authenticationDTO.UserName,
                authenticationDTO.Password, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(authenticationDTO.UserName);
                if (user == null)
                {
                    return Unauthorized(new AuthenticationResponseDto()
                    {
                        IsAuthSuccessful = false,
                        ErrorMessage = "Invalid Authentication"
                    });
                }

                //everything is valid and we need to login the user

                var signinCredentials = GetSigningCredentials();
                var claims = await GetClaims(user);

                var tokenOptions = new JwtSecurityToken(
                    issuer: _aPISettings.ValidIssuer,
                    audience: _aPISettings.ValidAudience,
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                return Ok(new AuthenticationResponseDto
                {
                    IsAuthSuccessful = true,
                    Token = token,
                    userDto = new UserDto
                    {
                        Name = user.LastName,
                        Id = user.Id,
                        Email = user.Email,
                        PhoneNo = user.PhoneNumber
                    }
                });
            }
            else
            {
                return Unauthorized(new AuthenticationResponseDto
                {
                    IsAuthSuccessful = false,
                    ErrorMessage = "Invalid Authentication"
                });
            }
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_aPISettings.SecretKey));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("Id",user.Id),

            };
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByEmailAsync(user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

    }
}
