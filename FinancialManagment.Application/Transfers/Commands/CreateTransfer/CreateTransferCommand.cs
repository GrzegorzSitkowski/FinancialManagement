﻿using FinancialManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Transfers.Commands.CreateTransfer
{
    public class CreateTransferCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public TransferType TransferType { get; set; }
        public TransferCategory TransferCategory { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
    }
}
