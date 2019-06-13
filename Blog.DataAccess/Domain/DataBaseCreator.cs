using Blog.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Blog.DataAccess.Domain
{
    public class DataBaseCreator
    {
        private readonly IMongoDatabase _context;

        public DataBaseCreator(IOptions<ConnectionConfig> connectionConfig)
        {
            var client = new MongoClient(connectionConfig.Value.ConnectionString);
            _context = client.GetDatabase(connectionConfig.Value.Database);
        }

        protected async Task Creator()
        {
            await CreateTable<Post>();
            await CreateTable<Comment>();
            await CreateTable<MySelfInfo>();
        }

        private async Task<bool> IsCollectionExist(string name)
        {
            var filter = new BsonDocument("name", name);
            var collections = await _context.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });
            return await collections.AnyAsync();
        }

        private async Task CreateTable<TEntity>()
        {
            var name = $"{typeof(TEntity).Name}s";
            var a = await IsCollectionExist(name);
            if (a == false)
            {
                await _context.CreateCollectionAsync(name);
            }
        }
    }
}
