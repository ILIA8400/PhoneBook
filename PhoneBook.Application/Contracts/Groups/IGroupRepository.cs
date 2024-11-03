using PhoneBook.Application.Contracts.BaseRepositories;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.Groups
{
    public interface IGroupRepository : IGenericRepository<ContactGroup>
    {
    }
}
