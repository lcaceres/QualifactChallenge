using Newtonsoft.Json;
using QualifactChallenge.ApplicationLayer.DTO;
using QualifactChallenge.ApplicationLayer.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Configuration;


namespace QualifactChallenge.ApplicationLayer.Services
{
    public class DivisivilityService: IDivisivilityService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public DivisivilityService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<List<DTODivisivility>> GetResultsAsync(int input1, int input2, int size)
        {
            var httpClient = _httpClientFactory.CreateClient();

            string? url = _configuration.GetSection("ApiSettings").GetSection("BaseUrl").Value;

            HttpResponseMessage response = await httpClient.GetAsync($"{url}Number?input1={input1}&input2={input2}&size={size}");

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                List<DTODivisivility> results = JsonConvert.DeserializeObject<List<DTODivisivility>>(responseContent);
                return results;
            }

            return null;
        }
    }
}
