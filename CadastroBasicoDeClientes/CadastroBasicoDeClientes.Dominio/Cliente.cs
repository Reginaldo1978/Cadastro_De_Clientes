using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroBasicoDeClientes.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Preencha o nome do cliente")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o email do cliente")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a UF do cliente")]
        public string UF { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Preencha a data de nascimento do cliente")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
    }
}
