using System.Threading.Tasks;
using CreateTemplate.Business.Models;
using CreateTemplate.Core;
using Optional;

namespace CreateTemplate.Business.Services.Interfaces
{
    public interface IUsersService
    {
        Task<Option<JwtModel, Error>> Login(LoginUserModel model);

        Task<Option<UserModel, Error>> Register(RegisterUserModel model);
    }
}
