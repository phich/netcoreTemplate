using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using CreateTemplate.Data.Contexts;
using Microsoft.AspNetCore.Http;

namespace CreateTemplate.Data.UnitOfWork
{
   public  class HttpUnitOfWork:UnitOfWork
    {
      public HttpUnitOfWork(ApplicationDbContext context, IHttpContextAccessor httpAccessor) : base(context)
      {
        
        context.CurrentUserId = Guid.Parse(httpAccessor.HttpContext.User.Claims.First().Value);
      }
    }
}
