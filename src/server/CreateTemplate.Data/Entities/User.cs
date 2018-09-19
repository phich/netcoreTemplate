using System;
using Microsoft.AspNetCore.Identity;

namespace CreateTemplate.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
