namespace Epicom.Client.Resources.Fornecedor
{
    public class DisponibilidadeGetResponse
    {
        public decimal Preco { get; set; }
        public decimal? PrecoDe { get; set; }
        public bool Disponivel { get; set; }
        public string CodigoMarketplace { get; set; }
    }
}
