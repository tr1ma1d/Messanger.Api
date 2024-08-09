namespace Messanger.Api.Contracts
{
    public record UsersResponse(
        int Id,
        string Username,
        string Email,
        string Password
    );
    
}
