using AutoMapper;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Blog.Services.Interface;
using Blog.ViewModels.Home.AllPosts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Services
{
	public class HomeService : IHomeService
	{
		private readonly IPostRepository _postRepository;
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public HomeService(IPostRepository postRepository, ICommentRepository commentRepository, IMapper mapper)
		{
			_postRepository = postRepository;
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public async Task<AllPostHomeViewItem> GetAllPosts()
		{
			List<Post> listPosts = await _postRepository.GetAll();
			var listPostsView = _mapper.Map<List<PostHomeView>>(listPosts);

			var model = new AllPostHomeViewItem();
			model.Posts = listPostsView;
			return model;
		}

		public async Task<PostHomeView> Get(string id)
		{
			List<Comment> comments = await _commentRepository.GetAllByPostId(id);
			Post post = await _postRepository.Get(id);
			post.Comment = comments;
			var model = _mapper.Map<PostHomeView>(post);
			return model;
		}
	}
}
