using FluentValidation;
using TesteRiscoBR.Entidates;

namespace TesteRiscoBR.Model.Category.Create;


public class CreateRequestValidator : AbstractValidator<CategoryEntity>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório.");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Tipo é obrigatório.").Must(operatorValue => new[] { "PUBLIC", "PRIVATE" }.Contains(operatorValue)).WithMessage("Tipo inválido! Permitidos: 'PUBLIC' ou 'PRIVATE'.");
        RuleFor(x => x.Operator).NotEmpty().WithMessage("Operador é obrigatório.").Must(operatorValue => new[] { "=", ">", "<" }.Contains(operatorValue)).WithMessage("Operador inválido! Permitidos: '=', '>' ou '<'.");
        RuleFor(x => x.Value).NotEmpty().WithMessage("Valor é obrigatório.").PrecisionScale(10, 2, true).WithMessage("O valor deve ter no máximo dez dígitos e duas casas decimais.");

    }
}