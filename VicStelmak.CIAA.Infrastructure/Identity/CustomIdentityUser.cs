using Microsoft.AspNetCore.Identity;

namespace VicStelmak.CIAA.Infrastructure.Identity
{
    // Add profile data for application users by adding properties to the CustomIdentityUser class
    public class CustomIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}