using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Application.Extensions;
public static class HttpResponseExtensions
{
    public async static Task<T> ReadAs<T>(this HttpResponseMessage response)
    {
        return JsonConvert.DeserializeObject<T>(await response?.Content?.ReadAsStringAsync());
    }
}
