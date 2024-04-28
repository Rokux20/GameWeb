using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameWeb.Models
{
    public class DevicesTypeEnergy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DevicesEnergyId { get; set; }
        public int DeviceId { get; set; }
        Devices Device { get; set; }
        public int TypeEnergyId { get; set; }
        TypeEnergy TypeEnergy { get; set; }

    }
}
