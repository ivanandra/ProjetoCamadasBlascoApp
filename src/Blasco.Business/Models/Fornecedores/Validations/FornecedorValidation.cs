using Blasco.Business.Core.Validations.Documents;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Business.Models.Fornecedores.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public  FornecedorValidation()
        {
            RuleFor(Fornecedor => Fornecedor.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(2, 200)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

           
            When(Fornecedor => Fornecedor.TipoFornecedor == TipoFornecedor.PessoaFisica, () => {

                RuleFor(Fornecedor => Fornecedor.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo Documento precisa ter{ComparisonValue}caracteres  e foi fornecido {PropertyValue} caracteres");

                RuleFor(Fornecedor => CpfValidacao.Validar(Fornecedor.Documento)).Equal(true)
                .WithMessage("Cpf Inválido");

            });

            When(Fornecedor => Fornecedor.TipoFornecedor == TipoFornecedor.PessoaJuridica, () => {

                RuleFor(Fornecedor => Fornecedor.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                  .WithMessage("O campo Documento precisa ter{ComparisonValue} caracteres e foi fornecido {PropertyValue} caracteres");

                RuleFor(Fornecedor => CnpjValidacao.Validar(Fornecedor.Documento)).Equal(true)
                .WithMessage("Cpf Inválido");

            });

        }

    }
}
