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

       
        public User(User_register_DTOs user, IConfiguration configeration)
        {
            Name = user.name;
            Surname = user.surname;
            Email = user.email;
            Password = user.password;
        }
       

    
    public User() { }


}
}
