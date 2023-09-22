using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QualifactChallenge.ApplicationLayer.DTO;
using QualifactChallenge.ApplicationLayer.Services.Interfaces;
using QualifactChallenge.PresentationLayer.Models;
using X.PagedList;

namespace QualifactChallenge.PresentationLayer.Controllers
{
    public class NumberController : Controller
    {

        private readonly IDivisivilityService _divisivilityService;

        public NumberController(IDivisivilityService divisivilityService)
        {
            _divisivilityService = divisivilityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(NumberModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            var results = await _divisivilityService.GetResultsAsync(model.Input1, model.Input2, model.SampleSize);
            TempData["Divisions"] = JsonConvert.SerializeObject(results);

            int? page = 1; 
            return RedirectToAction("Calculate", new { page });
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(int? page)
        {
            var resultJSON = TempData["Divisions"] as string;
            var results = JsonConvert.DeserializeObject<List<DTODivisivility>>(resultJSON);
            int pageSize = 10;
            int pageNumber = page ?? 1;

            IPagedList<QualifactChallenge.ApplicationLayer.DTO.DTODivisivility> pagedResults = results.ToPagedList(pageNumber, pageSize);
            TempData.Keep("Divisions");
            return View(pagedResults);
        }



    }
}
