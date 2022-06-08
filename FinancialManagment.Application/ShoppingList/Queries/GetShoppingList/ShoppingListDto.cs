using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetShoppingList
{
    public class ShoppingListDto
    {
        public string Product { get; set; }
        public decimal Price { get; set; }
        public bool Done { get; set; }
    }
}
