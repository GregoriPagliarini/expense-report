using User.Data.ValueObjects;
using User.Model;
using User.Model.Context;
using User.Repository.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace User.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public UserRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _context = mySQLContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserModelValueObject>> FindAll()
        {
            List<UserModel> users = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserModelValueObject>>(users);
        }

        public async Task<UserModelValueObject> FindById(int idUser)
        {
            UserModel user = await _context.Users.Where(user => user.IdUser == idUser).FirstOrDefaultAsync();
            return _mapper.Map<UserModelValueObject>(user);
        }

        public async Task<UserModelValueObject> FindByName(string name)
        {
            UserModel user = await _context.Users.Where(user => user.Name == name).FirstOrDefaultAsync();
            return _mapper.Map<UserModelValueObject>(user);
        }

        public async Task<UserModelValueObject> Create(UserModelValueObject userVO)
        {
            try
            {
                UserModel user = _mapper.Map<UserModel>(userVO);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<UserModelValueObject>(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModelValueObject> Update(UserModelValueObject userVO)
        {
            UserModel user = _mapper.Map<UserModel>(userVO);
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserModelValueObject>(user);
        }

        public async Task<bool> Delete(int idUser)
        {
            try
            {
                UserModel user = await _context.Users.Where(user => user.IdUser == idUser).FirstOrDefaultAsync();
                if(user is null) return false;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }
        }

        public async Task<bool> ValidateCredentials(AuthValueObject authVO)
        {
            return await _context.Users.Where(user => user.Name.Equals(authVO.Name) & user.Password == authVO.Password).FirstOrDefaultAsync() != null;
        }
    }
}
