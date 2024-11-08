using PhoneBook.Application.Contracts.BaseRepositories;
using PhoneBook.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.Messages
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
