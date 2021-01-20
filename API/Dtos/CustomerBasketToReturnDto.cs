using System.Collections.Generic;

namespace API.Dtos
{
    public class CustomerBasketToReturnDto
    {
        public string Id { get; set; }
        public List<BasketItemToReturnDto> Items { get; set; }
    }
}