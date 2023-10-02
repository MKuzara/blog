using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Models.Domain;

namespace Blog.API.Repositiories
{
    public interface ITokenRespository
    {
        string CreateJWTToken(User user);
    }
}