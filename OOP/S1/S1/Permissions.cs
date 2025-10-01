using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1
{
    // enum with a tag (flags)
    [Flags]
    internal enum Permissions : byte
    {
        Read = 1, 
        Write = 2, 
        Delete = 4, 
        Execute = 8
    }
}
