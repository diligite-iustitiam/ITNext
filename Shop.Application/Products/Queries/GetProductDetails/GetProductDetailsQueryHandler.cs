using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Shop.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Domain;

namespace Shop.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler :  IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly IMapper? _mapper;
        private readonly IShopDbContext? _context;

        public GetProductDetailsQueryHandler(IMapper? mapper, IShopDbContext? context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(product =>
                product.ProductID == request.ProductID, cancellationToken);

            if (entity == null || entity.ProductID != request.ProductID)
            {
                throw new NotFoundException(nameof(Product), request.ProductID);
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
