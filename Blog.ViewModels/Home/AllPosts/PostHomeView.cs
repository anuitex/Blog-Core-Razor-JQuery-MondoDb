using System;
using System.Collections.Generic;
using Blog.ViewModels.Home.AllComments;

namespace Blog.ViewModels.Home.AllPosts
{
	public class PostHomeView
	{
		public string Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string Tag { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public List<CommentHomeView> Comment { get; set; }

	    public PostHomeView()
	    {
	        Comment = new List<CommentHomeView>();
	    }
	}
}
