using Application.UnitTests.Common;
using FinancialManagment.Application.Goals.Commands.UpdateGoal;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Goal.Commands.UpdateGoal
{
    public class UpdateGoalCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateGoalCommandHandler _handler;

        public UpdateGoalCommandHandlerTests()
            :base()
        {
            _handler = new UpdateGoalCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldUpdateGoal()
        {
            var command = new UpdateGoalCommand()
            {
                Id = 1,
                SavedAmount = 10,
                TargetAmount = 11,
                CategoryId = 3,
                Name = "Travel",
                Note = "Barcelona",
                DesireDate = new DateTime(2 / 2 / 2030)
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == command.Id);

            goal.SavedAmount.ShouldBe(10);
            goal.TargetAmount.ShouldBe(11);
            goal.CategoryId.ShouldBe(3);
            goal.Name.ShouldBe("Travel");
            goal.Note.ShouldBe("Barcelona");
        }
    }
}
