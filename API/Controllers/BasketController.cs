using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;

        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketDto>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);

            var dest = _mapper.Map<CustomerBasket, CustomerBasketDto>(basket ?? new CustomerBasket(id));
            return Ok(dest);
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateBasket(CustomerBasket basket)
        {
            var updateBasket = await _basketRepository.UpdateBasketAsync(basket);
            var dest = _mapper.Map<CustomerBasket, CustomerBasketDto>(updateBasket);

            return Ok(dest);
        }

        [HttpDelete]
        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }

    }
}