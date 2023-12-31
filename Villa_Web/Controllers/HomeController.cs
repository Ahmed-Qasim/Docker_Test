using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Villa_Web.Models;
using Villa_Web.Models.DTOs.VillaDTOs;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _VillaService;
        private readonly IMapper _mapper;
        public HomeController(IVillaService service, IMapper mapper)
        {
            _VillaService = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<VillaDTO> list = new List<VillaDTO>();
            var response = await _VillaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }

    }
}
