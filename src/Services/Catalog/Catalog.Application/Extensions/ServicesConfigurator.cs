using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application.Extensions;

public static class ServicesConfigurator
{
    public static void ConfigureServices(this IServiceCollection collection)
    {
        collection.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
