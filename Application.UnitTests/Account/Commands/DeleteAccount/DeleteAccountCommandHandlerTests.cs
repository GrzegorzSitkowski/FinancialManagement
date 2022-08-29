using Application.UnitTests.Common;
using FinancialManagment.Application.Accounts.Commands.DeleteAccount;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Account.Commands.DeleteAccount
{
    public class DeleteAccountCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteAccountCommandHandler _handler;

        public DeleteAccountCommandHandlerTests()
            :base()
        {
            _handler = new DeleteAccountCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldDeleteAccount()
        {
            var command = new DeleteAccountCommand()
            {
                Id = 9
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var acc = await _context.Accounts.FirstOrDefaultAsync(x => x.Id == command.Id && x.StatusId == 1, CancellationToken.None);

            acc.ShouldBeNull();
        }
    }
}
