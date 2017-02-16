using System.ComponentModel.DataAnnotations;

namespace Epicom.Client.Resources.Shared
{
    public class PedidoEndereco
    {
        [Required]
        public string Bairro { get; set; }

        /// <summary>
        /// Somente dígitos ex. 22631455
        /// </summary>
        [Required, RegularExpression(@"^\d{8}$")]
        public string Cep { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Complemento { get; set; }

        /// <summary>
        /// Estado (sigla com dois caracteres ex. SP)
        /// </summary>
        [Required, RegularExpression(@"(\-|AC|AL|AP|AM|BA|CE|DF|ES|GO|MA|MT|MS|MG|PA|PB|PR|PE|PI|RJ|RN|RS|RR|RO|SC|SP|SE|TO)")]
        public string Estado { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        /// <summary>
        /// Somente dígitos com codigo de area ex. 11996500800
        /// </summary>
        [Required, Phone]
        public string Telefone { get; set; }

        /// <summary>
        /// Ponto de referência para entrega
        /// </summary>
        public string Referencia { get; set; }
    }
}
