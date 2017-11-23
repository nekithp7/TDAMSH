namespace api.Features.Shared.Hash
{
	public interface IHashService
	{
		string CreateHash(string password);

		bool VerifyPassword(string password, string goodHash);
	}
}
