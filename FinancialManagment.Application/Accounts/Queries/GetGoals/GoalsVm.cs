﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetGoals
{
    public class GoalsVm
    {
        ICollection<GoalsDto> Goals { get; set; }
    }
}
