using Blog.Services.Interface;
using Blog.ViewModels.Post;
using Blog.ViewModels.Post.Update;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService _service;

		public PostController(IPostService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult> Index()
		{
			var model = await _service.GetAll();
			return View(model);
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var model = await _service.GetAll();
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreatePostView model)
		{
			var newPost = await _service.Create(model);
			return LocalRedirect("~/Post");
		}

		[HttpGet]
		public async Task<ActionResult> Read(string id)
		{
			var model = await _service.Get(id);
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Update(UpdatePostView model)
		{
			var newPost = await _service.Update(model);
			return LocalRedirect("~/Post");
		}

		[HttpGet]
		public async Task<ActionResult> Delete(string id)
		{
			var response = await _service.Delete(id);
			return Ok(response);
		}
	}
}