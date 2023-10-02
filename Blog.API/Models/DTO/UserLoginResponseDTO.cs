using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.DTO
{
    public class UserLoginResponseDTO
    {
        public string JwtToken { get; set; }
    }
}