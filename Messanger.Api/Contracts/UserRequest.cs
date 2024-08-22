namespace Messanger.Api.Contracts
{
    public record UsersRequest(
       string Username,
       string Password,
       string Email
      
   );
}
