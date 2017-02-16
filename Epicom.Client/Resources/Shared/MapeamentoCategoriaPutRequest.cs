using Epicom.Http.Client;
using Epicom.Http.Client.Annotations;

namespace Epicom.Client.Resources.Shared
{
    /// <summary>
    /// Representa um mapeamento entre duas categorias ou entre uma categoria e um marketplace.
    /// </summary>
    [Route("shared/mapeamentos/categorias", "PUT")]
    public class MapeamentoCategoriaPutRequest : IEmptyResponse
    {
        /// <summary>
        /// Código da categoria a ser associada com a categoria de um parceiro, ou com o próprio parceiro,
        /// se este for um marketplace.
        /// O valor null pode ser informado caso o usuário autenticado seja um marketplace
        /// que deseja se associar diretamente com a categoria de um fornecedor.
        /// </summary>
        public string CodigoCategoria { get; set; }

        /// <summary>
        /// Código da categoria do parceiro a ser associada com a categoria do usuário autenticado.
        /// O valor null pode ser informado caso o usuário autenticado seja um fornecedor 
        /// que deseja associar uma categoria sua diretamente com um marketplace.
        /// </summary>
        public string CodigoCategoriaParceiro { get; set; }

        /// <summary>
        /// Código do parceiro ao qual se deseja associar uma categoria.
        /// </summary>
        public string CodigoParceiro { get; set; }
        public bool Ativo { get; set; }
    }
}