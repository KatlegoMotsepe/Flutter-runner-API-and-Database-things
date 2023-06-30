using Flutter_runnner;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;

namespace Flutter_runnner
{
    public class User
    {
        private User user;

        private IConfiguration configeration;

        [Key]
        public Guid id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool ForgotPassword { get; set; }


        public User(User_register_DTOs user, IConfiguration configeration)
        {
            Name = user.name;
            Surname = user.surname;
            Email = user.email;
           
        }
        public User() { }

        public void HashPassword(string password, IConfiguration config)
        {
            using var hmac = new HMACSHA512();
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + config["TokenKey"]));
            PasswordSalt = hmac.Key;
        }

        public bool PasswordValidation(string password, IConfiguration config)
        {
            using var hmac = new HMACSHA512(PasswordSalt);

            var newHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + config["TokenKey"]));

            if (newHash.Length != PasswordHash.Length)
            {
                return false;
            }

            for (int i = 0; i < newHash.Length; i++)
            {
                if (newHash[i] != PasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }
        


    }
}
