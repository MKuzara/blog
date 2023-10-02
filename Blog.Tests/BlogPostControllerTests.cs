using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoFixture;
using Blog.API.Controllers;
using Blog.API.Models.Domain;
using Blog.API.Repositiories;
using Moq;
using Blog.API.Mappings;
using AutoMapper;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Identity;

namespace Blog.Tests
{
    public class BlogPostControllerTests
    {
        private Mock<IBlogPostRepository> blogPostRepositoryMock;
        private Fixture fixture;
        private static IMapper mapper;

        public BlogPostControllerTests()
        {
            fixture = new Fixture();
            blogPostRepositoryMock = new Mock<IBlogPostRepository>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfiles());
            });
            mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async void TestGetBlogPostList()
        {
            // var blogPostList = fixture.CreateMany<BlogPost>(3)..;

            blogPostRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(GetTestBlogPosts());

            BlogPostsController controller = new BlogPostsController(mapper, blogPostRepositoryMock.Object);

            var result = await controller.GetList();

            result.Should().NotBeNull();

        }
        
        private List<BlogPost> GetTestUsers()
        {
            
        }

        private List<BlogPost> GetTestBlogPosts()
        {
            var hasher = new PasswordHasher<User>();
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

            return blogPosts;
        }

        // [Fact]
        // public async void TestGetBlogPostById()
        // {
        //     blogPostRepositoryMock.Setup(repo => repo.GetListAsync()).ReturnsAsync(GetTestBlogPosts());
        //     BlogPostsController controller = new BlogPostsController(mapper, blogPostRepositoryMock.Object);

        //     var result = await controller.GetById(id: Guid.Parse("2a9247f1-6aee-4c2f-9795-a1d98d8d3937"));

        //     Assert.IsTrue(result.TryGetContentValue<Product>(out product));
        //     Assert.AreEqual(10, product.Id);
        // }
    }
}
