using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class AccountType : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
