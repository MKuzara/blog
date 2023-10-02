using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.DTO
{
    public class UserLoginDTO
    {
        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}