namespace api.Features.Shared.Response
{
	public static class Messages
	{
		public static string NewUser200 { get => "User is registred"; }
		public static string ErrEmail409 { get => "This email address is already registered"; }
		public static string Err500 { get => "Contact admin"; }
	}
}
