using Application.UnitTests.Common;
using AutoMapper;
using FinancialManagment.Application.Products.Queries.GetProductDetail;
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
    public class GetProductQueryHandlerTests
    {
        private readonly FinancialDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandlerTests(QueryTestFixtures fixtures)
        {
            _context = fixtures.Context;
            _mapper = fixtures.Mapper;
        }

        [Fact]
        public async Task CanGetProductDetailById()
        {
            var handler = new GetProductDetailQueryHandler(_context, _mapper);

            var productId = 6;

            var result = await handler.Handle(new GetProductDetailQuery { Id = productId }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.Product.ShouldBe("Ketchup");
        }
    }
}
