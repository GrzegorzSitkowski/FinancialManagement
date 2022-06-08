using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Queries.GetTransfers
{
    public class TransfersDto
    {
        public decimal Amount { get; set; }
        public TransferType TransferType { get; set; }
        public TransferCategory TransferCategory { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}
