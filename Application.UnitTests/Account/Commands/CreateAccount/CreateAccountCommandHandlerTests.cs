using Application.UnitTests.Common;
using FinancialManagment.Application.Accounts.Commands.CreateAccount;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Account.Command.CreateAccount
{
    public class CreateAccountCommandHandlerTests : CommandTestBase
    {
        private readonly CreateAccountCommandHandler _handler;
        public CreateAccountCommandHandlerTests()
            :base()
        {
            _handler = new CreateAccountCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertAccount()
        {
            var command = new CreateAccountCommand()
            {
                Amount = 5000,
                Name = "Name",
                TypeId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var acc = await _context.Accounts.FirstAsync(x => x.Id == result, CancellationToken.None);

            acc.ShouldNotBeNull();
        }
    }
}
