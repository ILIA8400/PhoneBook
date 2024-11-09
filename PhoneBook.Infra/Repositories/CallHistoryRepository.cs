using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Contracts.CallHistories;
using PhoneBook.Domain.CallHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Infra.Repositories
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

        public async Task<bool> Exist(int id, string userId)
        {
            var entity = await Get(id,userId);
            return entity != null;
        }

        public async Task<CallHistory> Get(int id,string userId)
        {
            return await _context.CallHistories.SingleOrDefaultAsync(c => c.Id == id && c.UserId == userId);
        }

        public async Task<List<CallHistory>> GetAll(string userId)
        {
            return await _context.CallHistories.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task Update(CallHistory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
