using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static ISALib.Registers;
namespace ISALib
{
    public class Operations
    {
        public static void ADD(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] + registers[PARAM3]);
        }

        public static void SUB(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] - registers[PARAM3]);
        }

        public static void MULT(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] * registers[PARAM3]);
        }

        public static void DIV(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            if (registers[PARAM3] != 0)
                registers[PARAM1] = (ushort)(registers[PARAM2] / registers[PARAM3]);
            else
                registers[PARAM1] = 0; // handle divide by zero as zero output
        }

        public static void EQ(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (registers[PARAM2] == registers[PARAM3]) ? (ushort)1 : (ushort)0;
        }

        public static void GTHAN(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (registers[PARAM2] > registers[PARAM3]) ? (ushort)1 : (ushort)0;
        }

        public static void LTHAN(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (registers[PARAM2] < registers[PARAM3]) ? (ushort)1 : (ushort)0;
        }

        public static void SETBIT(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] |= (ushort)(1 << PARAM2);
        }

        public static void CLRBIT(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            ushort val = 0; 
            for(int i = 0; i < 16; i++) 
            {
                if(i != PARAM2) 
                {
                    val |= (ushort)(1 << i);
                }
            }
            registers[PARAM1] &= val;
        }

        public static void SET(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)PARAM2;
        }

        public static void MOV(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = registers[PARAM2];
        }

        public static void PRNT(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            // Checks if the print bit (first bit) of flag register is set to 1
            if ((registers[reg["FLAGS"]] & 1) == 1)
            {
                // Set the print bit to 0
                CLRBIT(registers, reg["FLAGS"], 0, PARAM3, EXTRA);

                // Print the value in the CHAR register (assuming CHAR register is at index 2)
                Console.Write(registers[reg["CHAR"]]);
            }
        }

        public static void READ(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                registers[reg["CHAR"]] = (ushort)keyInfo.KeyChar; // Store the key into val register
            }
        }

        public static void RNDM(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            // If the rndm flag random bit is set to 0
            if (((registers[reg["FLAGS"]] & (1 << FlagIndex["RNDM"])) >> FlagIndex["RNDM"]) == 1)
            {
                CLRBIT(registers, reg["FLAGS"], 2, PARAM3, EXTRA);

                Random rnd = new Random();
                registers[reg["RNDM"]] = (ushort)rnd.Next(PARAM1, PARAM2);
            }
        }

        public static void LOAD(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            throw new NotImplementedException();
        }

        public static void STR(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            throw new NotImplementedException();
        }

        public static void INC(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1]++;
        }

        public static void DEC(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1]--;
        }

        public static void NOT(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(~registers[PARAM2]);
        }

        public static void AND(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] & registers[PARAM3]);
        }

        public static void OR(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] | registers[PARAM3]);
        }

        public static void NOR(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(~(registers[PARAM2] | registers[PARAM3]));
        }

        public static void NAND(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(~(registers[PARAM2] & registers[PARAM3]));
        }

        public static void XOR(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] ^ registers[PARAM3]);
        }

        public static void LSHF(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] << registers[PARAM3]);
        }

        public static void RSHF(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            registers[PARAM1] = (ushort)(registers[PARAM2] >> registers[PARAM3]);
        }

        public static void NONE(ushort[] registers, byte PARAM1, byte PARAM2, byte PARAM3, int EXTRA)
        {
            return;
        }
    }
}