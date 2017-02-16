using System.Collections.Generic;

namespace Epicom.Client.Resources.Shared
{
    public class GrupoPostRequest
    {
        public string Nome { get; set; }
        public IEnumerable<Atributo> Atributos { get; set; }

        public class Atributo
        {
            public string Nome { get; set; }
            public string Valor { get; set; }
        }
    }
}