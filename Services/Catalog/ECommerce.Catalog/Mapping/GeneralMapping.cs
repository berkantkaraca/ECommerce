using AutoMapper;
using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Dtos.BannerDtos;
using ECommerce.Catalog.Dtos.BrandDtos;
using ECommerce.Catalog.Dtos.CampaignDtos;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Dtos.SocialMediaDtos;
using ECommerce.Catalog.Entities;

namespace ECommerce.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategoryDto>().ReverseMap();

            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, GetByIdBannerDto>().ReverseMap();
            CreateMap<Banner, ResultBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();

            CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
            CreateMap<Campaign, GetByIdCampaignDto>().ReverseMap();
            CreateMap<Campaign, ResultCampaignDto>().ReverseMap();
            CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();

            CreateMap<Brand, CreateBrandDto>().ReverseMap();
            CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
            CreateMap<Brand, ResultBrandDto>().ReverseMap();
            CreateMap<Brand, UpdateBrandDto>().ReverseMap();
            
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, GetByIdAboutDto>().ReverseMap();
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, GetByIdSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();

            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, GetByIdContactDto>().ReverseMap();
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
        }
    }
}
