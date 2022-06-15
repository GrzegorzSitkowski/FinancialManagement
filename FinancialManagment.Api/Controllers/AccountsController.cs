﻿using FinancialManagment.Application.Accounts.Commands.CreateAccount;
using FinancialManagment.Application.Accounts.Queries.GetAccountDetail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
