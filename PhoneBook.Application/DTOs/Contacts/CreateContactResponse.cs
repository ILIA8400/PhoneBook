using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.DTOs.Contacts
{
    public class CreateContactResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string? Message { get; set; }
    }
}
