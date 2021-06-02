using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BeerApi.Model;
using Newtonsoft.Json;

namespace BeerApi.Clients
{
    public class BeerClient
    {
        private HttpClient _client;
        

       
        /// </summary>
        private static string _adres;

        public BeerClient()
        {
           
            ///
            _adres = Constants.adres;



            _client = new HttpClient();

            _client.BaseAddress = new Uri(_adres); 
            //
           
        }

        
        public async Task<IEnumerable<BeerInfo>> BeerByName(string name)
        {
            var response = await _client.GetAsync($"/v2/beers?beer_name={name}&per_page=5");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            ///convert to json
            var result = JsonConvert.DeserializeObject<IEnumerable<BeerInfo>>(content);
            return result;
        }
        public async Task<IEnumerable<BeerInfo>> BeerByAbv(string Abv)
        {
            double abvLess= Convert.ToDouble(Abv)-1;
            double abvGreat = Convert.ToDouble(Abv) + 1;
            var response = await _client.GetAsync($"/v2/beers?abv_gt={abvLess}&abv_lt={abvGreat}&per_page=5");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            ///convert to json
            var result = JsonConvert.DeserializeObject<IEnumerable<BeerInfo>>(content);
            return result;
        }
        public async Task<IEnumerable<BeerInfo>> BeerByIbu(string Ibu)
        {
            double ibuLess = Convert.ToDouble(Ibu) - 5;
            double ibuGreat = Convert.ToDouble(Ibu) + 5;
            var response = await _client.GetAsync($"/v2/beers?ibu_gt={ibuLess}&ibu_lt={ibuGreat}&per_page=5");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            ///convert to json
            var result = JsonConvert.DeserializeObject<IEnumerable<BeerInfo>>(content);
            return result;
        }

        public async Task<IEnumerable<BeerInfo>> BeerByRandom()
        {
            
            var response = await _client.GetAsync($"/v2/beers/random");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            ///convert to json
            var result = JsonConvert.DeserializeObject<IEnumerable<BeerInfo>>(content);
            return result;
        }
        public async Task<IEnumerable<BeerInfo>> BeerByEbc(string Ebc)
        {
            double ebcLess = Convert.ToDouble(Ebc) - 5;
            double ebcGreat = Convert.ToDouble(Ebc) + 5;
            var response = await _client.GetAsync($"/v2/beers?ebc_gt={ebcLess}&ebc_lt={ebcGreat}&per_page=5");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            ///convert to json
            var result = JsonConvert.DeserializeObject<IEnumerable<BeerInfo>>(content);
            return result;
        }
       
    }
}
