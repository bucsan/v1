using v1.Models.Contracts;
using v1.Models;
using System.Threading.Tasks;
using System;

namespace v1.Services
{
    public sealed class FakeAuthorizationService : IAuthorizationService
{
    public async Task<BaseResult<IUser>> AuthorizeAsync(
        LoginUser loginUser)
    {
        var loginOrEmail = loginUser?.LoginOrEmail ?? "";
        var password = loginUser?.Password ?? "";
 
        var result = new BaseResult<IUser>();
 
        if (loginOrEmail == "fsl" && password == "1234")
        {
            result.Success = true;
            result.Message = "User authorized!";
            result.Data = new MyLoggedUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Nome test",
                Credentials = "01|02|09",
                IsAdmin = false
            };
        }
        else
        {
            result.Success = false;
            result.Message = "Not authorized!";
        }
 
        return await Task.FromResult(result);
    }
}
}