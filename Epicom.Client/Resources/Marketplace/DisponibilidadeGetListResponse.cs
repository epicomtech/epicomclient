using System.Collections.Generic;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Resources.Marketplace
{
	public class DisponibilidadeGetListResponse
	{
        public int SkuId { get; set; }
        public string CodigoEmpresa { get; set; }
        public decimal? Preco { get; set; }
        public decimal? PrecoDe { get; set; }
    }

}
