using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class DevicesTypeEnergy
    {
        [Key]
        public int DevicesEnergyId { get; set; }

        [ForeignKey("DeviceId")]
        public int DeviceId { get; set; }
        public Devices Device { get; set; }

        [ForeignKey("TypeEnergyId")]
        public int TypeEnergyId { get; set; }
        public TypeEnergy TypeEnergy { get; set; }

    }
}
