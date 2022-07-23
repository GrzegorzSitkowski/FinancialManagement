using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Accounts.Queries.GetAccounts;
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
    public class GetAccountsQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetAccountsQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetAccounts()
        {
            var handler = new GetAccountsQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetAccountsQuery(),  CancellationToken.None);

            result.ShouldBeOfType<AccountsVm>();
            result.Accounts.Count.ShouldBe(1);
        }
    }
}
