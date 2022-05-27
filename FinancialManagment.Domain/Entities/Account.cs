using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
    }
}
