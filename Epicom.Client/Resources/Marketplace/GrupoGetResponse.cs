using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    public class GrupoGetResponse
    {
        public string Nome { get; set; }
        public IEnumerable<Atributo> Atributos { get; set; }

        public class Atributo
        {
            public string CodigoAtributoCategoria { get; set; }
            public string Nome { get; set; }
            public string CodigoValorAtributoCategoria { get; set; }
            public string Valor { get; set; }
        }
    }
}