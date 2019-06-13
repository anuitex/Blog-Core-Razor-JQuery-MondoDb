using System.Collections.Generic;

namespace Blog.ViewModels.Commet.Get
{
	public class GetAllCommentViewItem
	{
		public List<GetCommentView> Comments { get; set; }

		public GetAllCommentViewItem()
		{
			Comments = new List<GetCommentView>();
		}
	}
}
