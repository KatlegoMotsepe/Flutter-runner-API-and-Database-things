using System.ComponentModel.DataAnnotations;

namespace Flutter_runnner.DTOs
{
    public class History_page_DOTs
    {
     public int id { get; set; }
        public float distance { get; set; }
        public DateTime duration { get; set; }
        public float average_speed { get; set; }
        public float average_pace { get; set; }
        public float top_speed { get; set; }
    }
}
