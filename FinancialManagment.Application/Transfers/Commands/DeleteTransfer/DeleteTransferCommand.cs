using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.DeleteTransfer
{
    public class DeleteTransferCommand : IRequest
    {
        public int TransferId { get; set; }
    }
}
