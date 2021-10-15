using Blasco.Business.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blasco.Business.Models.Produtos
{
   public interface IProdutoRepository : IRepository<Produto>
    {
        //traz uma lista de produtos de acordo com o fornecedor//
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid fornecedorId);
        //traz a lista de produtos e seus fornecedores
        Task<IEnumerable<Produto>> ObterProdutosFornecedores();
        //traz um produto e seu fornecedor de acordo com o id//
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
