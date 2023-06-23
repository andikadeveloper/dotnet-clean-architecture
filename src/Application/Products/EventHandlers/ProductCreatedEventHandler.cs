using dotnet_clean_architecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace dotnet_clean_architecture.Application.Products.EventHandlers;

public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
{
    private readonly ILogger<ProductCreatedEventHandler> _logger;

    public ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("clean_architecture_example Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}