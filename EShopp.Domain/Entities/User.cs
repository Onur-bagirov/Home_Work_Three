using Microsoft.AspNetCore.Identity;
namespace EShopp.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsLoggedIn { get; set; } = false;
        public string UserPassword { get; set; }
    }
}