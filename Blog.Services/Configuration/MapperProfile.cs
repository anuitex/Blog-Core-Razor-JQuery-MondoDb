using Blog.Entities.Entities;
using Blog.ViewModels.Commet.Create;
using Blog.ViewModels.Commet.Get;
using Blog.ViewModels.Commet.Update;
using Blog.ViewModels.Home.AllComments;
using Blog.ViewModels.Home.AllPosts;
using Blog.ViewModels.Post;
using Blog.ViewModels.Post.Update;

namespace Blog.Services.Configuration
{
	public class MapperProfile : AutoMapper.Profile
	{
		public MapperProfile()
		{
			// Post
			CreateMap<Post, GetPostView>().ReverseMap();
			CreateMap<CreatePostView, Post>().ReverseMap();
			CreateMap<UpdatePostView, Post>().ReverseMap();

			// Comment
			CreateMap<Comment, GetCommentView>().ReverseMap();
			CreateMap<CreateCommentView, Comment>().ReverseMap();
			CreateMap<UpdateCommentView, Comment>().ReverseMap();
            
			// Home Post/Comment
			CreateMap<Post, PostHomeView>().ReverseMap();
			CreateMap<Comment, CommentHomeView>().ReverseMap();

		}
	}
}
