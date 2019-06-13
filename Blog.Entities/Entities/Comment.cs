namespace Blog.Entities.Entities
{
	public class Comment : BaseEntity
	{
		public string PostId { get; set; }
		public string Name { get; set; }
		public string Text { get; set; }
	}
}
