using System;

namespace Blog.ViewModels.Commet.Get
{
	public class GetCommentView
	{
		public string Id { get; set; }
		public DateTime CreationDate { get; set; }
		public string PostId { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
	}
}
