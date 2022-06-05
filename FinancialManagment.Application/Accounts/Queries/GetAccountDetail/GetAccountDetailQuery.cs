using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQuery : IRequest<AccountDetailVm>
    {
        public int AmountId { get; set; }
    }
}
