using FinancialManagment.Application.Accounts.Queries.GetTransferDetail;
using FinancialManagment.Application.Transfers.Commands.CreateTransfer;
using FinancialManagment.Application.Transfers.Commands.DeleteTransfer;
using FinancialManagment.Application.Transfers.Commands.UpdateTransfer;
using FinancialManagment.Application.Transfers.Queries.GetTransfers;
using FinancialManagment.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagment.Api.Controllers
{
    [Route("api/transfers")]
    public class TransfersController : BaseController
    {
        private readonly FinancialDbContext _context;
        public TransfersController(FinancialDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddTransfer(CreateTransferCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransferDetailVm>> GetTransfer(int id)
        {
            var vm = await Mediator.Send(new GetTransferDetailQuery() { Id = id });
            return vm;
        }

        [HttpGet]
        public async Task<ActionResult<TransfersDto>> GetTransfers()
        {
            var transfers = await _context.Transfers.AsNoTracking().Where(p => p.StatusId == 1).ToListAsync();
            return Ok(transfers);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransfer(UpdateTransferCommand command)
        {
            var transfer = await Mediator.Send(command);
            return Ok(transfer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTransfer (int id)
        {
            var transfer = await Mediator.Send(new DeleteTransferCommand() { Id = id });
            return Ok(transfer);
        }
    }
}
