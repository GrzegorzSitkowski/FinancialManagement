using FinancialManagment.Application.Products.Commands.CreateProduct;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddProduct (CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
