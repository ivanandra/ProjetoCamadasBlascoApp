using Blasco.Business.Models.Produtos;
using System;
using System.Threading.Tasks;
using Blasco.Infra.Repository;
using System.Collections.Generic;

namespace Blasco.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await Db.Produtos.AsNoTracking()
                .Include(f: Produto => f.Fornecedor)
                .FirstOrDefaultAsync(Produto => Produto.Id = id);
                
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
            return await Db.Produtos.AsNoTracking()
                 .Include(f: Produto => f.Fornecedor)
                 .OrderBy(Produto => Produto.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid fornecedorId)
        {
            return await Buscar(Produto => Produto.FornecedorID == fornecedorId);    

        }

    }
}
