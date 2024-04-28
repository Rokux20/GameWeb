using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class Crops
    {
        [Key]
        public int CropId { get; set; }

        [Required]
        public string CropName { get; set; }

        [ForeignKey("FarmId")]
        public int FarmId { get; set; }

        public Farms Farm { get; set; }
    }
}
