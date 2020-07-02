using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using v1.Models;
using v1.Models.Contracts;
using IAuthorizationService = v1.Models.Contracts.IAuthorizationService;

namespace v1.Controllers
{
    [Route("api/login")]
    [ApiController]
    public sealed class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
    
        public LoginController(
            IAuthenticationService authenticationService,
            IAuthorizationService authorizationService)
        {
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
        }
    
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginUser loginUser)
        {
            var authorization = await _authorizationService.AuthorizeAsync(loginUser);
            if (!authorization.Success)
            {
                return Ok(authorization);
            }
    
            var authentication = await _authenticationService.AuthenticateAsync(authorization.Data);
            if (!authentication.Success)
            {
                return Ok(authentication);
            }
    
            return Ok(authentication);
        }
    }
}