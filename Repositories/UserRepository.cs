using TodoApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Repositories;

namespace TodoApiAPI.Repositories
{
    public class UserRepository : IUserRepository
    {

        public readonly UserContext _context;


        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task Delete(long Id)
        {
            var userToDelete = await _context.Users.FindAsync(Id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Get(long Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}