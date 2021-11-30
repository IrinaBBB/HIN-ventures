using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using HIN_ventures.Client.Helper;
using HIN_ventures.Client.Service.IService;
using HIN_ventures.Common;
using HIN_ventures.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

namespace HIN_ventures.Client.Service
{
     public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient client, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
        {
            _client = client;
            _authStateProvider = authStateProvider;
            ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
            _localStorage = localStorage;
        }

        public async Task<AuthenticationResponseDto> Login(AuthenticationDto userFromAuthentication)
        {
            var content = JsonConvert.SerializeObject(userFromAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signin", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AuthenticationResponseDto>(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                await _localStorage.SetItemAsync(SD.Local_Token, result.Token);
                await _localStorage.SetItemAsync(SD.LocalUserDetails, result.userDto);
                ((AuthStateProvider)_authStateProvider).NotifyUserLoggedIn(result.Token);
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
                return new AuthenticationResponseDto { IsAuthSuccessful = true };
            }
            else
            {
                return result;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync(SD.Local_Token);
            await _localStorage.RemoveItemAsync(SD.LocalUserDetails);
            _client.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<RegistrationResponseDto> RegisterUser(UserRequestDto userForRegisteration)
        {
            var content = JsonConvert.SerializeObject(userForRegisteration);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("api/account/signup", bodyContent);
            var contentTemp = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RegistrationResponseDto>(contentTemp);

            if (response.IsSuccessStatusCode)
            {

                return new RegistrationResponseDto { IsRegisterationSuccessful = true };
            }
            else
            {
                return result;
            }
        }

    //    public void NotifyUserLoggedIn(string token)
    //    {
    //        var authenticatedUser =
    //            new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "JwtAuthType"));
    //        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
    //    }

    //    public void NotifyUserLoggedOut()
    //    {
    //        var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
    //        NotifyA(authState);
    //    }
    }
}
