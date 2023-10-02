using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
using Blog.API.ActionFilter;
using Blog.API.Models.Domain;
using Blog.API.Models.DTO;
using Blog.API.Repositiories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IUserRepository userRepository;
        private readonly IAuthorizationService authorizationService;

        public BlogPostsController(
            IMapper mapper, IBlogPostRepository blogPostRepository, 
            IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            this.mapper = mapper;
            this.blogPostRepository = blogPostRepository;
            this.userRepository = userRepository;
            this.authorizationService = authorizationService;
        }

        // GET Blog Posts
        // GET: /api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] string? filter, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // Get list of the blog posts from the DB
            var blogPostList = await blogPostRepository.GetListAsync(filter, pageNumber, pageSize);

            // Map the blogpost model to a DTO
            var blogPostsDto = mapper.Map<List<BlogPostDTO>>(blogPostList);

            return Ok(blogPostsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get blog post from the DB
            var blogPost = await blogPostRepository.GetByIdAsync(id);

            // Gandle 404 - Not Found
            if (blogPost == null)
            {
                return NotFound();
            }
            var blogPostDto = mapper.Map<BlogPostDetailsDTO>(blogPost);

            return Ok(blogPostDto);
        }

        [HttpPost]
        [Authorize]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddBlogPostDTO addBlogPostDTO)
        {
            // Map the DTO to a blogpost model
            var blogPost = mapper.Map<BlogPost>(addBlogPostDTO);

            // check if user the authenticated user has correct informaiton
            if (this.User.Identity?.Name == null) {
                return BadRequest("Something went wrong.");
            }
            // Get user by ID
            var user = await userRepository.GetUserByUserName(this.User.Identity.Name);

            if (user == null)
            {
                return BadRequest();
            }
            blogPost.UserId = user.Id;
            // Create a blog post
            blogPost = await blogPostRepository.CreateAsync(blogPost);

            // Map the blogpost model to a DTO
            var blogPostDTO = mapper.Map<BlogPostDetailsDTO>(blogPost);

            return CreatedAtAction(nameof(GetById), new { id = blogPost.Id }, blogPostDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBlogPostDTO updateBlogPostDTO)
        {
            var existingBlogPost = await blogPostRepository.GetByIdAsync(id);

            var authorizationResult = await authorizationService.AuthorizeAsync(this.User, existingBlogPost, "ObjectOwner");

            if (authorizationResult.Succeeded)
            {
                // Map the DTO to a blogpost model
                var blogPost = mapper.Map<BlogPost>(updateBlogPostDTO);
                // update the blogpost object
                blogPost = await blogPostRepository.UpdatedAsync(existingBlogPost, blogPost);

                // Handle 404 - Not Found
                if (blogPost == null)
                {
                    return NotFound();
                }

                // Map the blogpost model to a DTO
                var blogPostDTO = mapper.Map<BlogPostDetailsDTO>(blogPost);

                return Ok(blogPostDTO);

            }
            else if (this.User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var blogPost = await blogPostRepository.GetByIdAsync(id);

            // Handle 404 - Not Found
            if (blogPost == null){
                return NotFound();
            }

            var authorizationResult = await authorizationService.AuthorizeAsync(this.User, blogPost, "ObjectOwner");

            if (authorizationResult.Succeeded)
            {
                // Delete the blogpost object
                var deletedBlogPost = await blogPostRepository.DeleteAsync(id);

                // Return 204 - No Content
                return NoContent();

            } else if (this.User.Identity.IsAuthenticated) {
                return new ForbidResult();
            } else {
                return new ChallengeResult();
            }
        }
    }
}