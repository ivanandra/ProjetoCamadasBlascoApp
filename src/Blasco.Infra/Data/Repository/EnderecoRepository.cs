using Blasco.Business.Models.Fornecedores;
using System;
using System.Threading.Tasks;
using Blasco.Infra.Repository;

namespace Blasco.Infra.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await ObterPorId(fornecedorId);
        }
    }
}
