using Domain.Entities;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var users = await _context.Users
                                      .Where(x => x.Email.ToLower().Equals(email.ToLower()))
                                      .AsNoTracking()
                                      .ToListAsync();
            return users.FirstOrDefault();
        }

        public async Task<User> GetByName(string name)
        {
            var users = await _context.Users
                                      .Where(x => x.Name.ToLower().Equals(name.ToLower()))
                                      .AsNoTracking()
                                      .ToListAsync();
            return users.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var usersList = await _context.Users
                                          .Where(x => x.Email.ToLower().Contains(email.ToLower()))
                                          .AsNoTracking()
                                          .ToListAsync();
            return usersList;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var usersList = await _context.Users
                                          .Where(x => x.Name.ToLower().Contains(name.ToLower()))
                                          .AsNoTracking()
                                          .ToListAsync();
            return usersList;
        }
    }
}
