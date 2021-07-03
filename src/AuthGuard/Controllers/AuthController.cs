using AuthGuard.Models;
using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuthGuard.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("login")]
        public async Task<TokenResponseDTO> Login(LoginRequestDTO loginRequest)
        {
            HttpClient client = new HttpClient();
            DiscoveryDocumentResponse disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

            if (disco.IsError)
                throw new HttpRequestException("Connection Error");

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = loginRequest.ClientId,
                ClientSecret = loginRequest.ClientSecret,
                Scope = loginRequest.Scope,
                UserName = loginRequest.UserName,
                Password = loginRequest.Password.Sha256()
            });

            if (tokenResponse.HttpStatusCode != HttpStatusCode.OK)
                throw new UnauthorizedAccessException(tokenResponse.HttpErrorReason);

            return tokenResponse.Json.ToObject<TokenResponseDTO>();
        }
    }
}
