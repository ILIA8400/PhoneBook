﻿using PhoneBook.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.CallHistories
{
    public class CallType : BaseEntity
    {
        public string Name { get; set; }
    }
}
