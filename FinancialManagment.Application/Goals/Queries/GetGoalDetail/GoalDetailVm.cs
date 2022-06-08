using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoalDetail
{
    public class GoalDetailVm
    {
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesireDate { get; set; }
        public string Note { get; set; }
        public GoalCategory GoalCategorires { get; set; }
    }
}
