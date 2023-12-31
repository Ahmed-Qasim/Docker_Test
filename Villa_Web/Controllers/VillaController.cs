using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Villa_Web.Models;
using Villa_Web.Models.DTOs.VillaDTOs;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _VillaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService service, IMapper mapper)
        {
            _VillaService = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new List<VillaDTO>();
            var response = await _VillaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
        public async Task<IActionResult> CreateVilla()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _VillaService.CreateAsync<APIResponse>(dto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa was created Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }

            }
            return View(dto);


        }

        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var response = await _VillaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(model));
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _VillaService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa was Updated Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }

            }
            return View(model);


        }

        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _VillaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO model)
        {


            var response = await _VillaService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa was Deleted Successfully";
                return RedirectToAction(nameof(IndexVilla));
            }


            return View(model);


        }
    }
}
