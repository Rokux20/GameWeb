using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameWeb.Models
{
    public class TypeEnergy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeEnergyId { get; set; }
        public string? TypeEnergyName { get; set; }
    }
}
