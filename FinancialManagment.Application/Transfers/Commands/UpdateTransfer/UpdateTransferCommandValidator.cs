using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommandValidator : AbstractValidator<UpdateTransferCommand>
    {
        public UpdateTransferCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.TypeId).NotNull();
        }
    }
}
