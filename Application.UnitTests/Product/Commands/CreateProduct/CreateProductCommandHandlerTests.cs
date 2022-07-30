using Application.UnitTests.Common;
using FinancialManagment.Application.Products.Commands.CreateProduct;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandlerTests : CommandTestBase
    {
        private readonly CreateProductHandler _handler;

        public CreateProductCommandHandlerTests()
            :base()
        {
            _handler = new CreateProductHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldInsertProduct()
        {
            var command = new CreateProductCommand()
            {
                Done = true,
                Price = 50,
                Product = "Pasta"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var product = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == result, CancellationToken.None);

            product.ShouldNotBeNull();
            product.Product.ShouldBe("Pasta");
            product.Price.ShouldBe(50);
            product.Done.ShouldBe(true);
        }
    }
}
