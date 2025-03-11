using ECommerce.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace ECommerce.WebUI.Services.OrderServices.OrderOderingServices
{
    public interface IOrderOrderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
