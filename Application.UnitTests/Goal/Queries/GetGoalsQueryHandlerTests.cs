using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Accounts.Queries.GetGoals;
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

namespace Application.UnitTests.Goal.Queries
{
    [Collection("QueryCollection")]
    public class GetGoalsQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetGoalsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetGoals()
        {
            var handler = new GetGoalsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetGoalsQuery(), CancellationToken.None);

            result.ShouldBeOfType<GoalsVm>();
            result.Goals.Count.ShouldBe(1);
        }
    }
}
