using Application.UnitTests.Common;
using FinancialManagment.Application.Transfers.Commands.DeleteTransfer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Transfer.Commands.DeleteTransfer
{
    public class DeleteTransferCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteTransferCommandHandler _handler;
        public DeleteTransferCommandHandlerTests()
            :base()
        {
            _handler = new DeleteTransferCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldDeleteTransfer()
        {
            var command = new DeleteTransferCommand()
            {
                TransferId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var transfer = await _context.Transfers.FirstOrDefaultAsync(x => x.Id == command.TransferId && x.StatusId == 1, CancellationToken.None);

            transfer.ShouldBeNull();
        }
    }
}
