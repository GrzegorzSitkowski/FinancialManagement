using Application.UnitTests.Common;
using FinancialManagment.Application.Transfers.Commands.UpdateTransfer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Transfer.Commands.UpdateTransfer
{
    public class UpdateTransferCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateTransferCommandHandler _handler;
        public UpdateTransferCommandHandlerTests()
            :base()
        {
            _handler = new UpdateTransferCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidReqest_ShouldUpdateTransfer()
        {
            var command = new UpdateTransferCommand()
            {
                TransferId = 1,
                CategoryId = 1,
                Description = "Car",
                Name = "Fuel",
                TypeId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var transfer = await _context.Transfers.FirstOrDefaultAsync(x => x.Id == command.TransferId, CancellationToken.None);

            transfer.ShouldNotBeNull();
            transfer.Name.ShouldBe("Fuel");
            transfer.CategoryId.ShouldBe(1);
            transfer.Description.ShouldBe("Car");
            transfer.TypeId.ShouldBe(1);
        }
    }
}
