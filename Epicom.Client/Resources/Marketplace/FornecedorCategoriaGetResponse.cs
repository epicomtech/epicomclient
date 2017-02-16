namespace Epicom.Client.Resources.Marketplace
{
    public class FornecedorCategoriaGetResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CaminhoCompleto { get; set; }
        public int? CategoriaPai { get; set; }
    }
}