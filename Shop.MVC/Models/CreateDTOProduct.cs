
using AutoMapper;
using Shop.Application.Common.Mappings;
using Shop.Application.Products.CreateProduct;

namespace WebProjectOnAzure.Models
{
    public class CreateDTOProduct  : IMapWith<CreateProductCommand>
    {
        public int CategoryID { get; set; }
        public string? ProductBrand { get; set; }
        public string? ProductModel { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ProductImage { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDTOProduct, CreateProductCommand>()
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
