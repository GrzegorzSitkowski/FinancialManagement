using FinancialManagment.Application.Accounts.Commands.CreateAccount;
using FinancialManagment.Application.Accounts.Queries.GetAccountDetail;
using FinancialManagment.Application.Accounts.Commands.UpdateAccount;
using Microsoft.AspNetCore.Mvc;    
using System.Threading.Tasks;
using FinancialManagment.Application.Accounts.Commands.DeleteAccount;
using FinancialManagment.Application.Accounts.Queries.GetAccounts;

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
        public async Task<ActionResult<AccountDetailVm>> GetAccount(int id)
        {
            var vm = await Mediator.Send(new GetAccountDetailQuery() { AccountId = id });
            return vm;
        }

        [HttpGet]
        public async Task<ActionResult<AccountsVm>> GetAccounts()
        {
            return await Mediator.Send(new GetAccountsQuery());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount(UpdateAccountCommand command)
        {
            var account = await Mediator.Send(command);
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var account = await Mediator.Send(new DeleteAccountCommand() { Id = id });
            return Ok(account);
        }
        
    }
}
