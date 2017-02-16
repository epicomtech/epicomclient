using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;
using Newtonsoft.Json;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias", "POST")]
    public class CategoriaPostRequest : IEmptyResponse
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CategoriaPai { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? Associavel { get; set; }

        protected bool Equals(CategoriaPostRequest other)
        {
            return string.Equals(Codigo, other.Codigo) && string.Equals(Nome, other.Nome) && string.Equals(CategoriaPai, other.CategoriaPai) && Associavel == other.Associavel;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CategoriaPostRequest) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Codigo != null ? Codigo.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Nome != null ? Nome.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (CategoriaPai != null ? CategoriaPai.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Associavel.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(CategoriaPostRequest left, CategoriaPostRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CategoriaPostRequest left, CategoriaPostRequest right)
        {
            return !Equals(left, right);
        }
    }
}
