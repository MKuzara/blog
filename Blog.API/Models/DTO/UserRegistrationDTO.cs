using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.DTO
{
    public class UserRegistrationDTO
    {
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}