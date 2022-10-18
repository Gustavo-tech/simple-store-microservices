using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Cart.Application.Extensions;

public static class ServicesConfigurator
{
    public static void ConfigureServices(this IServiceCollection collection)
    {
        collection.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
