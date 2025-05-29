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
        public string Name { get; set; }


        [Display(Name = "Genero Mod")]
        [Required]
        [MaxLength(50, ErrorMessage = "Genero Demasiado largo")]
        public string Genre { get; set; }

        [Display(Name = "Descripcion Mod")]
        [Required]
        [MaxLength(800, ErrorMessage = "Tamaño maximo permitido")]
        public string Description { get; set; }

        [Display(Name = "Version Mod")]
        [Required]
        public float Version { get; set; }

        [Display(Name = "FechaPublicacion Mod")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; } = DateTime.Now;

        [Display(Name = "FechaActualizacion Mod")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        [Display(Name = "Estado Mod")]
        public ModStatus ModStatus { get; set; }
       
        //Conexiones

        [JsonIgnore]
        public ICollection<Report> Reports { get; set; }

        [JsonIgnore]
        public Creator Creator { get; set; }
        public int? CreatorId { get; set; }

        [MaxLength(75)]
        public string CreatorName { get; set; }

        [JsonIgnore]
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
