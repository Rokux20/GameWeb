using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models
{
    public class Devices
    {
        [Key]
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Consumer { get; set; }
        public int FarmId { get; set; }
    }
}
