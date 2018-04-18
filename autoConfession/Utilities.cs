using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoConfession
{
    class Utilities
    {
        public static string extractIDFromLink(string Link)
        {
            //https://docs.google.com/spreadsheets/d/15HIx2tD-E-zBn6ZY4rMjv0IlE0pu_dGoc7ybuqbkXXI/edit#gid=1070981831
            return string.Join(String.Empty, Link.Split('/').Reverse().Skip(1).Take(1));
        }
    }
}
