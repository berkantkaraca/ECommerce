namespace ECommerce.DtoLayer.CatalogDtos.BannerDtos
{
    public class UpdateBannerDto
    {
        public string BannerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
