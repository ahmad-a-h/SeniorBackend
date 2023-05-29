namespace SeniorBackend.Models.DTOs
{
    public class UserLoginRequest
    {
        /// <summary>
        /// Username can be both username/email
        /// </summary>
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
