using PhoneBook.Application.Contracts.BaseRepositories;
using PhoneBook.Domain.CallHistories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.CallHistories
{
    public interface ICallHistoryRepository : IGenericRepository<CallHistory>
    {
    }
}
