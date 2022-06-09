using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.ShoppingList.Commands.DeleteShoppingList
{
    public class DeleteShoppingListCommand : IRequest
    {
        public int ProductId { get; set; }
    }
}
