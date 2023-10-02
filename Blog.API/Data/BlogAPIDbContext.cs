using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.API.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Blog.API.Data
{
    public class BlogAPIDbContext : IdentityDbContext<User>
    {
        public BlogAPIDbContext(DbContextOptions<BlogAPIDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var hasher = new PasswordHasher<User>();
            // Create sample users
            List<User> users = new List<User>() {
                new User() {
                    Id = Guid.Parse("b73ee27e-4084-45ff-b7dd-5a821adef831").ToString(),
                    UserName = "example_user_1",
                    NormalizedUserName = "EXAMPLE_USER_1",
                    Email = "user1@example.com",
                    PasswordHash = hasher.HashPassword(null, "!QAZxsw2")
                },
                new User() {
                    Id = Guid.Parse("6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4").ToString(),
                    UserName = "example_user_2",
                    Email = "user2@example.com",
                    NormalizedUserName = "EXAMPLE_USER_2",
                    PasswordHash = hasher.HashPassword(null, "!QAZxsw2")
                }
            };
            modelBuilder.Entity<User>().HasData(users);

            // Create sample blog posts and assign then to the users
            List<BlogPost> blogPosts = new List<BlogPost>() {
                new BlogPost() {
                    Id = Guid.Parse("2a9247f1-6aee-4c2f-9795-a1d98d8d3937"),
                    Title = "Blog Post #1",
                    Content = @"
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                        Fusce iaculis vehicula neque ut fermentum. Ut urna justo, 
                        porttitor sit amet diam at, dictum vulputate elit.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = Guid.Parse("b73ee27e-4084-45ff-b7dd-5a821adef831").ToString()
                },
                new BlogPost() {
                    Id = Guid.Parse("453fae99-af87-40e5-a005-eace9e3862c1"),
                    Title = "Blog Post #2",
                    Content = @"
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                        Nunc sed nisl diam. Pellentesque habitant morbi tristique 
                        senectus et netus et.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = Guid.Parse("6682b6cc-9ea9-4ff3-92dc-cbd306a31cd4").ToString()
                },
                new BlogPost() {
                    Id = Guid.Parse("ad417376-e1e8-4b18-bfb5-c00e155e9926"),
                    Title = "Blog Post #1",
                    Content = @"
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                        Cras eget finibus nibh. Suspendisse sem ante, ultrices eu 
                        ultricies non, facilisis.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = Guid.Parse("b73ee27e-4084-45ff-b7dd-5a821adef831").ToString()
                },
                new BlogPost() {
                    Id = Guid.Parse("4afaa9a9-7488-4168-9be2-56138e6a2882"),
                    Title = "Blog Post #1",
                    Content = @"
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
                        Duis cursus tincidunt feugiat. Nullam molestie dui id velit 
                        vehicula porttitor. Vestibulum.",
                    CreatedDate = DateTime.UtcNow,
                    UserId = Guid.Parse("b73ee27e-4084-45ff-b7dd-5a821adef831").ToString()
                },
            };
            modelBuilder.Entity<BlogPost>().HasData(blogPosts);
        }
    }
}