using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly IMapper? _mapper;
        private readonly IShopDbContext? _context;
        public GetProductListQueryHandler(IMapper? mapper, IShopDbContext? context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            var productsQuery = await _context.Products
                
                .ProjectTo<ProductLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProductListVm { Products = productsQuery };
        }
    }
}
