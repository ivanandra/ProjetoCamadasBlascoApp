using Blasco.Business.Models.Fornecedores;
using System.Data.Entity;
using System;
using System.Threading.Tasks;
using Blasco.Infra.Repository;

namespace Blasco.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(Fornecedor => Fornecedor.Endereco)
                .FirstOrDefaultAsync(Fornecedor => Fornecedor.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(Fornecedor => Fornecedor.Endereco)
                .Include(Fornecedor => Fornecedor.Produtos)
                .FirstOrDefaultAsync(Fornecedor => Fornecedor.Id == id);
        }
    }
}
