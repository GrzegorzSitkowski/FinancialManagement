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
    }
}
