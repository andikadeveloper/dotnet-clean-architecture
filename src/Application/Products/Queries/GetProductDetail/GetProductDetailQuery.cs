using AutoMapper;
using AutoMapper.QueryableExtensions;
using dotnet_clean_architecture.Application.Common.Exceptions;
using dotnet_clean_architecture.Application.Common.Interfaces;
using dotnet_clean_architecture.Application.Products.Queries.GetProductsWithPagination;
using dotnet_clean_architecture.Domain.Entities;
using MediatR;

namespace dotnet_clean_architecture.Application.Products.Queries.GetProductDetail;

public record GetProductDetailQuery : IRequest<ProductBriefDto>
{
    public int Id { get; init; }
}

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductBriefDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductDetailQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductBriefDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        return _mapper.Map<ProductBriefDto>(entity);
    }
}