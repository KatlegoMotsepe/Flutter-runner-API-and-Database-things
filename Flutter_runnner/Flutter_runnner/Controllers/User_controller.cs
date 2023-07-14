using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Flutter_runnner.DTOs;
using Flutter_runnner.Interfaces;
using static Org.BouncyCastle.Math.EC.ECCurve;
using System.Data.Entity;

namespace Flutter_runnner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_controller : Controller
    {


        private readonly ITokenService tokenService;
        private readonly IConfiguration configeration;
        public User_controller(IConfiguration config, ITokenService _tokenService)
        {
            tokenService = _tokenService;
             configeration = config;
        }
       
        [HttpPost("registerUser")]

        public async Task<IActionResult> ResgisterUser(User_register_DTOs user)
        {

            try
            {
                using var db = new DataContext();

                var dbUser = await db.Users.FirstOrDefaultAsync(x => x.Email == user.email);

                if (dbUser != null)
                {
                    return BadRequest("This email is attached to an account");
                }

                await db.Users.AddAsync(new User(user, configeration));

                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(user + " has been added");

        }

        [HttpPost("login")]

        public async Task<ActionResult> LoginUser(User_Login_DTOs user_)
        {
            using var db = new DataContext();

            var user = await db.Users.FirstOrDefaultAsync<User>(x => x.Email == user_.email);

            if (user == null)
            {
                return BadRequest("Invalid credentials");
            }

            if (user.Password == null)
            {
                return BadRequest("Password invalid");
            }

            if (user.Password == null) return BadRequest("Invalid credentials");
            var test = user.PasswordValidation(user_.password, configeration);

            if (test)
            {
         
                await db.SaveChangesAsync();

                //Will send JWT Token
                return Ok(new User_DTO
                {
                    User = user.Name + " " + user.Surname,
                    Token = tokenService.CreateToken(user)
                });
            }
            await db.SaveChangesAsync();

            return BadRequest("Invalid credentials");
        }

        [Authorize]
        [HttpGet("GetUser")]
        public async Task<ActionResult<IEnumerable<User_DTO>> GetUser()
        {
          if (w)
        }

       

    }
}
