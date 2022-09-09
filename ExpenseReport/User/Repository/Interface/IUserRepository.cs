using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using User.Data.ValueObjects;

namespace User.Repository.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModelValueObject>> FindAll();
        Task<UserModelValueObject> FindById(int userId);
        Task<UserModelValueObject> FindByName(string name);
        Task<UserModelValueObject> Create(UserModelValueObject user);
        Task<UserModelValueObject> Update(UserModelValueObject user);
        Task<bool> Delete(int userId);
        Task<bool> ValidateCredentials(AuthValueObject authVO);
    }
}
