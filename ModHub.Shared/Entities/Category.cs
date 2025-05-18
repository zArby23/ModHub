using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Category
    {

        public int Id { get; set; }


        [Display(Name = "Nombre Categoria")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(55, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }

        [Display(Name = "Descripcion Categoria")]
        [Required]
        [MaxLength(800, ErrorMessage = "Tamaño maximo permitido")]
        public string DescriptionCategory { get; set; }



        //Conexiones
        [JsonIgnore]

        ICollection<Game> Games { get; set; }



    }
}
