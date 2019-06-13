using System.Collections.Generic;

namespace Blog.ViewModels.Home.AllPosts
{
	public class AllPostHomeViewItem
	{
		public List<PostHomeView> Posts { get; set; }

		public AllPostHomeViewItem()
		{
			Posts = new List<PostHomeView>();
		}
	}
}
