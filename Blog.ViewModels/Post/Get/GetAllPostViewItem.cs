using System.Collections.Generic;

namespace Blog.ViewModels.Post.Get
{
	public class GetAllPostViewItem
	{
		public List<GetPostView> Posts { get; set; }

		public GetAllPostViewItem()
		{
			Posts = new List<GetPostView>();
		}
	}
}
