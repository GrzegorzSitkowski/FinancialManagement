using Application.UnitTests.Common;
using FinancialManagment.Application.Goals.Commands.DeleteGoal;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Goal.Commands.DeleteGoal
{
    public class DeleteGoalCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteGoalCommandHandler _handler;

        public DeleteGoalCommandHandlerTests()
            :base()
        {
            _handler = new DeleteGoalCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldDeleteGoal()
        {
            var command = new DeleteGoalCommand()
            {
                GoalId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var goal = await _context.Goals.FirstOrDefaultAsync(x => x.Id == command.GoalId && x.StatusId == 1, CancellationToken.None);

            goal.ShouldBeNull();
        }
    }
}
