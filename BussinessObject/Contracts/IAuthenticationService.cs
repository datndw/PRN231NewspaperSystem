using System;
using BussinessObject.Models;

namespace BussinessObject.Contracts
{
	public interface IAuthenticationService
	{
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}

