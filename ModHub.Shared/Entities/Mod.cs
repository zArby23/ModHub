using ModHub.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Mod
    {

        public int Id { get; set; }


        [Display(Name = "Nombre Mod")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(95, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }


        [Display(Name = "Genero Mod")]
        [Required]
        [MaxLength(50, ErrorMessage = "Genero Demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "Descripcion Mod")]
        [Required]
        [MaxLength(800, ErrorMessage = "Tamaño maximo permitido")]
        public string Description { get; set; }

        [Display(Name = "Version Mod")]
        [Required]
        public float Version { get; set; }

        [Display(Name = "FechaPublicacion Mod")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateOnly PublicationDate { get; set; }

        [Display(Name = "FechaActualizacion Mod")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateOnly UpdateDate { get; set; }

        [Display(Name = "Estado Mod")]
        public ModStatus ModStatus { get; set; }
        //Conexiones
        [JsonIgnore]

        public Report Report { get; set; }

        public int ReportId { get; set; }

        [JsonIgnore]

        public Creator Creator { get; set; }

        public int CreatorId { get; set; }

        [JsonIgnore]

        public Game Game { get; set; }


        public int GameId { get; set; }

    }
}
