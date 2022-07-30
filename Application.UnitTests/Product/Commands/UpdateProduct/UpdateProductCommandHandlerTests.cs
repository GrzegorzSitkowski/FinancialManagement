using Application.UnitTests.Common;
using FinancialManagment.Application.Products.Commands.UpdateProduct;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandlerTests : CommandTestBase
    {
        private readonly UpdateProductCommandHandler _handler;

        public UpdateProductCommandHandlerTests()
            :base()
        {
            _handler = new UpdateProductCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldUpdateProduct()
        {
            var command = new UpdateProductCommand()
            {
                ProductId = 1,
                Price = 29,
                Done = false,
                Product = "Plant"
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var product = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == command.ProductId, CancellationToken.None);

            product.Price.ShouldBe(29);
            product.Done.ShouldBe(false);
            product.Product.ShouldBe("Plant");
        }
    }
}
