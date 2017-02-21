﻿using System.Collections.Generic;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Resources.Fornecedor
{
    public class ProdutoGetResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string NomeReduzido { get; set; }
        public string Descricao { get; set; }
        public string CodigoCategoria { get; set; }
        public string CodigoFornecedor { get; set; }
        public string CodigoMarca { get; set; }
        public IEnumerable<GrupoGetResponse> Grupos { get; set; }
    }
}