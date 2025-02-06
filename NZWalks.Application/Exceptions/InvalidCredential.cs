using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZWalks.Application.Exceptions
{
    public class InvalidCredential : Exception
    {
        public InvalidCredential(string message) : base(message)
        {
            
        }
    }
}
