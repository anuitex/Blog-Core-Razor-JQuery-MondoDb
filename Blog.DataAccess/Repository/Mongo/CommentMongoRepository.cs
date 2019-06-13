using Blog.DataAccess.Domain;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.Mongo
{
	public class CommentMongoRepository : BaseMongoRepository<Comment>, ICommentRepository
	{
		public CommentMongoRepository(IOptions<ConnectionConfig> connectionConfig)
			: base(connectionConfig)
		{ }

		public async Task<List<Comment>> GetAllByPostId(string postId)
		{
			var filter = Builders<Comment>.Filter.Eq("PostId", postId);
			var dbResult = await _context.FindAsync<Comment>(filter);
			var result = await dbResult.ToListAsync();

			return result;
		}
	}
}
