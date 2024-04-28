using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }
        public string Description { get; set; }
        public bool Finished { get; set; }
        public int FarmId { get; set; }
    }
}
