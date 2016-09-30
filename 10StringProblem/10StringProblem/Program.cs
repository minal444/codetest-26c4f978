using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
                Console.WriteLine("Please enter the input string");
                inputString = Console.ReadLine();
                if (ValidateInput(inputString))
                {
                    ProcessRequest();
                }
                PrintOutput();
                Console.WriteLine(Environment.NewLine + "Press enter to close application");
                Console.ReadLine();
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
            sb.Append("]");
            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Process request if input is valid
        /// </summary>
        private static void ProcessRequest()
        {
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
