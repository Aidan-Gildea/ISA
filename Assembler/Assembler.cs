using System.Reflection.Emit;
using System.Security.Cryptography;
using ISALib;
using static ISALib.Instruc.Thing;
using static ISALib.OpCodes;

namespace ISA.Assembler
{
    internal class Assembler
    {
        const string COMMENT = "#"; // comment string. 
        const string LABEL = ":";
        const string COMMENT2 = ";";
        const byte INSTRUCTION_LENGTH = 4; // 4 bytes / instruction

        const string AssemblyCodeFile = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\TestData\\InfiniteCouter.asm";
        const string BinaryOutputFile = "TestData\\TestInfiniteCounter.bin";

        static void Main(string[] args)
        {
            //string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string projectPath = Path.Combine(docPath, "source", ) for dynamic file paths


            byte[] machineCode = Assemble(AssemblyCodeFile);
            File.WriteAllBytes(BinaryOutputFile, machineCode);


        }

        static string[] ParseStringsFromFile(string path) 
        {
            return File.ReadAllLines(path);
        }

        static byte[] Assemble(string File) 
        {
            //first pass
            string[] file = ParseStringsFromFile(File);

            Dictionary<string, byte> labels = new();

            int passednonlabels = 0; 
            for(int l = 0; l < file.Length; l++) 
            {
                string[] parts = file[l].ToUpper().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) 
                {
                    continue;
                }//splits each line into separate parts. 
                if (parts[0] == COMMENT2) continue;
                if (parts[0] == LABEL) 
                {
                    labels.Add(parts[1], (byte)(passednonlabels)); //note that the indexes start at 1. If i want to point 2 lines in the future, have to do +2
                }
                else 
                {
                    passednonlabels++;
                }
            }
            //iterate through and get all labels. 

            int currentByte = 0;
            byte[] machineCode = new byte[file.Length * INSTRUCTION_LENGTH];



            foreach (var line in file)
            {
                if(line == "") 
                {
                    continue;
                }
                string[] parts = line.ToUpper().Split(' ', StringSplitOptions.RemoveEmptyEntries); //splits each line into separate parts. 

                if (parts[0] == COMMENT2) continue;

                if (parts[0] == LABEL) 
                {
                    continue;
                }

                byte[] bytes = Codes[parts[0]].Assemble(parts, labels);
                foreach (byte val in bytes)
                {
                    machineCode[currentByte] = val;
                    currentByte++;
                }
            }
            return machineCode;

        }
    }
}
