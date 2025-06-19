using System.Text;

namespace ISA.Disassembler
{
    internal class Disassembler
    {
        static Dictionary<byte, string> OpCodes = new()
        {
            [0x41] = "SET",
            [0x10] = "ADD"
        };

        //function that takes in string and outputs bytes, and other way? Possibly class for each command. making labels... 
        //Tomorrow, learn regular expressions... 
        //The minute you are doing something in more than one file, consider the option that I shouldn't have to do that. So use the class library? 
        //scoping the code so I can reuse variable names in switches? 
        const string disassemblyFileName = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\TestData\\InfiniteCounter.dasm";
        static void Main(string[] args)
        {
            const int INSTRUCTION_LENGTH = 4;

            string machineFileName = "C:\\Users\\Aidan.Gildea\\source\\repos\\ISA\\Assembler\\bin\\Debug\\net8.0\\TestData\\InfiniteCounter.bin";
            byte[] machineCode = File.ReadAllBytes(machineFileName);

            StringBuilder disassembly = new();

            for (int i = 0; i < machineCode.Length; i += 4) // will iterate through  
            {
                byte opCode = machineCode[i];
                switch (opCode)
                {
                    case 0x10:
                        int resultRegIndex = machineCode[i + 1];
                        int Reg1Index = machineCode[i + 2];
                        int Reg2Index = machineCode[i + 3];

                        string addLine = $"ADD R{resultRegIndex} R{Reg1Index} R{Reg2Index}";
                        disassembly.AppendLine(addLine);
                        //Console.WriteLine(addLine);
                        break;

                    case 0x41:
                        byte regIndex = machineCode[i + 1];
                        byte hiByte = machineCode[i + 2];
                        byte lowByte = machineCode[i + 3];

                        ushort regIndexValue = (ushort)(hiByte << 4 | lowByte);
                        string setLine = $"SET R{regIndex} {regIndexValue:X4}";
                        //Console.WriteLine(setLine);
                        disassembly.AppendLine(setLine);


                        break;
                }

            }
            Console.WriteLine(disassembly.ToString());
            File.WriteAllText(disassemblyFileName, disassembly.ToString());
        }
    }
}
