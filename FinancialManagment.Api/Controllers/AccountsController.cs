using FinancialManagment.Application.Accounts.Commands.CreateAccount;
using FinancialManagment.Application.Accounts.Queries.GetAccountDetail;
using FinancialManagment.Application.Accounts.Commands.UpdateAccount;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialManagment.Application.Accounts.Commands.DeleteAccount;

namespace FinancialManagment.Api.Controllers
{
    [Route("api/accounts")]
    public class AccountsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddAccount(CreateAccountCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountDetailVm>> GetDetails(int id)
        {
            var vm = await Mediator.Send(new GetAccountDetailQuery() { AccountId = id });
            return vm;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UpdateAccountCommand command)
        {
            var account = await Mediator.Send(command);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var account = await Mediator.Send(new DeleteAccountCommand() { AccountId = id });
            return Ok(account);
        }
        
    }
}
