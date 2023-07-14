

using Flutter_runnner.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Flutter_runnner
{
    public class SessionsDetails
    {
        [Key]
        public int details_Id { get; set; }
        
        [Required]
        public float distance { get; set; }
        public DateTime date { get; set; }
        
        [Required]
        public DateTime duration { get; set; }
        
        [Required]
        public double points { get; set; } // Change to list of points

       
    }
}
