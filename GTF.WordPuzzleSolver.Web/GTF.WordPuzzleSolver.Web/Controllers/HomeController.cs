using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GTF.WordPuzzleSolver.Web.Models;
using GTF.WordPuzzleSover.Application.Services;

namespace GTF.WordPuzzleSolver.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly WordMatrixService _service;
        public HomeController()
        {
            _service = new WordMatrixService();
        }

        public IActionResult Index()
        {
            _service.Initialize();
            var matrix = _service.Draw();
            var viewModel = new WordMatrixModel()
            {
                Matrix = matrix.Matrix,
                Words = matrix.Words
            };

            return View(viewModel);
        }

        [Route("GetWord")]
        [HttpPost]
        public IActionResult GetWord([FromBody]string word)
        {
            var breakdown = _service.SearchWord(word);
            var response = new
            {
                Word = word,
                Breakdown = breakdown
            };

            return Json(response);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
