using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Interfaces
{
    public interface IOrderingRepository
    {
        public List<Ordering> GetOrderingsByUserId(string id);
    }
}
