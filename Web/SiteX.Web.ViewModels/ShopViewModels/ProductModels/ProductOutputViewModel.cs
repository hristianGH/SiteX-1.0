namespace SiteX.Web.ViewModels.ShopViewModels.ProductModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using SiteX.Data.Models.Shop;
    using SiteX.Services.Mapping;

    public class ProductOutputViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        [Display(Name = "Name of product")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, double.MaxValue - 100)]
        [Display(Name = "Price in Bgn")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        [MaxLength(400)]
        [MinLength(3)]
        public string Description { get; set; }

        [MinLength(1)]
        [MaxLength(3)]
        public ICollection<Category> Categories { get; set; } = new List<Category>();

        [Required]
        [MaxLength(4)]
        public ICollection<Location> Locations { get; set; } = new List<Location>();

        [MinLength(1)]
        public ICollection<Size> Sizes { get; set; } = new List<Size>();

        [MinLength(1)]
        public ICollection<Color> Colors { get; set; } = new List<Color>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Product, ProductOutputViewModel>()
                .ForMember(x => x.Categories, opt =>
                {
                    opt.MapFrom(x => x.ProductCategories.Select(x => x.Category).ToList());
                })
                .ForMember(x => x.Locations, opt =>
                {
                    opt.MapFrom(x => x.ProductLocations.Select(x => x.Location).ToList());
                })
                .ForMember(x => x.Sizes, opt =>
                {
                    opt.MapFrom(x => x.ProductSizes.Select(x => x.Size).ToList());
                })
                .ForMember(x => x.Colors, opt =>
                {
                    opt.MapFrom(x => x.ProductColors.Select(x => x.Color).ToList());
                })
                .ForMember(x => x.ImageUrl, opt =>
                {
                    opt.MapFrom(x => x.ProductImages.OrderBy(x => x.Id).Select(x => x.Path).FirstOrDefault());
                })
                .ReverseMap();
        }
    }
}
