using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommandValidator : AbstractValidator<CreateTransferCommand>
    {
        public CreateTransferCommandValidator()
        {
            RuleFor(x => x.AccountId).NotNull();
            RuleFor(x => x.Amount).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.TypeId).NotNull();
        }
    }
}
