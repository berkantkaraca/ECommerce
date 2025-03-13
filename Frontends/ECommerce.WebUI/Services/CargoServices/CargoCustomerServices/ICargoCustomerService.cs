using ECommerce.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace ECommerce.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
