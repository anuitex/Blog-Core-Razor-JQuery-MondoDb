using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.DataAccess.Repository.Interfaces
{
	public interface IBaseRepository<TEntity> where TEntity : class
	{
		Task<List<TEntity>> GetAll();

		Task Remove(string id);

		Task<TEntity> Get(string id);

		Task Add(TEntity item);

		Task AddRange(List<TEntity> entity);

		Task Update(TEntity entity);

	}
}
