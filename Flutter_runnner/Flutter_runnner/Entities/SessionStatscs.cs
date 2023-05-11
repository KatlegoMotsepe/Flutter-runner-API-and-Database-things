using Flutter_runnner.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Flutter_runnner
{
    public class SessionStatscs
    {
        [Key]
        public int stats_Id { get; set; }

        [Required]
        public float top_speed { get; set; }

        [Required]
        public float low_speed { get; set; }

        [Required]
        public float average_speed { get; set; }

        [Required]
        public float average_pace { get; set; }
       
    }
}
