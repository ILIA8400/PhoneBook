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

        public async Task<bool> Exist(int id, string userId)
        {
            var entity = await Get(id, userId);
            return entity != null;
        }

        public async Task<Contact> Get(int id, string userId)
        {
            var contact = await _context.Contacts.SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);
            foreach (var group in contact.Groups)
            {
                group.Contacts = null;
            }
            return contact;
        }

        public async Task<List<Contact>> GetAll(string userId)
        {
            var contacts = await _context.Contacts.Where(x => x.UserId == userId).Include(x => x.Groups).ToListAsync();
            foreach (var contact in contacts)
            {
                foreach (var group in contact.Groups)
                {
                    group.Contacts = null;
                }
            }
            return contacts;
        }

        public async Task Update(Contact entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
