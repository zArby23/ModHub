using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class Creator
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de usuario")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(75, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }

        [Display(Name = "Correo electrónico")]
        [Required]
        [EmailAddress(ErrorMessage = "Correo electrónico no valido")]
        [MaxLength(130, ErrorMessage = "Email Demasiado largo")]
        public string Email { get; set; }

        [Display(Name = "Fecha de Registro")] //Pone una Descripcion del campo
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; } //Fecha de registro por defecto es la fecha actual

        //Conexiones

        [JsonIgnore]
        public ICollection<Report> Reports { get; set; }

        [JsonIgnore]
        public ICollection<Mod> Mods { get; set; }

        [JsonIgnore]
        public ICollection<User> Users { get; set; }

        



    }
}
