﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.UpdateTransfer
{
    public class UpdateTransferCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}
