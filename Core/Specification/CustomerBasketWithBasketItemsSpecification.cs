using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class CustomerBasketWithBasketItemsSpecification : BaseSpecification<CustomerBasket>
    {
        public CustomerBasketWithBasketItemsSpecification(string basketId) : base(x => x.Id == basketId)
        {
            AddInclude(x => x.Items);
        }
    }
}