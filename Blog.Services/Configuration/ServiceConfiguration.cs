using Blog.Entities.Enums;
using Blog.Services.Interface;
using Blog.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Services.Configuration
{
	public static class Configuration
	{
		public static void Service(this IServiceCollection services, IConfiguration сonfiguration)
		{
			string orm = сonfiguration.GetSection("Orm").Value;
			if (orm == OrmType.Mongo.ToString())
			{
				services.MongoRepository(сonfiguration);
			}

			var config = new AutoMapper.MapperConfiguration(c =>
			{
				c.AddProfile(new MapperProfile());
			});
			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);

			ServiceSettings(services, сonfiguration);
		}

		private static void ServiceSettings(this IServiceCollection services, IConfiguration сonfiguration)
		{
			services.AddScoped<IPostService, PostService>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<IHomeService, HomeService>();
		}
	}
}
