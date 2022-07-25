using Application.UnitTests.Common;
using FinancialManagment.Application.Transfers.Commands.CreateTransfer;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Transfer.Commands.CreateTransfer
{
    public class CreateTransferCommandHandlerTests : CommandTestBase
    {
        private readonly CreateTransferCommandHandler _handler;

        public CreateTransferCommandHandlerTests()
            :base()
        {
            _handler = new CreateTransferCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertTransfer()
        {
            var command = new CreateTransferCommand()
            {
                AccountId = 9,
                Amount = 50,
                CategoryId = 2,
                TypeId = 3,
                Name = "Shopping",
                Description = "Achuan",
                Date = new DateTime(12 / 01 / 2022)
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var transfer = await _context.Transfers.FirstAsync(x => x.Id == result, CancellationToken.None);

            transfer.ShouldNotBeNull();
        }
    }
}
