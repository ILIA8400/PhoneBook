using MediatR;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.Contacts
{
    public class UpdateContactCommand : IRequest<string>
    {
        public int Id { get; set; }
        [StringLength(55, MinimumLength = 3)]
        public required string Name { get; set; }
        [Phone]
        [Length(11, 11)]
        public required string PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        public ICollection<ContactGroup>? Groups { get; set; }
        public string UserId { get; set; }
    }
}
