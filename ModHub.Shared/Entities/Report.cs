using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Report
    {
        public int Id { get; set; }
        [Display(Name = "Titulo")]
        [Required]
        [MaxLength(40, ErrorMessage = "Tamaño maximo permitido")]
        public string Title { get; set; }

        [Display(Name = "Contenido  Reporte")]
        [Required]
        [MaxLength(1200, ErrorMessage = "Tamaño maximo permitido")]
        public string Content { get; set; }

        [JsonIgnore]
        public Mod Mod { get; set; }
        public int ModId { get; set; }

        [JsonIgnore]
        public Creator Creator { get; set; }
        public int CreatorId { get; set; }
    }
}
