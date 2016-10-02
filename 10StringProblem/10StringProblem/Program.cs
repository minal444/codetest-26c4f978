using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using _10StringProblem.BusinessLogic;
namespace _10StringProblem
{
    public class Program
    {
        protected static string inputString; //input variable
        protected static long inputValue; //input variable after converting to Int64
        protected static List<long> outputValues = new List<long>(); //output values for print
        /// <summary>
        /// Console Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            try
            {

                inputString=string.Empty; //input variable
                inputValue=0; //input variable after converting to Int64
                outputValues = new List<long>(); //output values for print

                Console.WriteLine("Please enter the input string");
                inputString = Console.ReadLine();
                if (ValidateInput(inputString))
                {
                    //process request if input is valid
                    ProcessRequest();
                }
                PrintOutput();
                Console.WriteLine(Environment.NewLine + "Press Esc to close Application" + Environment.NewLine + "Press any key to continue with new input");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape)//close on escape
                    return;
                else//loop back
                {
                    Console.WriteLine(Environment.NewLine + Environment.NewLine );
                    Main(new string[1]);
                }
            }
            catch (Exception ex)
            {
                //Main exception to catch
                
#if (DEBUG)
                Console.WriteLine(ex.Message);
                Console.ReadLine();                
#else 
                Console.WriteLine("Error occured - Please contact admin" + Environment.NewLine + "Press enter to close application");
                Console.ReadLine();
#endif

            }
            
            
        }

        /// <summary>
        /// print output to console
        /// </summary>
        private static void PrintOutput()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < outputValues.Count; i++)
            {
                sb.Append(outputValues[i].ToString());
                sb.Append(", ");

            }
            ///remove last comma
            sb.Replace(',',' ',sb.ToString().Length-2,1);
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Process request if input is valid
        /// </summary>
        private static void ProcessRequest()
        {
            ///to do threading

            try
            {
                inputValue = Convert.ToInt64(inputString);
                for (long i = 0; i < inputValue; i++)
                {
                    AlgoHelper helper = new AlgoHelper();
                    if (helper.ValidateFriendlyNess(i))
                        outputValues.Add(i);
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// validate user input
        /// </summary>
        /// <returns></returns>
        public static bool ValidateInput(string inputValue)
        {
            try
            {

                Match m = Regex.Match(inputValue, @"^[0-9]+$");
                return m.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
