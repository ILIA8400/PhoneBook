using PhoneBook.Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Groups
{
    public class GroupDto
    {
        public string GroupName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
