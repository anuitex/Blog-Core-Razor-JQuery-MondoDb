using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.DataAccess.Domain;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blog.DataAccess.Repository.Mongo
{
    public class BaseMongoRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly IMongoCollection<TEntity> _context;

        public BaseMongoRepository(IOptions<ConnectionConfig> connectionConfig)
        {
            _context = new MongoContext<TEntity>(connectionConfig).Table;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var result = await _context.AsQueryable().ToListAsync();
            return result;
        }

        public async Task Add(TEntity entity)
        {
            await _context.InsertOneAsync(entity);
        }

        public async Task<TEntity> Get(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", id);
            return await _context
                            .Find(filter)
                            .FirstOrDefaultAsync();
        }

        public async Task Remove(string id)
        {
            await _context.DeleteOneAsync(
                 Builders<TEntity>.Filter.Eq("Id", id));
        }

        public async Task Update(TEntity entity)
        {
            await _context.ReplaceOneAsync(n => n.Id.Equals(entity.Id), entity, new UpdateOptions { IsUpsert = true });
        }

        public async Task AddRange(List<TEntity> entity)
        {
            await _context.InsertManyAsync(entity);
        }

    }
}
