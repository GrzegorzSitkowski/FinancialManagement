using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Accounts.Queries.GetShoppingList
{
    public class ShoppingListVm
    {
        ICollection<ShoppingListDto> ShoppingList { get; set; }
    }
}
