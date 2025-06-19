using System.Collections.Generic;
using System.Text;
using static ISALib.OpCodes;

namespace ISA.Disassembler
{
    internal class Disassembler
    {

        const string disassemblyFileName = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\TestData\\InfiniteCounter.dasm";
        static void Main(string[] args)
        {
            byte[] machineCode = File.ReadAllBytes(disassemblyFileName);

            StringBuilder disassembly = new();

            for (int i = 0; i < machineCode.Length; i += 4) // will iterate through  
            {
                byte opCode = machineCode[i];
                var key = Codes.FirstOrDefault(x => x.Value.OpCode.Value == opCode).Key; // will return the OpCode of the given byte
                disassembly.Append(Codes[key].Disassemble()); //shorten the passed byte array to the current 4 bytes / total instruction, and then fill out instruction command. 



            }
            Console.WriteLine(disassembly.ToString());
            File.WriteAllText(disassemblyFileName, disassembly.ToString());
        }
    }
}
