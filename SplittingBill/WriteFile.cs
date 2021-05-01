using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingBill
{
    public class WriteFile
    {
        public static bool WriteText(string FileName, List<string> OutputText)
        {
            bool Result = false;
            //Writing data to output file
            try
            {
                string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

                _filePath += @"\" + FileName + ".out";
                File.WriteAllLines(_filePath, OutputText);
                Result=true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error writing to output file :"+ ex.Message.ToString());
                return Result;
            }
            return Result;
        }

        //public bool CheckOutputForInvalidCharacters(List<string> OutputText)
        //{
        //    bool result;

        //    foreach (string line in OutputText)
        //    {
        //        result = decimal.TryParse(line, out decimal value);

        //        if (result == false)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}

        public static bool CheckOutputForNullOrEmpty(List<string> OutputText)
        {
            if ((OutputText == null) || (OutputText.ToArray().Length == 0))
            {
                return false;
            }

            return true;
        }
    }
}
