using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ISALib
{
    public enum Thing 
    {
        OPCODE,
        REGISTER,
        VALUE,
        PAD
    };
    public class Instruction
    {
        public Thing[] Order;

        public KeyValuePair<string, byte> OpCode;

        public Instruction(Thing[] ORDER, KeyValuePair<string, byte> OPCODE) 
        {
            Order = ORDER;
            OpCode = OPCODE;
        }

        public byte[] Assemble(string[] perameters)
        {
            byte[] bytes = new byte[4];

            for (int i = 0; i < 4; i++)
            {
                switch (Order[i])
                {
                    case Thing.OPCODE:
                        bytes[i] = OpCode.Value;
                        break;

                    case Thing.REGISTER:
                        bytes[i] = Registers.reg[perameters[i]];
                        break;

                    case Thing.VALUE:
                        bytes[i] = byte.Parse(perameters[i]);
                        break;

                    case Thing.PAD:
                        bytes[i] = 0x00;
                        break;
                }
            }

            return bytes;
        }
    }
}
