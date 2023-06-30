using System.ComponentModel.DataAnnotations;

namespace Flutter_runnner.DTOs
{
    public class UpadateUser_DTO
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
