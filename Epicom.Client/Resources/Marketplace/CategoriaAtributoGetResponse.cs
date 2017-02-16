using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    public class CategoriaAtributoGetResponse
    {
        public string Codigo { get; set; }
        public bool Obrigatorio { get; set; }
        public IEnumerable<string> CodigosValores { get; set; }
    }
}