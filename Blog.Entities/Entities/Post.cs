using System.Collections.Generic;

namespace Blog.Entities.Entities
{
	public class Post : BaseEntity
	{
		public string Tag { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public List<Comment> Comment { get; set; }
	}
}
