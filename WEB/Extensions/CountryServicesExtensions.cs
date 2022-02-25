using System;
using WEB.Services;
using WEB.Interfaces;

namespace WEB.Extensions;

public static class CountryServicesExtensions
{
    public static void AddCountryService(this IServiceCollection services)
    {
        services.AddTransient<ICountryService, CountryService>();
    }
}