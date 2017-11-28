using MongoDB.Bson.Serialization.Attributes;

namespace api.Features.Task
{
	public class TaskModel
	{
		[BsonId]
		public string Id;
		public string UserId;
		public string Name;
		public string Description;
	}
}
