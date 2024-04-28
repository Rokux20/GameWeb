using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models
{
    public class TypeEnergy
    {
        [Key]
        public int TypeEnergyId { get; set; }

        [Required]
        public string TypeEnergyName { get; set; }

        public ICollection<DevicesTypeEnergy> DevicesTypeEnergy { get; set; }
    }
}
