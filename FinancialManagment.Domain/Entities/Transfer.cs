using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class Transfer : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int TypeId { get; set; }
        public TransferType TransferType { get; set; }
        public int CategoryId { get; set; }
        public TransferCategory TransferCategory { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
