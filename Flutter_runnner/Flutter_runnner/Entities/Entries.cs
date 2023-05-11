using Flutter_runnner.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flutter_runnner
{
    public class Entries
    {
        [Key]
        public int entry_id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int user_id { get; set; }

        [Required]
        [ForeignKey("SessionStatscs")]
        public int stats_id { get; set; }

        [Required]
        [ForeignKey("SessionsDetails")]
        public int details_id { get; set; }

        public virtual User User { get; set; }
        public virtual SessionStatscs SessionStatscs { get; set; }
        public virtual SessionsDetails SessionsDetails { get; set; }

       

    }
}
