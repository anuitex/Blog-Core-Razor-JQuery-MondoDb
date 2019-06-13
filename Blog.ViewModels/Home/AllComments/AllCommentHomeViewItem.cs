using System.Collections.Generic;

namespace Blog.ViewModels.Home.AllComments
{
	public class AllCommentHomeViewItem
	{
		public List<CommentHomeView> Comments { get; set; }

		public AllCommentHomeViewItem()
		{
			Comments = new List<CommentHomeView>();
		}
	}
}
