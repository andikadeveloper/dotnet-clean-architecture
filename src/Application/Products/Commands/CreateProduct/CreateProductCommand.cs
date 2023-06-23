using dotnet_clean_architecture.Application.Common.Interfaces;
using dotnet_clean_architecture.Domain.Entities;
using dotnet_clean_architecture.Domain.Events;
using MediatR;

namespace dotnet_clean_architecture.Application.Products.Commands.CreateProduct;

public record CreateProductCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Image { get; init; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = request.Name,
            Image = request.Image
        };

        entity.AddDomainEvent(new ProductCreatedEvent(entity));

        _context.Products.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}