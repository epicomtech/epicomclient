using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Shared
{
    public class PedidoDestinatario
    {
        [Required]
        public string CpfCnpj { get; set; }

        public string InscricaoEstadual { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
     
    }
}
