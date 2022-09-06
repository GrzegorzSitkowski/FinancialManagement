using AutoMapper;
using FinancialManagment.Application.Common.Mappings;
using FinancialManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagment.Application.Products.Queries.GetShoppingList
{
    public class ShoppingListDto : IMapFrom<ShoppingList>
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public bool Done { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ShoppingList, ShoppingListDto>();
        }
    }
}
