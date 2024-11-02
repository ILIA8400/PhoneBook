using PhoneBook.Application.Contracts.BaseRepositories;
using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contracts.Contacts
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
    }
}
