using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Data;
using Blog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositiories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogAPIDbContext dbContext;

        public BlogPostRepository(BlogAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<BlogPost> CreateAsync(BlogPost blogPost)
        {
            blogPost.CreatedDate = DateTime.UtcNow;
            await dbContext.BlogPosts.AddAsync(blogPost);
            await dbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var blogPost = await dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);

            if (blogPost == null) {
                return null;
            }

            dbContext.BlogPosts.Remove(blogPost);
            await dbContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPost?> GetByIdAsync(Guid id)
        {
            return await dbContext.BlogPosts
                .Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BlogPost>> GetListAsync(string? filter, int pageNumber = 1, int pageSize = 10)
        {
            var blogPostList = dbContext.BlogPosts
                .Include(x => x.User)
                .AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(filter)) {
                blogPostList = blogPostList.Where(x => x.Title.Contains(filter));
            }
            var skipResults = (pageNumber - 1) * pageSize;
            return await blogPostList.Skip(skipResults).Take(pageSize).ToListAsync();
        }
        
        public async Task<BlogPost?> UpdatedAsync(BlogPost existingBlogPost, BlogPost blogPost)
        {
            if(existingBlogPost == null) {
                return null;
            }

            existingBlogPost.Title = blogPost.Title;
            existingBlogPost.Content = blogPost.Content;
            existingBlogPost.UpdatedDate = DateTime.UtcNow;

            await dbContext.SaveChangesAsync();

            return existingBlogPost;
        }
    }
}