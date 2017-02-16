using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Marketplace
{
    [Route("marketplace/categorias/{Codigo}", "GET")]
    public class CategoriaGetRequest : IResponse<CategoriaGetResponse>
    {
        public string Codigo { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != GetType()) return false;
            if (ReferenceEquals(this, obj)) return true;
            return string.Equals(Codigo, ((CategoriaGetRequest)obj).Codigo);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = hash * 31 + (Codigo == null ? 0 : Codigo.GetHashCode());
                return hash;
            }
        }
    }
}
