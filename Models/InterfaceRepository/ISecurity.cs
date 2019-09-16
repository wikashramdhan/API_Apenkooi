using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.InterfaceRepository
{
    interface ISecurity
    {
        bool Login(string username, string password);
    }
}
