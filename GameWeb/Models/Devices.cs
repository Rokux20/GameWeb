using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameWeb.Models
{
    public class Devices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? Consumer { get; set; }
        public int FarmId { get; set; }
        Farms Farm { get; set; }

    }
}
