using System.Threading.Tasks;

namespace v1.Models.Contracts
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResult> AuthenticateAsync(MyLoggedUser user);
    }
}