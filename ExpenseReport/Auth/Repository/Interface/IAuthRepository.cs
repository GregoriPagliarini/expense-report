using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Auth.Data.ValueObjects;
//using Auth.Data.ValueObjects;

namespace Auth.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<AuthValueObject> FindById(AuthValueObject authValueObject);
    }
}
