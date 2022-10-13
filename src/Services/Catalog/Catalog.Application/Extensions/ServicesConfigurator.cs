using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Extensions;

public static class ServicesConfigurator
{
    public static void ConfigureServices(this IServiceCollection collection)
    {
        collection.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
