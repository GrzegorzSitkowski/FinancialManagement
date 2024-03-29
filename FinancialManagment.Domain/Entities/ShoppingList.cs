﻿using FinancialManagment.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Domain.Entities
{
    public class ShoppingList : AuditableEntity
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public bool Done { get; set; }
    }
}
