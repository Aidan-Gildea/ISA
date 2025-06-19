using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ISALib
{

    public class Instruc
    {
        public enum Thing
        {
            OPCODE,
            REGISTER,
            VALUE,
            PAD
        };

        public Thing[] Order;

        public KeyValuePair<string, byte> OpCode;

        public Instruc(Thing[] ORDER, KeyValuePair<string, byte> OPCODE)
        {
            Order = ORDER;
            OpCode = OPCODE;
        }

        public byte[] Assemble(string[] perameters) //includes opcode, so offset ny 1
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

        public string Disassemble(byte[] args) 
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < args.Length; i++) 
            {
                switch (Order[i]) 
                {
                    case Thing.OPCODE:
                        sb.Append($"{OpCode.Key} ");
                        break;
                    case Thing.REGISTER:
                        sb.Append($"{} ");
                        break;
                    case Thing.VALUE:
                        break;
                    case Thing.PAD:
                        break;
                }
            }
        }
    }
}
