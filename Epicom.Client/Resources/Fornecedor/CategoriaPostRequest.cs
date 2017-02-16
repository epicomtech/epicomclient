using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Fornecedor
{
    [Route("fornecedor/categorias", "POST")]
    public class CategoriaPostRequest : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CategoriaPai { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Associavel { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != GetType()) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = (CategoriaPostRequest)obj;
            return string.Equals(Codigo, other.Codigo) &&
                string.Equals(Nome, other.Nome) &&
                string.Equals(CategoriaPai, other.CategoriaPai);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = hash * 31 + (Codigo == null ? 0 : Codigo.GetHashCode());
                hash = hash * 31 + (Nome == null ? 0 : Nome.GetHashCode());
                hash = hash * 31 + (CategoriaPai == null ? 0 : CategoriaPai.GetHashCode());
                return hash;
            }
        }
    }
}
