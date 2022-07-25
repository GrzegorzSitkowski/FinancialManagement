using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Accounts.Queries.GetTransferDetail;
using FinancialManagment.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Transfer.Queries
{
    [Collection("QueryCollection")]
    public class GetTransferDetailQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetTransferDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetTransferDetailById()
        {
            var handler = new GetTransferDetailQueryHandler(_context, _mapper);
            var transferId = 1;

            var result = await handler.Handle(new GetTransferDetailQuery { TransferId = transferId }, CancellationToken.None);

            result.ShouldBeOfType<TransferDetailVm>();
            result.Description.ShouldBe("Home");
        }
    }
}
