using System.Diagnostics;
using System.Reflection;

namespace ISA.Emulator
{
    internal class Emulator
    {
        const int INSTRUCTION_LENGTH = 4;
        const int NUM_OF_REGISTERS = 32;

        static ushort[] Registers = new ushort[NUM_OF_REGISTERS];

        

        static void Main(string[] args)
        {
            string machineFileName = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\InfiniteCounter.bin";
            byte[] machineCode = File.ReadAllBytes(machineFileName);

            for(int i = 0; i < machineCode.Length; i+= 4) // will iterate through  
            {
                byte opCode = machineCode[i];
                switch (opCode) 
                {
                    case 0x10:
                        int resultRegIndex = machineCode[i + 1];
                        int Reg1Index = machineCode[i + 2];
                        int Reg2Index = machineCode[i + 3];

                        ushort a = Registers[Reg1Index];
                        ushort b = Registers[Reg2Index];

                        Registers[resultRegIndex] = (ushort)(a + b);

                        Console.WriteLine($"ADD R{resultRegIndex} R{Reg1Index} R{Reg2Index}");
                        break;

                    case 0x41:
                        byte regIndex = machineCode[i + 1];
                        byte hiByte = machineCode[i + 2];
                        byte lowByte = machineCode[i + 3];
                        
                        ushort val = (ushort)(hiByte << 8 | lowByte);

                        Registers[regIndex] = val;

                        Console.WriteLine($"SET R{regIndex} {val:X4}");


                        break;
                }

            }

        }
    }
}
