using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.DTOs.VillaDTOs;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class VillaService : BaseService, IVillaService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaApiUrl;
        public VillaService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            villaApiUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
            _httpClientFactory = httpClientFactory;
        }
        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(
                new APIRequest()
                {
                    ApiType = SD.ApiType.POST,
                    Data = dto,
                    Url = villaApiUrl + "/api/VillaApi"
                });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.DELETE,
                  Url = villaApiUrl + "/api/VillaApi/" + id
              });

        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.GET,
                  Url = villaApiUrl + "/api/VillaApi/"
              });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.GET,
                  Url = villaApiUrl + "/api/VillaApi/" + id
              });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {

            return SendAsync<T>(
                new APIRequest()
                {
                    ApiType = SD.ApiType.PUT,
                    Data = dto,
                    Url = villaApiUrl + "/api/VillaApi" + dto.Id
                });
        }
    }
}
