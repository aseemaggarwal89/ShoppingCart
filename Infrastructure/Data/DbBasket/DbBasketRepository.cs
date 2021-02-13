using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.DbBasket
{
    public class DbBasketRepository: IDBBasketRepository
    {
        private readonly StoreContext _context;
        public DbBasketRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            var item = await GetBasketAsync(basketId);
            if (item != null) {
                _context.Remove<CustomerBasket>(item);
                var task = await _context.SaveChangesAsync();
                return Convert.ToBoolean(task);
            } else {
                return true;
            }
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            return await _context.CustomerBasket.Include(p => p.Items).FirstOrDefaultAsync(p => p.Id == basketId);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var savedBasket = await GetBasketAsync(customerBasket.Id);
            foreach (var basketItem in customerBasket.Items)
            {
                basketItem.uniqueId = basketItem.Id + customerBasket.Id;
            }

            if (savedBasket == null)
            {
                _context.Add<CustomerBasket>(customerBasket);
                await _context.SaveChangesAsync();
                return customerBasket;
            } else {
                _context.BasketItem.RemoveRange(savedBasket.Items);
                savedBasket.Items.AddRange(customerBasket.Items);

                await _context.SaveChangesAsync();
                return savedBasket;
            }
        }
    }
}