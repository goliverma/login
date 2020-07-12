using System.Threading.Tasks;
using models;

namespace test.Models.Interface
{
    public interface IRegisterRepository
    {
        Task<Register> AddRegister(Register register);
        Task<bool> UserLogin(Register login);
    }
}