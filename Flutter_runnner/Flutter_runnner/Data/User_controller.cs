﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Flutter_runnner;
using Flutter_runnner.DTOs;

namespace Flutter_runnner
{
    [ApiController]
    [Route("api/[controller]")]
    public class User_controller : Controller
    {

        
        private readonly IConfiguration configeration;
        public User_controller( IConfiguration config)
        {

            configeration = config;
        }
        [HttpGet("loginUser")]

        public async Task<ActionResult> LoginUser(User_Login_DTOs user)
        {
            using var db = new DataContext();

            var dbUser = await db.Users.FirstOrDefaultAsync(x => x.Email == user.email);

            if (dbUser == null)
            {
                return BadRequest("Invalid credentials");
            }

            if (dbUser.deleted == true) return BadRequest("Invalid credentials");

            if (user.password == null) return BadRequest("Invalid credentials");

            var test = dbUser.PasswordValidation(user.password, configeration);

            if (test)
            {
               
                await db.SaveChangesAsync();    
            }
           
            await db.SaveChangesAsync();

            return BadRequest("Invalid credentials");
        }

        [HttpPost("registerUser")]

        public async Task<IActionResult> ResgisterUser(User_register_DTOs user)
        {
            using var db = new DataContext();
            var dbUser = await db.Users.FirstOrDefaultAsync(x => x.Email == user.email);   
            if (dbUser == null) { return BadRequest("This email is attached to an account"); }
            await db.Users.AddAsync(new User(user, configeration));
            await db.SaveChangesAsync();
            return Ok(user+" has been added");


        }
    }

  


}