using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models
{
    public class Farms
    {
        [Key]
        public int FarmId { get; set; }
        public string FarmName { get; set; }

    }
}
