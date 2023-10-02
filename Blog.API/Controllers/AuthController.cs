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
        public async Task<IActionResult> Register([FromBody] UserRegistrationDTO userRegistrationDTO)
        {
            var user = new User
            {
                UserName = userRegistrationDTO.Username,
                Email = userRegistrationDTO.Email
            };
            if(userRegistrationDTO.Password != userRegistrationDTO.Password2) {
                return BadRequest("Provided passwords do not much.");
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var identityResult = await userManager.CreateAsync(user, userRegistrationDTO.Password);

            if(identityResult.Succeeded) {
                return Ok("User was registered! Please login.");
            }
            return BadRequest("Something went wrong.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var user = await userManager.FindByNameAsync(userLoginDTO.Username);

            if(user == null)
            {
                return BadRequest("Username or Password was incorrect.");
            }

            var checkPasswordResult = await userManager.CheckPasswordAsync(user, userLoginDTO.Password);
            if(checkPasswordResult) {

                var jwtToken = tokenRepository.CreateJWTToken(user);

                var response = new UserLoginResponseDTO{
                    JwtToken = jwtToken
                };
                return Ok(response);
                
            }

            return BadRequest("Username or Password was incorrect.");
        }
    }
}