﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Queries.Groups
{
    public class GetGroupByNameQuery : IRequest<bool>
    {
    }
}
