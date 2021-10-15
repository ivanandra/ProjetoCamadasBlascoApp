using System;
using System.Linq;
using System.Threading.Tasks;
using Blasco.Business.Core.Services;
using Blasco.Business.Models.Fornecedores.Validations;


namespace Blasco.Business.Models.Fornecedores.Sevices
{
    public class FornecedorService : BaseService, IFornecedorService
    {

        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IEnderecoRepository enderecoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
        }
        public async Task Adicionar(Fornecedor fornecedor)
        {
            if (!ExecuteValidation(new FornecedorValidation(), fornecedor)
                || !ExecuteValidation(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (await FornecedorExistente(fornecedor)) return;

            await _fornecedorRepository.Adicionar(fornecedor);
        }

        public async Task Atualizar(Fornecedor fornecedor)
        {

            if (!ExecuteValidation(new FornecedorValidation(), fornecedor)
                || !ExecuteValidation(new EnderecoValidation(), fornecedor.Endereco)) return;

            if (await FornecedorExistente(fornecedor)) return;

            await _fornecedorRepository.Atualizar(fornecedor);

        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecuteValidation(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task<bool>FornecedorExistente(Fornecedor fornecedor)
        {
            var fornecedorAtual = await _fornecedorRepository.Buscar(Fornecedor => Fornecedor.Documento == fornecedor.Documento && Fornecedor.Id != Fornecedor.Id);

            return fornecedorAtual.Any();
        }

        public async Task Remover(Guid id)
        {
            var fornecedor = await _fornecedorRepository.ObterFornecedorProdutosEndereco(id);

            if (fornecedor.Produtos.Any()) return;

            if(fornecedor.Endereco != null)
            {
                await _enderecoRepository.Remover(fornecedor.Id);
            }

            await _fornecedorRepository.Remover(id);
        }

        public void Dispose()
        {
            _fornecedorRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}
