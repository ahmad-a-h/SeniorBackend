

using SeniorBackend.Models.IdentityModels;

namespace SeniorBackend
{
    public interface IUserServices
    {
        public string GenerateJwt(App_User user, IList<string> roles);
    }
}
