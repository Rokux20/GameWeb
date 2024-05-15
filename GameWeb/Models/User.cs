using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

        
    }
}
