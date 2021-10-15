using Blasco.Business.Models.Fornecedores;
using Blasco.Business.Models.Fornecedores.Sevices;
using Blasco.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blasco.AppMVC.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedoresController()
        {
            _fornecedorService = new FornecedorService(new FornecedorRepository(), new EnderecoRepository());
        }
        public async Task<ActionResult> Index()
        {

            var fornecedor = new Fornecedor()
            {
                Nome = "",
                Documento = "7771616",
                Endereco = new Endereco(),
                TipoFornecedor = TipoFornecedor.PessoaFisica,
                Ativo = true

            };

            await _fornecedorService.Adicionar(fornecedor);

            return new EmptyResult();
            
        }
    }
}