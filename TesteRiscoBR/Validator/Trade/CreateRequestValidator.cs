using FluentValidation;
using TesteRiscoBR.Entidates;

namespace TesteRiscoBR.Model.Trade.Create;


public class CreateRequestValidator : AbstractValidator<TradeEntity>
{
    public CreateRequestValidator()
    {
        RuleFor(x => x.Value).NotEmpty().WithMessage("Valor é obrigatório.").PrecisionScale(10, 2, true).WithMessage("O valor deve ter no máximo dez dígitos e duas casas decimais.");
        RuleFor(x => x.ClientSector).NotEmpty().WithMessage("Setor é obrigatório.");
        RuleFor(x => x.NextPaymentDate).NotEmpty().WithMessage("Data é obrigatório.");
    }
}