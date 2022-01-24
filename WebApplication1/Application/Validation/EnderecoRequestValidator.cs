using ClienteAPI.Application.DTO;
using FluentValidation;

namespace ClienteAPI.Application.Validation
{
    public class EnderecoRequestValidator : AbstractValidator<EnderecoRequest>
    {
        public EnderecoRequestValidator()
        {
            RuleFor(c => c.CEP).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Logradouro).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Complemento).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Bairro).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Cidade).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.UF).NotEmpty().WithMessage("Campo obrigatório.");
        }
    }
}
