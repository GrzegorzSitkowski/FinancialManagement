using Application.UnitTests.Common;
using FinancialManagment.Application.Goals.Commands.CreateGoal;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Goal.Commands.CreateGoal
{
    public class CreateGoalCommandHandlerTests : CommandTestBase
    {
        private readonly CreateGoalCommandHandler _handler;

        public CreateGoalCommandHandlerTests()
            :base()
        {
            _handler = new CreateGoalCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertGoal()
        {
            var command = new CreateGoalCommand()
            {
                SavedAmount = 100,
                TargetAmount = 500,
                CategoryId = 1,
                Name = "New car",
                Note = "Note",
                DesiredDate = new DateTime(1 / 1 / 2025)
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == result, CancellationToken.None);

            goal.ShouldNotBeNull();
            goal.Name.ShouldBe("New car");
            goal.TargetAmount.ShouldBe(500);
        }
    }
}
