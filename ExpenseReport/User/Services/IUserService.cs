using User.Data.ValueObjects;
using User.Model;

namespace User.Services
{
    public interface IUserService
    {
        Task<UserModelValueObject> Create(UserModelValueObject user);
        Task<UserModelValueObject> Update(UserModelValueObject user);
        Task<UserModelValueObject> FindById(int id);
        Task<bool> Delete(int id);
        Task<bool> ValidateCredentials(AuthValueObject authVO);
    }
}
