using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Villa_Web.Models;
using Villa_Web.Models.DTOs.VillaDTOs;
using Villa_Web.Models.DTOs.VillaNumberDTOs;
using Villa_Web.Models.VM;
using Villa_Web.Services.IServices;

namespace Villa_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _VillaNumberService;
        private readonly IVillaService _VillaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService service, IMapper mapper, IVillaService VillaService)
        {
            _VillaNumberService = service;
            _mapper = mapper;
            _VillaService = VillaService;
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> list = new();
            var response = await _VillaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));

            }
            return View(list);
        }


        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberCreateVM = new();
            var response = await _VillaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                villaNumberCreateVM.VillaList =
                    JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

            }

            return View(villaNumberCreateVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var resp = await _VillaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (resp != null && resp.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (resp != null && resp.ErrorMessages != null && resp.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", resp.ErrorMessages.FirstOrDefault());
                    }
                }

            }

            var response = await _VillaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

            }
            return View(model);


        }

        public async Task<IActionResult> UpdateVillaNumber(int villaNo)
        {
            var VillaNumUpdateVM = new VillaNumberUpdateVM();
            var response = await _VillaNumberService.GetAsync<APIResponse>(villaNo);
            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                VillaNumUpdateVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(model);

            }
            var resp = await _VillaService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                VillaNumUpdateVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(resp.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

                return View(VillaNumUpdateVM);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var resp = await _VillaNumberService.UpdateAsync<APIResponse>(model.VillaNumber);
                if (resp != null && resp.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
                else
                {
                    if (resp != null && resp.ErrorMessages != null && resp.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", resp.ErrorMessages.FirstOrDefault());
                    }
                }

            }

            var response = await _VillaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

            }
            return View(model);

        }

        public async Task<IActionResult> DeleteVillaNumber(int villaNo)
        {
            VillaNumberDeleteVM VillaNumberVM = new();
            var response = await _VillaNumberService.GetAsync<APIResponse>(villaNo);
            if (response != null && response.IsSuccess)
            {
                var model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                VillaNumberVM.VillaNumber = _mapper.Map<VillaNumberDTO>(model);

            }
            var resp = await _VillaService.GetAllAsync<APIResponse>();
            if (resp != null && resp.IsSuccess)
            {
                VillaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(resp.Result))
                    .Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });

                return View(VillaNumberVM);
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM model)
        {


            var response = await _VillaNumberService.DeleteAsync<APIResponse>(model.VillaNumber.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }


            return View(model);


        }
    }
}
