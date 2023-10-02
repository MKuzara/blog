using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blog.API.Models.Domain
{
    public class User : IdentityUser
    {
        // [Key]
        // public Guid Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // navigation property
        public List<BlogPost> BlogPosts { get; set; }
    }
}