using ECommerce.DtoLayer.OrderDtos.OrderAddressDtos;

namespace ECommerce.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAddressService
    {
        Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
    }
}
