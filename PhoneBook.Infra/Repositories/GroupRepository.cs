using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PhoneBookDbContext _context;

        public GroupRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<Group> Add(Group entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Group entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id, string userId)
        {
            var entity = await Get(id, userId);
            return entity != null;
        }

        public async Task<Group> Get(int id, string userId)
        {
            return await _context.Groups.SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);
        }

        public async Task<List<Group>> GetAll(string userId)
        {
            return await _context.Groups.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Group>> GetAllContactGroupUser(string user)
        {
            return await _context.Groups.Where(c=>c.UserId == user).ToListAsync();
        }

        public async Task Update(Group entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
