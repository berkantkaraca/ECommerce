using ECommerce.DtoLayer.CommentDtos;

namespace ECommerce.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task<List<ResultCommentDto>> GetAllCommentAsync();
        Task<List<ResultCommentDto>> CommentListByProductId(string id);
        Task<UpdateCommentDto> GetByIdCommentAsync(string id);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPAssiveCommentCount();
    }
}
