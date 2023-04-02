namespace SofthouseDev.Api.Models.Request
{
    public record RegisterClient(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string Phone);
}