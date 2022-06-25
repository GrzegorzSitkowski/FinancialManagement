using FinancialManagment.Application.Accounts.Queries.GetGoalDetail;
using FinancialManagment.Application.Accounts.Queries.GetGoals;
using FinancialManagment.Application.Goals.Commands.CreateGoal;
using FinancialManagment.Application.Goals.Commands.DeleteGoal;
using FinancialManagment.Application.Goals.Commands.UpdateGoal;
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

        [HttpGet]
        public async Task<ActionResult<GoalsVm>> GetGoals()
        {
            return await Mediator.Send(new GetGoalsQuery());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal(UpdateGoalCommand command)
        {
            var goal =  await Mediator.Send(command);
            return Ok(goal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGoal(int id)
        {
            var goal = await Mediator.Send(new DeleteGoalCommand() {GoalId = id });
            return Ok(goal);
        }
    }
}
