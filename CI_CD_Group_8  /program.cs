using System;

namespace CI_CD_Group_8
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string input;

            if (args.Length > 0)
            {
                input = args[0];
            }
            else
            {
                Console.Write("Skriv personnummer (YYMMDD-XXXX): ");
                input = Console.ReadLine() ?? "";
            }

            bool valid = PersonnummerValidator.IsValid(input);

            Console.WriteLine(valid ? "Giltigt personnummer" : "Ogiltigt personnummer");

            // 0 = OK, 1 = fel (bra för Docker/CI)
            return valid ? 0 : 1;
        }
    }
}
