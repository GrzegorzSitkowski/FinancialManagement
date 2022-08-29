using Application.UnitTests.Common;
using FinancialManagment.Application.Accounts.Commands.UpdateAccount;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Account.Commands.UpdateAccount
{
    public class UpdateAccountCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateAccountCommandHandler _handler;

        public UpdateAccountCommandHandlerTests()
            :base()
        {
            _handler = new UpdateAccountCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldDeleteAccount()
        {
            var command = new UpdateAccountCommand()
            {
                Id = 9,
                Amount = 100,
                Name = "Test"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var acc = await _context.Accounts.FirstAsync(x => x.Id == command.Id, CancellationToken.None);

            acc.Name.ShouldBe("Test");
            acc.Amount.ShouldBe(100);
        }
    }
}
