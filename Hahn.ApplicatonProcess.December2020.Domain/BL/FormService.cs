using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    /// <summary>
    /// Handle bussiness requirements
    /// Created by DVQUAN 
    /// </summary>
    public class FormService
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly ILogger<FormService> _logger;

        public FormService()
        {

        }

        public FormService(ILogger<FormService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ValidateCountry(string country)
        {
            return await ProcessRequest(country);
        }

        private async Task<bool> ProcessRequest(string country)
        {
            var url = "https://restcountries.eu/rest/v2/name/";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = client.GetStreamAsync($"{url}{country}");
            try
            {
                var lstCountries = await JsonSerializer.DeserializeAsync<List<object>>(await streamTask);
                if (lstCountries.Count > 0)
                {
                    return true;
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Failed to send request.\n" + ex.ToString());
                return false;
            }
            
            return false;
        }
    }
}
