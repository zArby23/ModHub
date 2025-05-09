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


        [Display(Name = "Contenido  Reporte")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(1200, ErrorMessage = "Tamaño maximo permitido")]//Caracteres maximos y mensaje de error
        public string Content { get; set; }




        //conexiones
        [JsonIgnore]

        public Creator Creator { get; set; }

        public int CreatorId { get; set; }

    }
}
