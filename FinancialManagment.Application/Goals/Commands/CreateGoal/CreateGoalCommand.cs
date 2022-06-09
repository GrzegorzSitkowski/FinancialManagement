using FinancialManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.CreateGoal
{
    public class CreateGoalCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesiredDate { get; set; }
        public string Note { get; set; }
        public GoalCategory goalCategory { get; set; }
    }
}
