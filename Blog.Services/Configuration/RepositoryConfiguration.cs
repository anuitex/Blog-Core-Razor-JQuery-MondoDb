using Blog.DataAccess.Repository.Interfaces;
using Blog.DataAccess.Repository.Mongo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Services.Configuration
{
    public static class RepositoryConfiguration
    {
        public static void MongoRepository(this IServiceCollection services, IConfiguration сonfiguration)
        {
            services.AddTransient<IPostRepository, PostMongoRepository>();
            services.AddTransient<ICommentRepository, CommentMongoRepository>();
        }
    }
}
