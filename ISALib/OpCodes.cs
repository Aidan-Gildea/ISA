using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static ISALib.Instruc.Thing;

namespace ISALib
{
    public static class OpCodes
    {
        public static Dictionary<string, Instruc> Codes = new()
        {

            // MATH
            ["NONE"] = new([OPCODE, PAD, PAD, PAD], new("NONE", 0x00)),
            ["SET"] = new([OPCODE, REGISTER, VALUE, PAD], new("SET", 0x41)),
            ["ADD"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("ADD", 0x10)),
            ["ADD"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("ADD", 0x10)),
            ["SUB"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("SUB", 0x11)),
            ["MULT"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("MULT", 0x12)),
            ["DIV"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("DIV", 0x13)),
            ["EQ"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("EQ", 0x14)),
            ["GTHAN"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("GTHAN", 0x15)),
            ["LTHAN"] = new([OPCODE, REGISTER, REGISTER, REGISTER], new("LTHAN", 0x16)),

            // 

        };

        
    }
}
