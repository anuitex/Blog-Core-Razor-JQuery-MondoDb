using Blog.ViewModels.Commet.Create;
using Blog.ViewModels.Commet.Get;
using Blog.ViewModels.Commet.Update;
using System.Threading.Tasks;

namespace Blog.Services.Interface
{
	public interface ICommentService
	{
		Task<GetAllCommentViewItem> GetAll(string postId);
		Task<GetCommentView> Get(string id);
		Task<object> Create(CreateCommentView model);
		Task<string> Update(UpdateCommentView model);
		Task<object> Delete(string id);
	}
}
