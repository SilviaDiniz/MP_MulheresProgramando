using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MulheresProgramando.Models
{
    public class Linguagem
    {
        public int Id { get; set; }
        [Display(Name = "Linguagem")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Nome { get; set; }
       
    }
}
