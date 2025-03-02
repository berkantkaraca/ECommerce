using ECommerce.DtoLayer.CatalogDtos.ContactDtos;

namespace ECommerce.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
    }
}
