using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Data;
using Blog.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Repositiories
{
    public class UserRespository : IUserRepository
    {
        private readonly BlogAPIDbContext dbContext;

        public UserRespository(BlogAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User?> GetUserProfileAsync(string username)
        {
            var user = await dbContext.Users
                .Include(x => x.BlogPosts)
                .FirstOrDefaultAsync(x => x.UserName == username);
            
            if (user == null) {
                return null;
            }

            return user;
        }

        public async Task<User?> GetUserByUserName(string username)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        }
    }
}