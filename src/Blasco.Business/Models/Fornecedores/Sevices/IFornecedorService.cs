using System;
using System.Threading.Tasks;

namespace Blasco.Business.Models.Fornecedores.Sevices
{
   public interface IFornecedorService: IDisposable
    {
        Task Adicionar(Fornecedor fornecedor);

        Task Atualizar(Fornecedor fornecedor);

        Task Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}
