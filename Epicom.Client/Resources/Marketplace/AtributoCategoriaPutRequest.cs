﻿using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/atributos", "PUT")]
    public class AtributoCategoriaPutRequest : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public bool AtributoValorLivre { get; set; }
        public IList<AtributoCategoriaValor> Valores { get; set; }
        
        public class AtributoCategoriaValor
        {
            public string Codigo { get; set; }
            public string Nome { get; set; }
        }
    }
}
