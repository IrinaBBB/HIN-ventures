using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures.Client.Service.IService
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserRequestDto userForRegisteration);

        Task<AuthenticationResponseDto> Login(AuthenticationDto userFromAuthentication);

        Task Logout();
    }
}
