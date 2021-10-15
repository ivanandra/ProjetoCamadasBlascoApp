using FluentValidation;

namespace Blasco.Business.Models.Produtos.Validations
{
    public class ProdutoValidation: AbstractValidator<Produto>
    {
        public ProdutoValidation()
        {

            RuleFor(Produto => Produto.Nome)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(2, 200)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength} caracteres");

            RuleFor(Produto => Produto.Descricao)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .Length(10, 1000)
                .WithMessage("O Campo {PropertyName} deve ser entre {MinLength} e {MaxLength}");

            RuleFor(Produto => Produto.Valor)
                .NotEmpty().WithMessage("O Campo {PropertyName} é requerido")
                .GreaterThan(0)
                .WithMessage("O Campo {PropertyName}precisa ser maior que {ComparisonValue}");
           
        }

    }
}
