using Blog.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.Interfaces
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
		Task<List<Comment>> GetAllByPostId(string postId);
	}
}
