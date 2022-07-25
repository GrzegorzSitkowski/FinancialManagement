using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Products.Queries.GetShoppingList;
using FinancialManagment.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Product.Queries
{
    [Collection("QueryCollection")]
    public class GetShoppingListQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetShoppingListQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetShoppingList()
        {
            var handler = new GetShoppingListQueryHandler(_context, _mapper);

            var result = await handler.Handle(new GetShoppingListQuery(), CancellationToken.None);

            result.ShouldBeOfType<ShoppingListVm>();
            result.ShouldNotBeNull();
        }
    }
}
