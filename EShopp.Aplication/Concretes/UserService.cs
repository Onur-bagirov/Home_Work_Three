using EShopp.Aplication.Abstacts;
using EShopp.DAL.Context;
using EShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace EShopp.Aplication.Concretes
{
    public class UserService : IUserService
    {
        private readonly EShoppDbContext _context;
        public UserService(EShoppDbContext context)
        {
            _context = context;
        }
        public async Task RegisterAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> LoginAsync(string username, string userpassword)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username && u.UserPassword == userpassword);
        }   
        public async Task <List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }   
    }
}
