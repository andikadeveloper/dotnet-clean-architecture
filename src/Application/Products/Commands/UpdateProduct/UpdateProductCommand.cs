using dotnet_clean_architecture.Application.Common.Exceptions;
using dotnet_clean_architecture.Application.Common.Interfaces;
using dotnet_clean_architecture.Domain.Entities;
using MediatR;

namespace dotnet_clean_architecture.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand : IRequest
{
    public int Id { get; init; }
    public string? Name { get; init; }
    public string? Image { get; init; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Product), request.Id);
        }

        entity.Name = request.Name;
        entity.Image = request.Image;

        await _context.SaveChangesAsync(cancellationToken);
    }

}