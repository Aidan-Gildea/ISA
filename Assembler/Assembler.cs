using System.Reflection.Emit;
using System.Security.Cryptography;
using ISALib;

namespace ISA.Assembler
{
    internal class Assembler
    {
        const string COMMENT = "#";
        const byte INSTRUCTION_LENGTH = 4;

        static Dictionary<string, Instruction> OpCodes = new()
        {
            ["SET"] = new(new byte[] { }),
            ["ADD"] = new()
        };

        static Dictionary<string, byte> Registers = new()
        {
            ["R0"] = 0x00,
            ["R1"] = 0x01,

        };

        //A class for each command, that can assemble and disassemble? 

        static void Main(string[] args)
        {
            string InfiniteCounterPath = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\TestData\\InfiniteCouter.asm";
            string InfiniteCounterTestPath = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\InfiniteCounter.dasm";

            string[] file = ParseStringsFromFile(InfiniteCounterPath);

            int currentByte = 0;
            byte[] machineCode = new byte[file.Length * INSTRUCTION_LENGTH];


            foreach (var line in file)
            {
                string[] parts = line.ToUpper().Split(' ', StringSplitOptions.RemoveEmptyEntries); //splits each line into separate parts. 

                byte[] bytes = OpCodes[parts[0]].AssembleSelf();
                

                File.WriteAllBytes("TestData\\InfiniteCounter.bin", machineCode);
                
            }
            ;

        }

        static string[] ParseStringsFromFile(string path) 
        {
            return File.ReadAllLines(path);
        }
    }
}
