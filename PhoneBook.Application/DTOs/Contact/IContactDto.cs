using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Contact
{
    public interface IContactDto
    {
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string? Email { get; set; }
        string? Address { get; set; }
    }
}
