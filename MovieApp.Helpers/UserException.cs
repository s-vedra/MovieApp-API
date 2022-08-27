using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Helpers
{
    public class UserException : Exception
    {
        public UserException() : base("Something went wrong")
        {

        }
    }
}
