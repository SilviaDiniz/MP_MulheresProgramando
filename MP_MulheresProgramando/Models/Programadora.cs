using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MP_MulheresProgramando.Models
{
    public class Programadora
    {
        public int Id { get; set; }
        [Display(Name = "Programadora")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string NomeDev { get; set; }
        [Display(Name = "Linguagem de Programação")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int LinguagemId { get; set; }
        public Linguagem Linguagens { get; set; }
    }
}
