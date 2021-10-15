using Blasco.Business.Core.Data;
using System;
using System.Threading.Tasks;

namespace Blasco.Business.Models.Fornecedores
{
   public interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
