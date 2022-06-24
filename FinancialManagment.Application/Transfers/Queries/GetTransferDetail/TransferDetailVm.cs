using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetTransferDetail
{
    public class TransferDetailVm : IMapFrom<Transfer>
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int AccountId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transfer, TransferDetailVm>();
        }
    }
}
