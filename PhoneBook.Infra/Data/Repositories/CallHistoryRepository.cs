using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.CallHistories;
using PhoneBook.Domain.CallHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Data.Repositories
{
    public class CallHistoryRepository : ICallHistoryRepository
    {
        private readonly PhoneBookDbContext _context;

        public CallHistoryRepository(PhoneBookDbContext context)
        {
            _context = context;
        }

        public async Task<CallHistory> Add(CallHistory entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(CallHistory entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<CallHistory> Get(int id)
        {
            return await _context.CallHistories.FindAsync(id);
        }

        public async Task<IReadOnlyList<CallHistory>> GetAll()
        {
            return await _context.CallHistories.ToListAsync();
        }

        public async Task Update(CallHistory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
