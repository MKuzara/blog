using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Blog.API.Models.Domain;
using Blog.API.Models.DTO;

namespace Blog.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BlogPost, BlogPostDTO>().ReverseMap();
            CreateMap<BlogPost, BlogPostDetailsDTO>().ReverseMap();
            CreateMap<BlogPost, AddBlogPostDTO>().ReverseMap();
            CreateMap<BlogPost, UpdateBlogPostDTO>().ReverseMap();

            CreateMap<User, UserProfileDTO>().ReverseMap();
            CreateMap<User, UserInfoDto>().ReverseMap();
        }
    }
}