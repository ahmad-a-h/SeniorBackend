using Microsoft.AspNetCore.Identity;

namespace SeniorBackend.Models.IdentityModels
{
    public class App_Role : IdentityRole
    {
        public string RoleTitle { get; set; }
    }
}
