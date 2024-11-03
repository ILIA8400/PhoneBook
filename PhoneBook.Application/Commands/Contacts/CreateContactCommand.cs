﻿using MediatR;
using PhoneBook.Application.DTOs.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Commands.Contacts
{
    public class CreateContactCommand : IRequest<CreateContactDto>
    {
        [StringLength(55,MinimumLength =3)]
        public required string Name { get; set; }
        [Phone]
        [Length(11,11)]
        public required long PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? Address { get; set; }
        public ICollection<ContactGroup>? Groups { get; set; }
    }
}