using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ViewModels.Post
{
	public class GetPostView
	{
		public string Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Tag { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		//public List<CommentAdminView> Comment { get; set; }
	}
}
