using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Admin
    {
        public int Id { get; set; }


        [Display(Name = "Nombre Admin")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(150, ErrorMessage = "Nombre Demasiado Admin")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }


        [Display(Name = "Email Admin")]
        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        [MaxLength(130, ErrorMessage = "Email Demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "FechaNacimiento Admin")]
        [Required]
        public DateOnly birthdate { get; set; }




    }
}
