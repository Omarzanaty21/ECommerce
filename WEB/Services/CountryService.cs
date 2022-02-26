using System;
using WEB.Interfaces;
using WEB.Data;
using WEB.ViewModels;
using WEB.Models;

namespace WEB.Services;
 public class CountryService :ICountryService
{
    private readonly DatabaseContext Context;

    public CountryService(DatabaseContext context)
    {
      this.Context = context;
    }
    public async Task CreateCountryAsync(CountryCreateViewModel model)
    {
        var country = new Country();
        country.Name = model.Name;
        await Context.Countries.AddAsync(country);
        await Context.SaveChangesAsync();
    }
    public IQueryable<CountryCreateViewModel> GetAllCountries()
    {
        var result = Context.Countries.Select(c => new CountryCreateViewModel{
            Name = c.Name,
            CountryId = c.Id
        });  
        return result;
    }
    public async Task UpdateCountryAsync(CountryUpdateViewModel model)
    {
        var requestedCountry = await Context.Countries.FindAsync(model.Id);
        if(requestedCountry != null)
        {
            requestedCountry.Name = model.Name;
            Context.Update(requestedCountry);
            await Context.SaveChangesAsync();
        } 
    }
     public async Task RemoveCountryAsync(CountryRemoveViewModel model)
    {
        var requestedCountry = await Context.Countries.FindAsync(model.Id);
        Context.Remove(requestedCountry);
        await Context.SaveChangesAsync();
    }
     public async Task<Country> FindCountryAsync(int id)
    {
        var requestedCountry = await Context.Countries.FindAsync(id);
        return requestedCountry;
    }
}