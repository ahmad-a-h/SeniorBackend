using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SeniorBackend.Models.DTOs;
using SeniorBackend.Models.IdentityModels;

namespace SeniorBackend.Controllers;

public class AccountController : Controller
{

    private readonly UserManager<App_User> _userManager;
    private readonly RoleManager<App_Role> _roleManager;
    private readonly SignInManager<App_User> _signInManager;
    private readonly IUserServices _userServices;
    private readonly IMapper _mapper;

    public AccountController(UserManager<App_User> userManager, SignInManager<App_User> signInManager, RoleManager<App_Role> roleManager, IUserServices userServices, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _userServices = userServices;
        _mapper = mapper;
    }

        [HttpPost("new-login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            try
            {
                //Check if username is email
                var isEmail = IsValidEmail(model.Username);
                Microsoft.AspNetCore.Identity.SignInResult loginResult = default;
                App_User user;
                if (isEmail)
                {
                    user = await _userManager.FindByEmailAsync(model.Username);
                    if (user == null) return BadRequest("Invalid username/email or password");
                    loginResult = await _signInManager.PasswordSignInAsync(user?.UserName, model.Password, false, false);
                }
                else
                {
                    user = await _userManager.FindByNameAsync(model.Username);
                    loginResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
                }
                if (!loginResult.Succeeded)
                {
                    return BadRequest("Invalid username/email or password");
                }
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var jwt = _userServices.GenerateJwt(user, roles);
                    return Ok(new { jwt });
                }
                else return BadRequest("User "+model.Username+" Not found!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        /// <summary>
        /// API used to regisgter a specific user to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationRequest model)
        {
            try
            {
                if (model == null) { return BadRequest("User cannot be null!"); }
                if (!IsValidEmail(model.Email)) return BadRequest("Email is not valid!");
                var emailExists = await _userManager.FindByEmailAsync(model.Email);
                if (emailExists != null) { return BadRequest("Email " + emailExists.Email + " is already in use!"); }
                //Check if added role exist
                var roleExist = await _roleManager.RoleExistsAsync(model.Role);
                if (!roleExist)
                {
                    return BadRequest("Specified role does not exist.");
                }

                var registeredUser = _mapper.Map<App_User>(model);

                var registrationResult = await _userManager.CreateAsync(registeredUser, model.Password);
                if (registrationResult.Succeeded)
                {
                    //Add user to the specified role
                    var addUserToRoleResult = await _userManager.AddToRoleAsync(registeredUser, model.Role);
                    if (!addUserToRoleResult.Succeeded)
                    {
                        //Deleting user, since no role have been assigned to this user
                        await _userManager.DeleteAsync(registeredUser);
                        return BadRequest("User registeration has been cancled due to a fail in assigning role.");
                    }
                }
                else
                {
                    return BadRequest(registrationResult.Errors?.FirstOrDefault()?.Description);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        
        [HttpGet("number_of_users")]
        public async Task<IActionResult> GetNumberOfUserAsync()
        {
            try
            {
                var instructers = await _userManager.GetUsersInRoleAsync("instructer");
                var instructersnb = instructers.Count();
                var admins = await _userManager.GetUsersInRoleAsync("admin");
                var adminsnb = admins.Count();

                return Ok(new { instructersnb, adminsnb });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("getadmins")]
        public async Task<IActionResult> GetAdminsAsync()
        {
            try
            {
                var admins = await _userManager.GetUsersInRoleAsync("admin");
                return Ok( admins );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet("getinstructers")]
        public async Task<IActionResult> GetInstructersAsync()
        {
            try
            {
                var instructers = await _userManager.GetUsersInRoleAsync("instructer");
                return Ok( instructers );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
}