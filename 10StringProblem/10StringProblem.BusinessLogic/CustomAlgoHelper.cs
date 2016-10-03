using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10StringProblem.BusinessLogic
{

    /// <summary>
    /*
     * run bruteforce for first 9 values (<100)
     * use that value as initial values
     * Loop through all values with following process (Sample 19)
     * --add a digit (0) at second last position --109
     * --add +1 in last but one digit and subtract -1 from last digit
     * --loop till new digit become last digit
     * --add anomaly with add 10-last digit from initial value as last digit (in this case 191)
     * Loop all value until input value reaches
     */
    /// </summary>
    public class CustomAlgoHelper
    {
        private long MaxInputNumber { get; set; }
        private List<long> InitialValue { get; set; }
        private bool MaxValueReached { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public CustomAlgoHelper(long InputNumber, List<long> initialValue)
        {
            this.MaxInputNumber = InputNumber;
            this.InitialValue = initialValue; 
        }

        /// <summary>
        /// generate all combination [recersive loop]
        /// </summary>
        /// <returns></returns>
        public List<long> GenerateAllPossibleCombination()
        {
            List<long> returnValuesList = new List<long>();

            for (int i = 0; i < this.InitialValue.Count; i++)
            {
                returnValuesList.AddRange(GenerateCombination(this.InitialValue[i]));
                if (this.MaxValueReached)
                    break;
            }
            if (!this.MaxValueReached)
            {
                this.InitialValue = returnValuesList;
                returnValuesList.AddRange(GenerateAllPossibleCombination());
            }
            return returnValuesList;
        }

        /// <summary>
        /// GenerateCombination will generate all possible combinatino by adding digit at second last position
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public List<long> GenerateCombination(long iNumber)
        {
            List<long> returnValuesList = new List<long>();
            int lastDigit = Convert.ToInt32(iNumber % 10);
            Int64 lastbutOtherDigit = Convert.ToInt64(iNumber / 10);
            for (int i = 0,j=lastDigit; i <= lastDigit; i++,j--)
            {
                int newNumber = Convert.ToInt32(string.Format("{0}{1}", i, j));
                returnValuesList.Add( Convert.ToInt64(string.Format("{0}{1}", lastbutOtherDigit, newNumber.ToString("D2"))));
            }
            
            //To Do missing values
            //with above algorithm if we pass 19 then 191 return value is missing 
            //same with pass value:28 --> 282 is missing
            
            //adding condition to handle error because last digit will be having 10 which breaks loop
            if (lastDigit.ToString("D1") != "0")
            {
                long ianomalyValue = Convert.ToInt64(string.Format("{0}{1}{2}", lastbutOtherDigit, lastDigit.ToString("D1"), (10 - lastDigit).ToString("D1")));
                returnValuesList.Add(ianomalyValue);
            }

            if (returnValuesList.Max() > this.MaxInputNumber)
            {
                this.MaxValueReached = true;
                //To Do check performence with Where/FindAll 
                return returnValuesList.FindAll(x => x < this.MaxInputNumber+1);//added +1 to return input value
            }

            return returnValuesList;
        }

       

    }

    
}
