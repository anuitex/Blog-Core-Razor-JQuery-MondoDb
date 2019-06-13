using Blog.DataAccess.Domain;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Microsoft.Extensions.Options;

namespace Blog.DataAccess.Repository.Mongo
{
	public class PostMongoRepository : BaseMongoRepository<Post>, IPostRepository
	{
		public PostMongoRepository(IOptions<ConnectionConfig> connectionConfig)
			: base(connectionConfig)
		{ }
	}
}
