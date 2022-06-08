using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Queries.GetTransfers
{
    public class TransfersVm
    {
        public ICollection<TransfersDto> Transfers { get; set; }
    }
}
