using ECommerce.Cargo.BusinessLayer.Abstract;
using ECommerce.Cargo.DataAccessLayer.Abstract;
using ECommerce.Cargo.EntityLayer.Concrete;

namespace ECommerce.Cargo.BusinessLayer.Concrete
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomer;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
        {
            _cargoCustomer = cargoCustomerDal;
        }

        public void TDelete(int id)
        {
            _cargoCustomer.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomer.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomer.GetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomer.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomer.Update(entity);
        }
    }
}
