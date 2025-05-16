using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Creator
    {

        public int Id { get; set; }


        [Display(Name = "Nombre Creator")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }


        [Display(Name = "Email Creator")]
        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        [MaxLength(130, ErrorMessage = "Email Demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "Fecha Registro Creator")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Contraseña Demasiado larga")]
        public string DateRegistration { get; set; }

        //Conexiones

        ICollection<Report> Reports { get; set; }

        ICollection<Mod> Mods { get; set; }

        ICollection<User> Users { get; set; }

        



    }
}
