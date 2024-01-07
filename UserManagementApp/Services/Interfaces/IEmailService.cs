namespace UserManagementApp.Services.Interfaces
{
	public interface IEmailService
	{
		Task<string> SendEmailAsync(string recipentEmail, string body, string subject);
	}
}
