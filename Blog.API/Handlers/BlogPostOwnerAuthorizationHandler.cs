using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.API.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Blog.API.Handlers
{
    public class BlogPostOwnerAuthorizationHandler :
        AuthorizationHandler<ObjectOwnerRequirement, BlogPost>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       ObjectOwnerRequirement requirement,
                                                       BlogPost resource)
        {
            if (context.User.Identity?.Name == resource.User.UserName)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }

    public class ObjectOwnerRequirement : IAuthorizationRequirement { }
}
