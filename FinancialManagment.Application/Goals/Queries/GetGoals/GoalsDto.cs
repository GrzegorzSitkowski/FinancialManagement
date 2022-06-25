using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoals
{
    public class GoalsDto : IMapFrom<Goal>
    {
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesiredDate { get; set; }
        public int CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Goal, GoalsDto>();
        }
    }
}
