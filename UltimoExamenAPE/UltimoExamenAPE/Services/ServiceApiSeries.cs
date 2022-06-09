using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UltimoExamenAPE.Models;

namespace UltimoExamenAPE.Services
{
    public class ServiceApiSeries
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceApiSeries
            (IConfiguration configuration)
        {
            this.UrlApi = configuration["UrlApis:ApiSeries"];
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Uri uri = new Uri(this.UrlApi + request);
                HttpResponseMessage response =
                    await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Personaje>> GetPersonajes(int IdSerie)
        {
            string request = "/api/Series/PersonajesSerie/" + IdSerie;
            List<Personaje> personajes = await this.CallApiAsync<List<Personaje>>(request);

            return personajes;
        }

        public async Task<List<Serie>> GetSeries()
        {
            string request = "/api/Series";
            List<Serie> series = await this.CallApiAsync<List<Serie>>(request);

            return series;
        }
        public async Task<Serie> FindSerie(string IdSerie)
        {
            string request = "/api/Series/" + IdSerie;
            Serie series = await this.CallApiAsync<Serie>(request);

            return series;
        }
    }
}
