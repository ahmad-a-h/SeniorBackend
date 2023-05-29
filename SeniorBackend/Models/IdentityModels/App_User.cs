using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SeniorBackend.Models.IdentityModels
{
    public class App_User : IdentityUser
    {
        public App_User()
        {
        }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public bool? RequireUniqueEmail { get; set; } = true;
    }
}
