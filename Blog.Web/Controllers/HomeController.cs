using Blog.Services.Interface;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IHomeService _service;

		public HomeController(IHomeService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var model = await _service.GetAllPosts();
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Get(string id)
		{
			var model = await _service.Get(id);
			return View(model);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
