using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    internal class Foro
    {


        public int Id { get; set; }


        [Display(Name = "Contenido  Comentario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(1200, ErrorMessage = "Tamaño maximo permitido")]//Caracteres maximos y mensaje de error
        public string content { get; set; }


        [Display(Name = "FechaPublicacion Comentario")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "FechaPublicacion Respuesta")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DatePublicationResponse { get; set; }


    }
}
