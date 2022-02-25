using System;
using WEB.ViewModels;
using WEB.Models;

namespace WEB.Interfaces;


public interface ICountryService
{
    Task<Country> FindCountryAsync(int id);
    Task CreateCountryAsync(CountryCreateViewModel model);
    IQueryable<CountryCreateViewModel> GetAllCountries();
    Task RemoveCountryAsync(CountryRemoveViewModel model);
    Task UpdateCountryAsync(CountryUpdateViewModel model);
}