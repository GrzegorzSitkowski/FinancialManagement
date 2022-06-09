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
        public int GoalId { get; set; }
    }
}
