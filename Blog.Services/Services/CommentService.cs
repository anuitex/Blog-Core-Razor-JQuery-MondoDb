using AutoMapper;
using Blog.DataAccess.Repository.Interfaces;
using Blog.Entities.Entities;
using Blog.Services.Interface;
using Blog.ViewModels.Commet.Create;
using Blog.ViewModels.Commet.Get;
using Blog.ViewModels.Commet.Update;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Services.Services
{
	public class CommentService : ICommentService
	{
		private readonly ICommentRepository _commentRepository;
		private readonly IMapper _mapper;

		public CommentService(ICommentRepository commentRepository, IMapper mapper)
		{
			_commentRepository = commentRepository;
			_mapper = mapper;
		}

		public async Task<GetAllCommentViewItem> GetAll(string postId)
		{
			List<Comment> listComments = await _commentRepository.GetAllByPostId(postId);
			var listViews = _mapper.Map<List<GetCommentView>>(listComments);

			var model = new GetAllCommentViewItem();
			model.Comments = listViews;
			return model;
		}

		public async Task<object> Delete(string id)
		{
			await _commentRepository.Remove(id);
			return new { response = $"Comment: {id} - Removed" };
		}

		public async Task<GetCommentView> Get(string id)
		{
			Comment comment = await _commentRepository.Get(id);
			var model = _mapper.Map<GetCommentView>(comment);
			return model;
		}

		public async Task<object> Create(CreateCommentView model)
		{
			Comment comment = _mapper.Map<Comment>(model);
			await _commentRepository.Add(comment);
			return new { response = $"Comment {comment.Id} Added" };
		}

		public async Task<string> Update(UpdateCommentView model)
		{
			Comment comment = _mapper.Map<Comment>(model);
			await _commentRepository.Update(comment);
			return comment.PostId;
		}
	}

}
