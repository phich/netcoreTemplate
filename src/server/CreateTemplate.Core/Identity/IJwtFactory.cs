using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace CreateTemplate.Core.Identity
{
    public interface IJwtFactory
    {
        string GenerateEncodedToken(Guid userId, string email, IEnumerable<Claim> additionalClaims);
    }
}
