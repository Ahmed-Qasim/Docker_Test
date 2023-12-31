using Villa_Utility;
using Villa_Web.Models;
using Villa_Web.Models.DTOs.VillaNumberDTOs;
using Villa_Web.Services.IServices;

namespace Villa_Web.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string villaApiUrl;
        public VillaNumberService(IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(httpClientFactory)
        {
            villaApiUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
            _httpClientFactory = httpClientFactory;
        }
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return SendAsync<T>(
                new APIRequest()
                {
                    ApiType = SD.ApiType.POST,
                    Data = dto,
                    Url = villaApiUrl + "/api/VillaNumberApi"
                });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.DELETE,
                  Url = villaApiUrl + "/api/VillaNumberApi/" + id
              });

        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.GET,
                  Url = villaApiUrl + "/api/VillaNumberApi/"
              });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(
              new APIRequest()
              {
                  ApiType = SD.ApiType.GET,
                  Url = villaApiUrl + "/api/VillaNumberApi/" + id
              });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto)
        {

            return SendAsync<T>(
                new APIRequest()
                {
                    ApiType = SD.ApiType.PUT,
                    Data = dto,
                    Url = villaApiUrl + "/api/VillaNumberApi/" + dto.VillaNo
                });
        }
    }
}
