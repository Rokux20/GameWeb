﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameWeb.Models
{
    public class Tasks
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public bool Finished { get; set; }

        [ForeignKey("FarmId")]
        public int FarmId { get; set; }

        public Farms Farm { get; set; }
    }
}
