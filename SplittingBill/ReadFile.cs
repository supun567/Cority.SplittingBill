using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SplittingBill
{
    public class ReadFile
    {
        public String[] ReturnText(string FileName)
        {
            //Reading text in file and returning to main
            string[] AllText=null;
            try
            {
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

                _filePath += @"\" + FileName;

                AllText = File.ReadAllLines(_filePath).Where(line => !string.IsNullOrWhiteSpace(line)).ToArray(); ;
                
                return AllText;

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error reading the inputfile :"+ ex.Message.ToString());
                return AllText;
            }
        }

        public static bool CheckArguements(string[] Arguements)
        {
            try
            {
                if (Arguements.Length == 0)
                {
                    Console.Error.WriteLine("Please enter the input filename. Ex. ProgramName.exe YourFileName.txt");
                    return false;
                }
                else if (Arguements.Length > 1)
                {
                    Console.Error.WriteLine("Multiple values received. If your filename containes spaces, enclose them within double quotes. Ex: \"Your File Name.txt\"");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error Occured!! :" + ex.ToString());
                return false;
            }

            return true;
        }

        public static bool CheckForInvalidCharacters(string[] AllText)
        {
            bool result;
           
            foreach (string line in AllText)
            {
                result = decimal.TryParse(line, out decimal value);

                if (result == false)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
