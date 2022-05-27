using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class Goal : AuditableEntity
    {
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesiredDate { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
        public GoalCategory GoalCategory { get; set; }
    }
}
