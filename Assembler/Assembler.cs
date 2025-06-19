using System.Reflection.Emit;
using System.Security.Cryptography;
using ISALib;
using static ISALib.Instruc.Thing;
using static ISALib.OpCodes;

namespace ISA.Assembler
{
    internal class Assembler
    {
        const string COMMENT = "#";
        const byte INSTRUCTION_LENGTH = 4;

        //A class for each command, that can assemble and disassemble? 

        static void Main(string[] args)
        {
            string AssemblyCode = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\TestData\\InfiniteCouter.asm";
            string CycledAssemblyCode = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\InfiniteCounter.dasm";

            string[] file = ParseStringsFromFile(AssemblyCode);

            int currentByte = 0;
            byte[] machineCode = new byte[file.Length * INSTRUCTION_LENGTH];
           


            foreach (var line in file)
            {
                string[] parts = line.ToUpper().Split(' ', StringSplitOptions.RemoveEmptyEntries); //splits each line into separate parts. 

                byte[] bytes = Codes[parts[0]].Assemble(parts);
                foreach (byte val in bytes) 
                {
                    machineCode[currentByte] = val;
                    currentByte++;
                }
            }
            ;
            File.WriteAllBytes("TestData\\TestInfiniteCounter.bin", machineCode);

        }

        static string[] ParseStringsFromFile(string path) 
        {
            return File.ReadAllLines(path);
        }
    }
}
