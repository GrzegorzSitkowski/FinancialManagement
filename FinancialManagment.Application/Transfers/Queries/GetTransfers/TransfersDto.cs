using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Queries.GetTransfers
{
    public class TransfersDto : IMapFrom<Transfer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }     
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Transfer, TransfersDto>();
        }
    }
}
