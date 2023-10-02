using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.API.Models.DTO;
using Blog.API.Repositiories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> GetUserProfle()
        {
            if (this.User.Identity?.Name == null) {
                return BadRequest("Could not find the authenticated user.");
            }
            var username = this.User.Identity.Name;
            var userProfile = await userRepository.GetUserProfileAsync(username);

            if(userProfile == null) {
                return NotFound();
            }

            var userProfileDTO = mapper.Map<UserProfileDTO>(userProfile);
            return Ok(userProfileDTO);
        }

    }
}