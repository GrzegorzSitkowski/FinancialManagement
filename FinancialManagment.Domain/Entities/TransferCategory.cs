using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class TransferCategory : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Transfer> Transfers { get; set; }
    }
}
