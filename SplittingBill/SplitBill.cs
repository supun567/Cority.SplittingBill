using System;
using System.Collections.Generic;

namespace SplittingBill
{
    public class SplitBill
    {
        int NoOfCycles;

        public bool IsStructureValid(string[] returnText)
        {
            bool result=false;

            //Get number of lines in the string array
            int NumberOfRecords = returnText.Length;
            int NoOfTrips = 0;
            bool BillCycle = false;
            bool PeopleCycle = false;
            
            

            //Untill the EOF is reached iterate through each record
            for (int i = 0; i < NumberOfRecords; i++)
            {
                if (returnText[i] == "0")
                {
                    //Reached the EOF
                    break;
                }
                else
                {
                    bool CanConvertTrip = int.TryParse(returnText[i], out int valueTrips);
                    if (CanConvertTrip) //Integer value is read // No of people
                    {
                        i++;
                        for (int j = 0; j < valueTrips; j++)
                        {
                            bool CanConvertBills = int.TryParse(returnText[i], out int valueBills);
                            if (CanConvertBills) //Integer value is read // no of bills for the person
                            {
                                i++;
                                for (int k = 0; k < valueBills; k++)
                                {
                                    bool CanConvertBillValue = int.TryParse(returnText[i], out int individualValue);
                                    i++;
                                    if (CanConvertBillValue)
                                    {
                                        break;                                          
                                    }
                                    else
                                    {
                                        NoOfCycles = k+1;
                                        continue;  
                                    }
                                }
                                // check for loop value
                                if (valueBills != NoOfCycles)//((valueBills != NoOfCycles+1) && (NoOfCycles < valueBills))
                                {
                                    //loop incomplete or overdone
                                    return false;
                                }
                                else if((valueBills == NoOfCycles))
                                {
                                    BillCycle = true;
                                }

                                if (j == valueTrips - 1)
                                {
                                    PeopleCycle = true;
                                }
                            }
                        }
                        NoOfTrips++;
                        i--;
                    }
                }            
            }

            //Check whether both cycles are executed properly
            if ((PeopleCycle == true) && (BillCycle == true))
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        static void Main(string[] args)
        {
            //Test Code Section
            //string[] inputstring = { "3", "5", "10.00", "20.00", "4", "15.00", "15.01", "4.00", "3.01", "3", "5.00", "9.00", "14.00", "2", "2", "8.00", "6.00", "2", "9.20", "6.75", "0" };

            //SplitBill sb = new SplitBill();
            //bool resultT = sb.IsStructureValid(inputstring);

            //End of Test Section
            Console.WriteLine("Splitting the Bill - Supun Kandaudahewa");

            //Checking if commandline arguements are received properly
            
            var readfile = new ReadFile();
          
            if (!ReadFile.CheckArguements(args) == true)
            {
                Console.WriteLine("File name not received properly. Please check and re-input");
                return;
            }

           // args.Length returned 1, valid file name received moving forward to read the file

            string[] ReturnText= readfile.ReturnText(args[0].ToString());

            //Check if the file is read properly, if not display message and exit the program
            if ((ReturnText == null)||(!ReadFile.CheckForInvalidCharacters(ReturnText)))
            {
                Console.WriteLine("File is null or invalid characters present");
                return;      
            }


            SplitBill sb = new SplitBill();
            bool result = sb.IsStructureValid(ReturnText);

            if (result == false)
            {
                Console.WriteLine("Error in the structure of input file");
                return;
            }


            List<string> Output = new();

            for (int i = 0; i < ReturnText.Length; i++)
            {
                //Adjusting index if arrayindex > 0
                if (i > 0)
                    i--;

                //To check end of file
                if (ReturnText[i] == "0")
                {
                    return;
                }
                else
                { 
                    int NoOfPeople = Convert.ToInt32(ReturnText[i].ToString()); 
                    Double TotalValue = 0;
                    int NoOfBills;
                    i++;

                    double[] Sum = new double[NoOfPeople];

                    for (int j = 0; j < NoOfPeople; j++)
                    {
                        //Calculating individual bill amounts
                        NoOfBills= Convert.ToInt32(ReturnText[i].ToString());
                        i++;
                        for (int k = 0; k < NoOfBills; k++)
                        {
                            Sum[j] += Convert.ToDouble(ReturnText[i].ToString());
                            TotalValue += Convert.ToDouble(ReturnText[i].ToString());
                            i++;
                        }                       
                    }
                    //Calculating PerPersonCost
                    double PerPersonCost = TotalValue / NoOfPeople;

                    for (int p = 0; p < NoOfPeople; p++)
                    {
                        //Calculating individual dues
                        Sum[p] = Math.Round(Sum[p]-PerPersonCost,3);

                        //Writing to list
                        if (Sum[p] > 0)
                        {
                            Output.Add("$(" + Math.Abs(Math.Round(Sum[p], 2)).ToString() + ")");
                        }
                        else
                        {
                            Output.Add("$" + Math.Abs(Math.Round(Sum[p], 2)).ToString());
                        }
                        Output.Add(""); //Adding the blank lines
                    }
                    //Adding the blank lines
                    Output.Add("");
                }
            }

            //Write output to file
            try
            {
                var writefile = new WriteFile();

                WriteFile.CheckOutputForNullOrEmpty(Output);

                //Writing data to output file
                WriteFile.WriteText(args[0].ToString(), Output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Output not generated : " + ex.Message.ToString());
            }
            
        }
    }
}
