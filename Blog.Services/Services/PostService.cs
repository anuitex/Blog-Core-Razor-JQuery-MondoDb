using AutoMapper;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Blog.Services.Interface;
using Blog.ViewModels.Post;
using Blog.ViewModels.Post.Get;
using Blog.ViewModels.Post.Update;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Services
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _postRepository;
		private readonly IMapper _mapper;

		public PostService(IPostRepository postRepository, IMapper mapper)
		{
			_postRepository = postRepository;
			_mapper = mapper;
		}

		public async Task<GetAllPostViewItem> GetAll()
		{
			List<Post> listPosts = await _postRepository.GetAll();
			var listViews = _mapper.Map<List<GetPostView>>(listPosts);

			var model = new GetAllPostViewItem();
			model.Posts = listViews;

			return model;
		}

		public async Task<object> Delete(string id)
		{
			await _postRepository.Remove(id);
			return new { response = $"Post: {id} - Removed" };
		}

		public async Task<GetPostView> Get(string id)
		{
			Post post = await _postRepository.Get(id);
			var model = _mapper.Map<GetPostView>(post);
			return model;
		}

		public async Task<object> Create(CreatePostView model)
		{
			Post post = _mapper.Map<Post>(model);
			await _postRepository.Add(post);
			return new { response = $"Post {post.Id} Added" };
		}

		public async Task<object> Update(UpdatePostView model)
		{
			Post post = _mapper.Map<Post>(model);

			await _postRepository.Update(post);
			return new { response = $"Post {post.Id} Updated" };
		}
	}
}
