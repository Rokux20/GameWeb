using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameWeb.Models
{
    public class Crops
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CropId { get; set; }
        public string? CropName { get; set; }
        public int FarmId { get; set; }
        Farms Farm { get; set; }
    }
}
