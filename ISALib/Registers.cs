using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISALib
{
    class Registers
    {
        public static Dictionary<string, byte> reg = new() 
        {
            ["R0"] = 0x00,
            ["R1"] = 0x01
        };
    }
}
