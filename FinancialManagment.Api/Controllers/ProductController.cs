using FinancialManagment.Application.Products.Commands.CreateProduct;
using FinancialManagment.Application.Products.Commands.DeleteProduct;
using FinancialManagment.Application.Products.Commands.UpdateProduct;
using FinancialManagment.Application.Products.Queries.GetProductDetail;
using FinancialManagment.Application.Products.Queries.GetShoppingList;
using FinancialManagment.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagment.Api.Controllers
{
    [Route("api/products")]
    public class ProductController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailVm>> GetProduct(int id)
        {
            var product = await Mediator.Send(new GetProductDetailQuery() { Id = id });
            return product;
        }

        [HttpGet]
        public async Task<ActionResult<ShoppingListVm>> GetShoppingLis()
        {
            return await Mediator.Send(new GetShoppingListQuery());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            var product = await Mediator.Send(command);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await Mediator.Send(new DeleteProductCommand() { Id = id});
            return Ok(product);
        }
    }
}
