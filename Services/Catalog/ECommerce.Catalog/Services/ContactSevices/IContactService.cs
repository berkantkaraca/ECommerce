using ECommerce.Catalog.Dtos.ContactDtos;

namespace ECommerce.Catalog.Services.ContactSevices
{
    public interface IContactService
    {
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task<List<ResultContactDto>> GettAllContactAsync();
        Task<GetByIdContactDto> GetByIdContactAsync(string id);
        Task UpdateContactAsync(UpdateContactDto updateContactDto);
        Task DeleteContactAsync(string id);
    }
}
