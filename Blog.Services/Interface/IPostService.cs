using Blog.ViewModels.Post;
using Blog.ViewModels.Post.Get;
using Blog.ViewModels.Post.Update;
using System.Threading.Tasks;

namespace Blog.Services.Interface
{
	public interface IPostService
	{
		Task<GetAllPostViewItem> GetAll();
		Task<object> Create(CreatePostView model);
		Task<GetPostView> Get(string id);
		Task<object> Update(UpdatePostView model);
		Task<object> Delete(string id);
	}
}
