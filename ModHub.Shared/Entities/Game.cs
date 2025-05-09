using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Display(Name = "Nombre Juego")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(120, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }

        [Display(Name = "Descripcion Juego")]
        [Required]
        [MaxLength(800, ErrorMessage = "Tamaño maximo permitido")]
        public string Description { get; set; }
    }
}
