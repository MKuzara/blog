using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Models.Domain;

namespace Blog.API.Repositiories
{
    public interface IBlogPostRepository
    {
        Task<List<BlogPost>> GetListAsync(string? filter, int pageNumber = 1, int pageSize = 10);

        Task<BlogPost?> GetByIdAsync(Guid id);

        Task<BlogPost> CreateAsync(BlogPost blogPost);

        Task<BlogPost?> UpdatedAsync(BlogPost exisingBlogPost, BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);
    }
}