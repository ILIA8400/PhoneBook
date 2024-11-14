using AutoMapper;
using PhoneBook.Application.DTOs.Contact;
using PhoneBook.Application.DTOs.Group;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Groups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact,CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Group, CreateGroupDto>().ReverseMap();
            CreateMap<Group, UpdateGroupDto>().ReverseMap();
        }
    }
}
