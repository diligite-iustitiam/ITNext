
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Application.Common.Exceptions;
using Shop.Domain;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
       : IRequestHandler<UpdateProductCommand>
    {
        private readonly IShopDbContext _dbContext;

        public UpdateProductCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Products.FirstOrDefaultAsync(product =>
                    product.ProductID == request.ProductID, cancellationToken);

            if (entity == null || entity.ProductID != request.ProductID)
            {
                throw new NotFoundException(nameof(Product), request.ProductID);
            }

            entity.ProductID = request.ProductID;
            entity.ProductDescription = request.ProductDescription;
            entity.ProductModel = request.ProductModel;
            entity.ProductBrand = request.ProductBrand;
            entity.ProductImage = request.ProductImage;
            entity.CategoryID = request.CategoryID;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
