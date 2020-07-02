using System.Threading.Tasks;
using v1.Models;

namespace v1.Models.Contracts
{
    public interface IAuthorizationService
    {
         Task<BaseResult<IUser>> AuthorizeAsync(LoginUser loginUser);
    }
}