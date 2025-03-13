using ECommerce.Cargo.DataAccessLayer.Abstract;
using ECommerce.Cargo.DataAccessLayer.Concrete;
using ECommerce.Cargo.DataAccessLayer.Repositories;
using ECommerce.Cargo.EntityLayer.Concrete;

namespace ECommerce.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }
        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
