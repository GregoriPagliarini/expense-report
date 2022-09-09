using User.Data.ValueObjects;
using User.Model;
using User.Repository.Interface;

namespace User.Services.Implementations
{
    public class UserServiceImplamentation : IUserService 
    {
        private readonly IUserRepository _IUserRepository;

        public UserServiceImplamentation(IUserRepository toDoItemRepository)
        {
            _IUserRepository = toDoItemRepository;
        }

        public async Task<UserModelValueObject> Create(UserModelValueObject user)
        {
            await ValidateUserInfo(user);
            await _IUserRepository.Create(user);
            return user;
        }

        private async Task ValidateUserInfo(UserModelValueObject user)
        {
            
        }

        public async Task<UserModelValueObject> Update(UserModelValueObject user)
        {
            await ValidateUserInfo(user);
            await _IUserRepository.Update(user);
            return user;
        }

        public async Task<bool> Delete(int id) => await _IUserRepository.Delete(id);

        public async Task<UserModelValueObject> FindById(int id) => await _IUserRepository.FindById(id);

        public async Task<bool> ValidateCredentials(AuthValueObject authVO) => await _IUserRepository.ValidateCredentials(authVO);
    }
}
