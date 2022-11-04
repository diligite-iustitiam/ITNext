using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Products.Commands.UpdateProduct;
using System.ComponentModel.DataAnnotations;

namespace WebProjectOnAzure.Models
{
    public class UpdateDTOProduct : IMapWith<UpdateProductCommand>
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "A Product Brand is required")]
        [StringLength(160)]
        public string? ProductBrand { get; set; }
        [Required(ErrorMessage = "A Product Model is required")]
        [StringLength(160)]
        public string? ProductModel { get; set; }
        [Required(ErrorMessage = "A Product Description is required")]
        [StringLength(1000)]
        public string? ProductDescription { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100000.00,
            ErrorMessage = "Price must be between 0.01 and 100000.00")]
        public decimal Price { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string? ProductImage { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDTOProduct, UpdateProductCommand>()
                .ForMember(noteCommand => noteCommand.CategoryID,
                    opt => opt.MapFrom(noteDto => noteDto.CategoryID))
                .ForMember(noteCommand => noteCommand.ProductBrand,
                    opt => opt.MapFrom(noteDto => noteDto.ProductBrand))
                .ForMember(noteCommand => noteCommand.ProductModel,
                    opt => opt.MapFrom(noteDto => noteDto.ProductModel))
                .ForMember(noteCommand => noteCommand.ProductDescription,
                    opt => opt.MapFrom(noteDto => noteDto.ProductDescription))
                .ForMember(noteCommand => noteCommand.Price,
                    opt => opt.MapFrom(noteDto => noteDto.Price))
                .ForMember(noteCommand => noteCommand.ProductImage,
                    opt => opt.MapFrom(noteDto => noteDto.ProductImage));
        }
    }
}
