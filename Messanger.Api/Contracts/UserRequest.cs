namespace Messanger.Api.Contracts
{
    public record UsersRequest(
       int Id,
       string Username,
       string Email,
       string Password
   );
}
