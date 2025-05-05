using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    internal class Category
    {

        public int Id { get; set; }


        [Display(Name = "Nombre Categoria")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        [MaxLength(55, ErrorMessage = "Nombre Demasiado largo")]//Caracteres maximos y mensaje de error
        public string FullName { get; set; }




    }
}
