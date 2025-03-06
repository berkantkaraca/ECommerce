using ECommerce.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace ECommerce.WebUI.Services.OrderServices.OrderOderingServices
{
    public interface IOrderOderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
