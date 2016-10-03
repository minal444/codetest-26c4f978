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
    public class BruteForceHelper
    {
        private bool AddMore { get; set; }
        private bool CurrentSequenceValid { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        public BruteForceHelper()
        {
            AddMore = false;
            CurrentSequenceValid = false;
        }

        /// <summary>
        /// Main method to validate if number is digit friendly 
        /// </summary>
        /// <param name="iNumber"></param>
        /// <returns></returns>
        public bool ValidateFriendlyNess(long iNumber)
        {
            int[] arrDigits = iNumber.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
            long iNumberToValidate = arrDigits[0];
            if (arrDigits.Length < 2)//checking double digit only 
                return false;
            //loop through all digit of the number
            // to do check while loop performence (once sample is working
            for (int i = 1; i < arrDigits.Length; i++)
            {

                iNumberToValidate = Convert.ToInt32(string.Format("{0}{1}", iNumberToValidate, arrDigits[i]));
                this.CurrentSequenceValid = false;

                if (isNumberTotalFriendly(iNumberToValidate))
                {
                    this.CurrentSequenceValid = true;
                    iNumberToValidate = RemoveFirstDigit(iNumberToValidate.ToString());
                    continue;
                }
                else
                {
                    if (this.AddMore)
                    {
                        continue;
                    }
                    else
                        return false;
                }
            }
            if (this.CurrentSequenceValid)
                return true;
            return false;
        }

        private int RemoveFirstDigit(string strNumberToValidate)
        {
            //find best methoed to remove first digit
            return Convert.ToInt32(strNumberToValidate.Substring(1, strNumberToValidate.Length - 1));
        }

        /// <summary>
        /// compare number with friendly total number from constant
        /// return property if number can accomodate more number
        /// </summary>
        /// <param name="iSubNumber"></param>
        /// <returns></returns>
        public bool isNumberTotalFriendly(Int64 iSubNumber)
        {
            int result = iSubNumber.ToString().Sum(c => Convert.ToInt32(c) - 48);
            if (result == Constants.FriendlyTotal)
                return true;
            else if (result < Constants.FriendlyTotal)
            {
                this.AddMore = true;
                return false;
            }
            else
            {
                this.AddMore = false;
                return false;
            }
        }

    }
}
