using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetAccountDetail
{
    public class TransfersAccount : IMapFrom<Transfer>
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transfer, TransfersAccount>();
        }
    }
}
