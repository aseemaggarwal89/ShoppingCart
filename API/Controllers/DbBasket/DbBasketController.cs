using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.DbBasket
{
    public class DbBasketController: BaseApiController
    {
        // public IBasketRepository _basketRepository { get; }
        public IBasketRepository _repo;
        public IMapper _mapper { get; }
        public DbBasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repo = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasketToReturnDto>> GetBasketById(string id)
        {

            // var spec = new CustomerBasketWithBasketItemsSpecification(id);

            var basket = await _repo.GetBasketAsync(id);
            
            if (basket == null) 
            {
                return NotFound(new ApiResponse(404));
            }
            var dest = _mapper.Map<CustomerBasket, CustomerBasketToReturnDto>(basket);

            return Ok(dest);
            
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasketToReturnDto>> UpdateBasket(CustomerBasket basket)
        {
            // var spec = new CustomerBasketWithBasketItemsSpecification(basket.Id);
            await _repo.UpdateBasketAsync(basket);
            var updatedBasket = await _repo.GetBasketAsync(basket.Id);

            var dest = _mapper.Map<CustomerBasket, CustomerBasketToReturnDto>(updatedBasket);

            return Ok(dest);
        }

        // [HttpDelete]
        // public async Task DeleteBasketAsync(string id)
        // {
        //     await _basketRepository.DeleteBasketAsync(id);
        // }

    }
}