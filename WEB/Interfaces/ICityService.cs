using System;
using WEB.ViewModels;
namespace WEB.Interfaces;

public interface ICityService
{
    Task CreateCityAsync(CityCreateViewModel model);
    IQueryable<CityCreateViewModel> GetAllCities();
    Task RemoveCityAsync(CityRemoveViewModel model);
    Task UpdateCityAsync(CityUpdateViewModel model);
}