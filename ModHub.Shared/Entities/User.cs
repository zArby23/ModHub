using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ModHub.Shared.Enums;

namespace ModHub.Shared.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Document { get; set; } = null!;

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Address { get; set; } = null!;

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

        [Display(Name = "Tipo de usuario")]
        public UserType UserType { get; set; }
        [JsonIgnore]
        public Creator Creator { get; set; }

        public int CreatorID { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

    }
}
