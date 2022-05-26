using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class GoalCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Goals> Goal { get; set; }
    }
}
