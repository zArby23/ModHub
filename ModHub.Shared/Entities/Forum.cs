using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Forum
    {
        public int Id { get; set; }

        [Display(Name = "Título del Foro")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(40, ErrorMessage = "Tamaño maximo permitido")]//Caracteres maximos y mensaje de error
        public string Title { get; set; }

        [Display(Name = "Contenido del Foro")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(1200, ErrorMessage = "Tamaño maximo permitido")]//Caracteres maximos y mensaje de error
        public string Content { get; set; }

        [Display(Name = "Fecha de publicacion comentario")]
        [DataType(DataType.Date)]
        public DateTime PublicationDate = DateTime.Now; //Fecha de registro por defecto es la fecha actual

        //Conexion
        [JsonIgnore]
        public Game Game { get; set; }
        public int GameId { get; set; }
    }
}
