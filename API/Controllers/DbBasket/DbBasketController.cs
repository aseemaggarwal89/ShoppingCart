using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DbBasket
{
    public class DbBasketController : BaseApiController
    {
        // public IBasketRepository _basketRepository { get; }
        private readonly IDBBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public DbBasketController(IDBBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketById(string id)
        {

            // var spec = new CustomerBasketWithBasketItemsSpecification(id);

            var basket = await _basketRepository.GetBasketAsync(id);

            if (basket == null)
            {
                return NotFound(new ApiResponse(404));
            }
            var dest = _mapper.Map<CustomerBasket, CustomerBasketDto>(basket);

            return Ok(dest);

        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasketDto basket)
        {
            // var spec = new CustomerBasketWithBasketItemsSpecification(basket.Id);
            var customerBasket = _mapper.Map<CustomerBasketDto, CustomerBasket>(basket);
            await _basketRepository.UpdateBasketAsync(customerBasket);
            var updatedBasket = await _basketRepository.GetBasketAsync(basket.Id);

            var dest = _mapper.Map<CustomerBasket, CustomerBasketDto>(updatedBasket);

            return Ok(dest);
        }

        // [HttpDelete]
        // public async Task DeleteBasketAsync(string id)
        // {
        //     await _basketRepository.DeleteBasketAsync(id);
        // }

    }
}