using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Groups;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly PhoneBookDbContext _context;

        public GroupRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<ContactGroup> Add(ContactGroup entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(ContactGroup entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<ContactGroup> Get(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task<IReadOnlyList<ContactGroup>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task Update(ContactGroup entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
