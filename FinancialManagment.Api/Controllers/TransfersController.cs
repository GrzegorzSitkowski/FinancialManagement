using FinancialManagment.Application.Accounts.Queries.GetTransferDetail;
using FinancialManagment.Application.Transfers.Commands.CreateTransfer;
using FinancialManagment.Application.Transfers.Commands.UpdateTransfer;
using FinancialManagment.Application.Transfers.Queries.GetTransfers;
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

        [HttpGet]
        public async Task<ActionResult<TransfersVm>> GetTransfers()
        {
            return await Mediator.Send(new GetTransfersQuery());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTransfer(UpdateTransferCommand command)
        {
            var transfer = await Mediator.Send(command);
            return Ok(transfer);
        }
    }
}
