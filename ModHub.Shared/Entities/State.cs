using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModHub.Shared.Entities
{
    public class State
    {

        public int Id { get; set; }


        [Display(Name = "Nombre del estado")] //Pone una Descripcion del campo
        [Required] //Hace que sea obligatorio
        public string StateName { get; set; }


    }
}
