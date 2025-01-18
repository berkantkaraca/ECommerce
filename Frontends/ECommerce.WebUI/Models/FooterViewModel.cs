using ECommerce.DtoLayer.CatalogDtos.AboutDtos;
using ECommerce.DtoLayer.CatalogDtos.SocialMediaDtos;

namespace ECommerce.WebUI.Models
{
    public class FooterViewModel
    {
        public List<ResultAboutDto> Abouts { get; set; }
        public List<ResultSocialMediaDto> SocialMedias { get; set; }
    }
}
