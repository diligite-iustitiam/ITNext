using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IShopDbContext _dbContext;

        public DeleteProductCommandHandler(IShopDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Products
                .FindAsync(new object[] { request.ProductID }, cancellationToken);

            if (entity == null || entity.ProductID != request.ProductID)
            {
                throw new NotFoundException(nameof(Product), request.ProductID);
            }

            _dbContext.Products.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
