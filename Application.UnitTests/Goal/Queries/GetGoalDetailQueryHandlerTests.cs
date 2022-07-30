using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Accounts.Queries.GetGoalDetail;
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
    public class GetGoalDetailQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetGoalDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetGoalDetailById()
        {
            var handler = new GetGoalDetailQueryHandler(_context, _mapper);

            var goalId = 1;

            var result = await handler.Handle(new GetGoalDetailQuery { GoalId = goalId }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Name.ShouldBe("Auto");
        }
    }
}
