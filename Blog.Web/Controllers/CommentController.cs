using Blog.Services.Interface;
using Blog.ViewModels.Commet.Create;
using Blog.ViewModels.Commet.Update;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Web.Controllers
{
	public class CommentController : Controller
	{
		private readonly ICommentService _service;

		public CommentController(ICommentService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult> Index(string id)
		{
			var model = await _service.GetAll(id);
			return View(model);
		}

		[HttpGet]
		public async Task<ActionResult> GetAll(string id)
		{
			var model = await _service.GetAll(id);
			return Ok(model);
		}

		[HttpPost]
		public async Task<ActionResult> Create(CreateCommentView model)
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
		public async Task<ActionResult> Update(UpdateCommentView model)
		{
			var newPost = await _service.Update(model);
			return LocalRedirect($"~/Comment/Index/{model.PostId}");
		}

		[HttpGet]
		public async Task<ActionResult> Delete(string id)
		{
			var response = await _service.Delete(id);
			return Ok(response);
		}
	}
}