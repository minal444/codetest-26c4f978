using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace _10StringProblem.BusinessLogic
{

    /// <summary>
    /// Basic process of Algo 
    /// input Number = iNumber
    /// sub of number = iSum
    /// while (inputnumber array size)
    /// {
    ///     get first digit
    ///     iSum += iNumber
    ///     if(isum==10)
    ///         {
    ///             Set some flag
    ///             AddNextDigit()
    ///             Loop Again
    ///         }
    ///     if(sum>10)
    ///         {
    ///             removefirstdigit()
    ///             Loop Again
    ///         }
    ///     if(sum>10)
    ///         {
    ///             AddNextDigit()
    ///             Loop Again
    ///         }
    ///         
    /// }
    /// 
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
            
            if (returnValuesList.Max() > this.MaxInputNumber)
            {
                this.MaxValueReached = true;
                //To Do check performence with Where/FindAll 
                return returnValuesList.FindAll(x => x < this.MaxInputNumber);
            }

            return returnValuesList;
        }

        

    }

    
}
