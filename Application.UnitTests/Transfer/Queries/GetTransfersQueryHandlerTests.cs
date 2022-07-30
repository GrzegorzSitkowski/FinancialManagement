using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Transfers.Queries.GetTransfers;
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
    public class GetTransfersQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetTransfersQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetTransfers()
        {
            var handler = new GetTransfersQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetTransfersQuery(), CancellationToken.None);

            result.ShouldBeOfType<TransfersVm>();
            result.Transfers.Count.ShouldBe(1);
        }
    }
}
