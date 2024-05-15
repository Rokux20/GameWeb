using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        public string Partida { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        User User { get; set; }

        [ForeignKey("FarmId")]
        public int FarmId { get; set; }
        Farms Farm { get; set; }


    }
}
