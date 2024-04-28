using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class Devices
    {
        [Key]
        public int DeviceId { get; set; }

        [Required]
        public string DeviceName { get; set; }
        public string Consumer { get; set; }


        [ForeignKey("FarmId")]
        public int FarmId { get; set; }

        public Farms Farm { get; set; }

        public ICollection<DevicesTypeEnergy> DevicesTypeEnergy { get; set; }
    }
}
