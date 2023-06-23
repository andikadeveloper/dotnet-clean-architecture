using dotnet_clean_architecture.Application.Common.Interfaces;

namespace dotnet_clean_architecture.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
