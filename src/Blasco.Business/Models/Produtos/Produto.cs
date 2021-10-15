using Blasco.Business.Core.Models;
using Blasco.Business.Models.Fornecedores;
using System;

namespace Blasco.Business.Models.Produtos
{
    public class Produto : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
        public Guid FornecedorID { get; set; }

        //Ef Relations//
        public Fornecedor Fornecedor { get; set; }
    }
}
