using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models
{
    public class Farms
    {
        [Key]
        public int FarmId { get; set; }
        public string FarmName { get; set; }

        public ICollection<Devices> Devices { get; set; }
        public ICollection<Tasks> Tasks { get; set; }
        public ICollection<Crops> Crops { get; set; }
    }
}
