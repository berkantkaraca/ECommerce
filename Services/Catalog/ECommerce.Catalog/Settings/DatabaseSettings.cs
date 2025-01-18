namespace ECommerce.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string FeatureSliderCollectionName { get; set; }
        public string ProductDetailsCollectionName { get; set; }
        public string ProductImagesCollectionName { get; set; }
        public string BannerCollectionName { get; set; }
        public string CampaignCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string BrandCollectionName { get; set; }
        public string SocialMediaCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
