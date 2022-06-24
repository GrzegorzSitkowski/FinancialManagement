using FinancialManagment.Application.Accounts.Queries.GetTransferDetail;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDetailVm>> GetTransfer(int id)
        {
            var vm = await Mediator.Send(new GetTransferDetailQuery() { TransferId = id });
            return vm;
        }
    }
}
