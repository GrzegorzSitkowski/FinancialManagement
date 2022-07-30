using Application.UnitTests.Common;
using FinancialManagment.Application.Products.Commands.DeleteProduct;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTests.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandlerTests : CommandTestBase
    {
        private readonly DeleteProductCommandHandler _handler;
        public DeleteProductCommandHandlerTests()
            :base()
        {
            _handler = new DeleteProductCommandHandler(_context);
        }

        [Fact]
        public async Task Handle_GivenValidRequest_ShouldDeleteProduct()
        {
            var command = new DeleteProductCommand()
            {
                ProductId = 1
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var product = await _context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == command.ProductId && x.StatusId == 1, CancellationToken.None);

            product.ShouldBeNull();
        }
    }
}
