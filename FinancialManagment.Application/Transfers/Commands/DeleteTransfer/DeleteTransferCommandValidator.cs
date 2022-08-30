using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommandValidator : AbstractValidator<DeleteTransferCommand>
    {
        public DeleteTransferCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
