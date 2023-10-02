using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog.API.Models.Domain;
using Blog.API.Models.DTO;
using Blog.API.Repositiories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Blog.API.ActionFilter;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly ITokenRespository tokenRepository;
        public AuthController(UserManager<User> userManager, ITokenRespository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        [ValidateModel]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            var user = new User
            {
                UserName = userRegistrationDTO.Username,
                Email = userRegistrationDTO.Email,
            };

            var identityResult = await userManager.CreateAsync(user, userRegistrationDTO.Password);

            if(identityResult.Succeeded) {
                return Ok("User was registered! Please login.");
            }
            return BadRequest(identityResult.Errors);
        }

        [HttpPost]
        [Route("Login")]
        [ValidateModel]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await userManager.FindByNameAsync(userLoginDTO.Username);

            if(user == null)
            {
                return BadRequest("Username or Password was incorrect.");
            }

            var checkPasswordResult = await userManager.CheckPasswordAsync(user, userLoginDTO.Password);
            if(checkPasswordResult) {

                // Create username claim so that it can be accessed in the controllers when authenticated
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, user.UserName)
                };
                
                var jwtToken = tokenRepository.CreateJWTToken(user, claims);

                var response = new UserLoginResponseDTO{
                    JwtToken = jwtToken
                };
                return Ok(response);
                
            }

            return BadRequest("Username or Password was incorrect.");
        }
    }
}