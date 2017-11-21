namespace api.Features.Shared.Response
{
	public class ResponseModel
	{		
		public ResponseModel(int statusCode, object msg)
		{
			StatusCode = statusCode;
			Message = msg;
		}

		public int StatusCode { get; }
		public object Message { get; }
	}
}
