using CompanyErp.Models;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyErp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _appDbContext;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;   
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);

            if (user !=null && await _userManager.CheckPasswordAsync(user, data.Password))
            {
                // Create claims for the user
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Name, user.UserName),
                        // Add any additional claims you want in the token
                    };

                // Create a security key
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM"));

                // Create signing credentials using the security key
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Create a JWT token
                var token = new JwtSecurityToken(
                    //issuer: "YourIssuer",
                    //audience: "YourAudience",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1), // Set the expiration time of the token
                    signingCredentials: creds
                );

                // Serialize the token to a string
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { Message = "Login successful", Token = tokenString });
            }
            return BadRequest(new { Message = "Invalid login details" });
        }

        //[Authorize]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel data)
        {
            var user = await _userManager.FindByEmailAsync(data.Email);
            if(user != null)
            {
                return BadRequest(new { Message = "User with email already exists" });
            }

            var newuser = new ApplicationUser
            {
                UserName = data.Email,
                Email = data.Email,  
            };

            var result = await _userManager.CreateAsync(newuser, data.Password);

            return BadRequest(new { Message = "Problem in registration" });
        }

        [Authorize]
        [HttpPost("Profile")]
        public async Task<IActionResult> UpateProfile([FromBody] ProfileDTO data)
        {
            var userEmailFromToken = HttpContext.User.Identity?.Name;

            //get user from dbcontext
            var user = _appDbContext.Users.Where(x => x.Email == userEmailFromToken).FirstOrDefault();

            if(user != null)
            {
                user.UserName = data.Name ?? user.UserName;
                user.Email = data.Email ?? user.Email;
                user.PhoneNumber = data.MobileNo ?? user.PhoneNumber;
                user.Address = data.Address ?? user.Address;
                user.PinCode = data.PinCode ?? user.PinCode;    
                user.About = data.About ?? user.About;

            }
            try
            {
                _appDbContext.SaveChanges();
                return Ok("User updated successfully");
            }
            catch(Exception ex) 
            {
                return BadRequest(new { Message = "Problem in updating profile" });
            }
        }

        [Authorize]
        [HttpPost("ProfilePicture")]
        public async Task<IActionResult> UpateProfilePicture([FromBody] ProfilePicDTO data)
        {
            var userEmailFromToken = HttpContext.User.Identity?.Name;

            //get user from dbcontext
            var user = _appDbContext.Users.Where(x => x.Email == userEmailFromToken).FirstOrDefault();

            if (user != null)
            {
                // Handle profile picture upload
                if (data.ProfilePicture != null && data.ProfilePicture.Length > 0)
                {
                    // Generate a unique filename using timestamp
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(data.ProfilePicture.FileName);

                    // Specify the server location to save the profile pictures
                    string filePath = Path.Combine("/Media/ProfilePic/", fileName);

                    // Save the image to the server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await data.ProfilePicture.CopyToAsync(stream);
                    }

                    // Update the user's profile picture filename
                    user.ProfilePictureFileName = fileName;
                }

            }
            try
            {
                _appDbContext.SaveChanges();
                return Ok("User updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Problem in updating profile" });
            }
        }
    }
}
