using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.Messages;
using PhoneBook.Domain.Messages;
using PhoneBook.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Persistence.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly PhoneBookDbContext _context;

        public MessageRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<Message> Add(Message entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Message entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<Message> Get(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<IReadOnlyList<Message>> GetAll()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task Update(Message entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
