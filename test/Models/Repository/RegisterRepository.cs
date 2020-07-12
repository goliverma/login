using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using models;
using test.Models.Interface;

namespace test.Models.Repository
{
    public class RegisterRepository : IRegisterRepository
    {
        private readonly AppDbContext context;

        public RegisterRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Register> AddRegister(Register register)
        {
            var result = await context.Registers.AddAsync(register);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UserLogin(Register login)
        {
            bool istrue = false;
            if(login != null)
            {
                var result = await context.Registers.Where(l => 
                l.UserName == login.UserName && l.Password == login.Password)
                .FirstOrDefaultAsync();
                if(result != null)
                {
                    istrue = true;
                }
            }
            return istrue;
        }
    }
}