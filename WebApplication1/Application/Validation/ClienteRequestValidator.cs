using ClienteAPI.Application.DTO;
using FluentValidation;

namespace ClienteAPI.Application.Validation
{
    public class ClienteRequestValidator : AbstractValidator<ClienteRequest>
    {
        public ClienteRequestValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.CPF).NotEmpty().WithMessage("Campo obrigatório.");
            
            RuleFor(c => c.EnderecoId).NotEmpty().WithMessage("Campo obrigatório.");

            RuleFor(c => c.Email).NotEmpty().WithMessage("Campo obrigatório.").EmailAddress()
                .WithMessage("Email inválido.")
                .OnAnyFailure(p => p.Email = "");

            RuleFor(c => c.Nascimento).NotEmpty().WithMessage("Campo obrigatório.")
                .LessThan(p => DateTime.Now).WithMessage("A data deve estar no passado.");
        }
    }
}
