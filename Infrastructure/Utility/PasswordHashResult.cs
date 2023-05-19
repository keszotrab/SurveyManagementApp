using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utility
{

    public class PasswordHashResult
    {
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
