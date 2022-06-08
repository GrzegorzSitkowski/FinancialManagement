using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetTransferDetail
{
    public class TransferDetailVm
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public TransferType TransferType { get; set; }
        public TransferCategory TransferCategory { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
    }
}
