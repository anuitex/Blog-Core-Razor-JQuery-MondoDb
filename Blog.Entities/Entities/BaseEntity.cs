using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Blog.Entities.Entities
{
	public class BaseEntity
	{
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public DateTime CreationDate { get; set; }

		public BaseEntity()
		{
			CreationDate = DateTime.UtcNow;
		}
	}
}
