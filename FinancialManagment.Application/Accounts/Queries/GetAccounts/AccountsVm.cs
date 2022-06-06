using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccounts
{
    public class AccountsVm
    {
        ICollection<AccountsDto> Accounts { get; set; }
    }
}
