using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Contacts;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookDbContext _context;

        public ContactRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> Add(Contact entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Contact entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<Contact> Get(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task<IReadOnlyList<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task Update(Contact entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
