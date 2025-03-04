using ECommerce.DtoLayer.BasketDtos;

namespace ECommerce.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
        Task<bool> RemoveBasketItem(string productId);
    }
}
