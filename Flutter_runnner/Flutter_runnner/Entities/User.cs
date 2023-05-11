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
        public int Id { get; set; }

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

        public bool deleted { get; set; }

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        public User(User_register_DTOs user, IConfiguration configeration)
        {
            Name = user.name;
            Surname = user.surname;
            Email = user.email;
            Password = user.password;
        }
        public void HashPassword(string password, IConfiguration config)
        {
            using var hmac = new HMACSHA512();
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + config));
            passwordSalt = hmac.Key;
        }

        public bool PasswordValidation(string password, IConfiguration config)
        {
            using var hmac = new HMACSHA512(passwordSalt);

            var newHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password + config));

            if (newHash.Length != passwordHash.Length)
            {
                return false;
            }

            for (int i = 0; i < newHash.Length; i++)
            {
                if (newHash[i] != passwordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

    
    public User() { }


}
}
