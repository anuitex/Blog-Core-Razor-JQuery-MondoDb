using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blog.DataAccess.Domain
{
    public class MongoContext<TEntity> where TEntity : class
    {
        private readonly IMongoDatabase _database;
        private readonly string _tableName = $"{typeof(TEntity).Name}s";

        public MongoContext(IOptions<ConnectionConfig> connectionConfig)
        {
            var client = new MongoClient(connectionConfig.Value.ConnectionString);
            _database = client.GetDatabase(connectionConfig.Value.Database);
        }

        public IMongoCollection<TEntity> Table => _database.GetCollection<TEntity>(_tableName);

    }
}
