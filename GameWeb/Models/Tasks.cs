using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameWeb.Models
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public string? Description { get; set; }
        public bool? Finished { get; set; }
        public int FarmId { get; set; }
        Farms Farm { get; set; }

    }
}
