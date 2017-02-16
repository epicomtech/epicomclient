using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using System;
using System.Collections.Generic;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias/{CodigoCategoria}/atributos", "PUT")]
    public class CategoriaAtributoPutRequest : IEmptyResponse
    {
        public string CodigoCategoria { get; set; }
        public string Codigo { get; set; }
        public bool Obrigatorio { get; set; }
        public bool AllowVariations { get; set; }
        public IEnumerable<string> CodigosValores { get; set; }
    }
}
