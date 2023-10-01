using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.API.Models.DTO;
using Blog.API.Repositiories;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public UserProfileController(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfle(string username)
        {
            var userProfile = await userRepository.GetUserProfileAsync(username);

            if(userProfile == null) {
                return NotFound();
            }

            var userProfileDTO = mapper.Map<UserProfileDTO>(userProfile);
            return Ok(userProfileDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfileInformation([FromBody] string email)
        {
            return Ok();
        }

    }
}