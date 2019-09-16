using API_APENKOOI.Models.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_APENKOOI.Models.Repository
{
    public class Security : ISecurity
    {
        private readonly Context context;
        public Security(Context context)
        {
            this.context = context;
        }
        public bool Login(string username, string password)
        {
            return context.APIUsers.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}
