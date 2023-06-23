using dotnet_clean_architecture.Application.Common.Exceptions;
using dotnet_clean_architecture.Application.Common.Interfaces;
using dotnet_clean_architecture.Domain.Entities;
using dotnet_clean_architecture.Domain.Events;
using MediatR;

namespace dotnet_clean_architecture.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int id) : IRequest;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.id);
        }

        _context.Products.Remove(entity);

        entity.AddDomainEvent(new ProductDeletedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);
    }
}
