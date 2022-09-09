//using Auth.Data.ValueObjects;
using Auth.Data.ValueObjects;
using Auth.Model;
using Auth.Model.Context;
using Auth.Repository.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(MySQLContext mySQLContext, IMapper mapper)
        {
            _context = mySQLContext;
            _mapper = mapper;
        }

        public Task<AuthValueObject> FindById(AuthValueObject authValueObject)
        {
            throw new NotImplementedException();
        }
    }
}
