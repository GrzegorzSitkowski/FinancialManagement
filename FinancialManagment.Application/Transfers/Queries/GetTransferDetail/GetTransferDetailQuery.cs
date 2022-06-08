using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetTransferDetail
{
    public class GetTransferDetailQuery : IRequest<TransferDetailVm>
    {
        public int TransferId { get; set; }
    }
}
