using System;
using WEB.Interfaces;
using WEB.Data;
using WEB.ViewModels;
using WEB.Models;

namespace WEB.Services;
 public class CityService :ICityService
{
    private readonly DatabaseContext Context;


    public CityService(DatabaseContext context)
    {
      this.Context = context;
    }
    public async Task CreateCityAsync(CityCreateViewModel model)
    {
        City city = new City();
        city.Name = model.Name;
        city.CountryId = model.CountryId;
        await Context.Cities.AddAsync(city);
        await Context.SaveChangesAsync();
    }
    public IQueryable<CityCreateViewModel> GetAllCities()
    {
        var result = Context.Cities.Select(c => new CityCreateViewModel{
            Name = c.Name
        });
        
        return result;
    }
    public async Task UpdateCityAsync(CityUpdateViewModel model)
    {
        var requestedCity = await Context.Cities.FindAsync(model.Id);
        requestedCity.Name = model.Name;
        Context.Update(requestedCity);
        await Context.SaveChangesAsync();
    }
     public async Task RemoveCityAsync(CityRemoveViewModel model)
    {
        var requestedCity = await Context.Cities.FindAsync(model.Id);
        Context.Remove(requestedCity);
        await Context.SaveChangesAsync();
    }
}