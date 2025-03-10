﻿using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using ExamenP3J.Cevallos.ViewModels;
using Newtonsoft.Json;
namespace ExamenP3J.Cevallos

public class CountriesViewModel
{
    public ObservableCollection<Country> Countries { get; } = new ObservableCollection<Country>();
    HttpClient client = new HttpClient();

    public async Task SearchCountry(string name)
    {
        var response = await client.GetAsync($"https://restcountries.com/v3.1/name/{name}?fields=name,region,maps");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<Country>>(json); 
            foreach (var country in countries)
            { 
                Countries.Add(country);
            }
        }
        else
        {
            
        }
    }
}