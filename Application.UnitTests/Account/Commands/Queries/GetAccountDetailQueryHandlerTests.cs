using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Accounts.Queries.GetAccountDetail;
using FinancialManagment.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Account.Commands.Queries
{
    [Collection("QueryCollection")]
    public class GetAccountDetailQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountDetailQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetAccountDetailById()
        {
            var handler = new GetAccountDetailQueryHandler(_context, _mapper);
            var accountId = 9;

            var result = await handler.Handle(new GetAccountDetailQuery { AccountId = accountId }, CancellationToken.None);

            result.ShouldBeOfType<AccountDetailVm>();
            result.Name.ShouldBe("Oszczednosciowe");
        }
    }
}
