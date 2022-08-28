using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal SavedAmount { get; set; }
        public DateTime DesireDate { get; set; }
        public string Note { get; set; }
        public int CategoryId { get; set; }
    }
}
