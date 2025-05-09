using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }


        [Display(Name = "Nombre Usuario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }


        [Display(Name = "Email Usuario")]
        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        [MaxLength(130, ErrorMessage = "Email Demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "Contraseña Usuario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Contraseña Demasiado larga")]
        public string Password { get; set; }

        [Display(Name = "Fecha Registro Usuario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Contraseña Demasiado larga")]
        public string DateRegistration { get; set; }

        [Display(Name = "Fecha Registro Usuario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Contraseña Demasiado larga")]
        public string DateRegistration { get; set; }




    }
}
