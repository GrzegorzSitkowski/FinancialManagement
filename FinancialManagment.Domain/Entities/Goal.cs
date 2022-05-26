using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesiredDate { get; set; }
        public string Note { get; set; }
        public ICollection<GoalCategory> GoalCategories { get; set; }
    }
}
