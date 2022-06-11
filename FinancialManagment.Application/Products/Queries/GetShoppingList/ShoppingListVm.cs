using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Products.Queries.GetShoppingList
{
    public class ShoppingListVm
    {
        public ICollection<ShoppingListDto> Products { get; set; }
    }
}
