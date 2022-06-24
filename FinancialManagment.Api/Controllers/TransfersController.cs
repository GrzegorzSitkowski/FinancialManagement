using FinancialManagment.Application.Transfers.Commands.CreateTransfer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagment.Api.Controllers
{
    [Route("api/transfers")]
    public class TransfersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddTransfer(CreateTransferCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
