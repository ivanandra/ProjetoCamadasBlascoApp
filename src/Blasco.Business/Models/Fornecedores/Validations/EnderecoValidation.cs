using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Business.Models.Fornecedores.Validations
{
   public  class EnderecoValidation: AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(Endereco => Endereco.Logradouro)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(2, 200)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

            RuleFor(Endereco => Endereco.Numero)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(8)
                .WithMessage("O Campo {PropertyName} deve ser ter {MaxLength} caracteres");

            RuleFor(Endereco => Endereco.CEP)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(2, 200)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

            RuleFor(Endereco => Endereco.Complemento)
                .Length(1, 150)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

            RuleFor(Endereco => Endereco.Bairro)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .WithMessage("O Campo {PropertyName} é requerido");

            RuleFor(Endereco => Endereco.Cidade)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(3, 150)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

            RuleFor(Endereco => Endereco.Estado)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .WithMessage("O Campo {PropertyName} é requerido");

        }

    }
}
