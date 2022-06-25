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
        public IActionResult Index()
        {
            return View();
        }
    }
}
