using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoals
{
    public class GoalsDto
    {
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesiredDate { get; set; }
        public GoalCategory GoalCategories { get; set; }
    }
}
