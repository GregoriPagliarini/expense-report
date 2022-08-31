using Auth.Model;

namespace Auth.Services
{
    public interface IUserService
    {
        User Create(User user);
        User Update(User user);
        User FindById(long id);
        User SwitchUserState(long id);
        User Delete(long id);
        List<User> FindAll();
    }
}
