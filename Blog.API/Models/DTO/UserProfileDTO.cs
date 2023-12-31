using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.DTO
{
    public class UserProfileDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public List<BlogPostDTO> BlogPosts { get; set; }
    }
}