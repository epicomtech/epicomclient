using System.Collections.Generic;
using Epicom.Client.Resources.Shared;

namespace Epicom.Client.Resources.Marketplace
{
	public class DisponibilidadeGetResponse
	{
		public decimal Preco { get; set; }
		public decimal? PrecoDe { get; set; }
		public bool Disponivel { get; set; }
		public int? Estoque { get; set; }
	}

}
