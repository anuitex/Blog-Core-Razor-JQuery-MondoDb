using Blog.ViewModels.Home.AllPosts;
using System.Threading.Tasks;

namespace Blog.Services.Interface
{
	public interface IHomeService
	{
		Task<AllPostHomeViewItem> GetAllPosts();
		Task<PostHomeView> Get(string id);
	}
}
