using FinancialManagment.Application.Accounts.Queries.GetGoalDetail;
using FinancialManagment.Application.Goals.Commands.CreateGoal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagment.Api.Controllers
{
    [Route("api/goals")]
    public class GoalsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddGoal(CreateGoalCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalDetailVm>> GetGoal(int id)
        {
            var vm = await Mediator.Send(new GetGoalDetailQuery() { GoalId = id });
            return vm;
        }
    }
}
