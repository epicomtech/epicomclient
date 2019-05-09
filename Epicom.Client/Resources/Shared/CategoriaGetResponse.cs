namespace Epicom.Client.Resources.Shared
{
    public class CategoriaGetResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CategoriaPai { get; set; }
        public string NomeCategoriaPai { get; set; }
        public string CaminhoCompleto { get; set; }
        public bool Associada { get; set; }
        public bool Associavel { get; set; }
    }
}