using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Goals.Commands.UpdateGoal
{
    public class UpdateGoalCommandValidator : AbstractValidator<UpdateGoalCommand>
    {
        public UpdateGoalCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.GoalId).NotNull();
            RuleFor(x => x.SavedAmount).NotNull();
            RuleFor(x => x.TargetAmount).NotNull();
            RuleFor(x => x.DesireDate).NotNull();
        }
    }
}
