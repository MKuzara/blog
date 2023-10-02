using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IAuthorizationService authorizationService;

        public BlogPostsController(IMapper mapper, IBlogPostRepository blogPostRepository, IAuthorizationService authorizationService)
        {
            this.mapper = mapper;
            this.blogPostRepository = blogPostRepository;
            this.authorizationService = authorizationService;
        }

        // GET Blog Posts
        // GET: /api/blogposts
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            // Get list of the blog posts from the DB
            var blogPostList = await blogPostRepository.GetListAsync();

            // Map the blogpost model to a DTO
            var blogPostsDto = mapper.Map<List<BlogPostDTO>>(blogPostList);

            return Ok(blogPostsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get blog post from the DB
            var blogPost = await blogPostRepository.GetByIdAsync(id);

            // Gandle 404 - Not Found
            if (blogPost == null)
            {
                return NotFound();
            }

            var authorizationResult = await authorizationService.AuthorizeAsync(User, blogPost, "ObjectOwner");

            if (authorizationResult.Succeeded)
            {
                // Map the blogpost model to a DTO
                var blogPostDto = mapper.Map<BlogPostDetailsDTO>(blogPost);

                return Ok(blogPostDto);
            }
            else if (User.Identity.IsAuthenticated)
            {
                return new ForbidResult();
            }
            else
            {
                return new ChallengeResult();
            }
            
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] AddBlogPostDTO addBlogPostDTO)
        {
            // Map the DTO to a blogpost model
            var blogPost = mapper.Map<BlogPost>(addBlogPostDTO);

            // Create a blog post
            blogPost = await blogPostRepository.CreateAsync(blogPost);

            // Map the blogpost model to a DTO
            var blogPostDTO = mapper.Map<BlogPostDetailsDTO>(blogPost);

            return CreatedAtAction(nameof(GetById), new { id = blogPost.Id }, blogPostDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBlogPostDTO updateBlogPostDTO)
        {
            // Map the DTO to a blogpost model
            var blogPost = mapper.Map<BlogPost>(updateBlogPostDTO);

            // update the blogpost object
            blogPost = await blogPostRepository.UpdatedAsync(id, blogPost);

            // Handle 404 - Not Found
            if (blogPost == null)
            {
                return NotFound();
            }

            // Map the blogpost model to a DTO
            var blogPostDTO = mapper.Map<BlogPostDetailsDTO>(blogPost);

            return Ok(blogPostDTO);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Delete the blogpost object
            var blogPost = await blogPostRepository.DeleteAsync(id);

            // Handle 404 - Not Found
            if (blogPost == null)
            {
                return NotFound();
            }
            // Return 204 - No Content
            return NoContent();
        }
    }
}