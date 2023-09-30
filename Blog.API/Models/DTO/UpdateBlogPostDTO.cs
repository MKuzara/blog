using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.DTO
{
    public class UpdateBlogPostDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}