using FluentValidation;
using Shop.Application.Products.CreateProduct;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(createProductCommand => createProductCommand.ProductID).NotEqual(0);
            RuleFor(createProductCommand => createProductCommand.ProductBrand).NotNull();
            RuleFor(createProductCommand => createProductCommand.ProductModel).NotNull();
            RuleFor(createProductCommand => createProductCommand.ProductImage).NotNull();
            RuleFor(createProductCommand => createProductCommand.Price).Must(x => x > 0 && x < 1000000);
            RuleFor(createProductCommand => createProductCommand.CategoryID).NotEqual(0);
        }
    }
}
