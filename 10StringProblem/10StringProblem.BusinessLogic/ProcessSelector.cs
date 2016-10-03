using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _10StringProblem.BusinessLogic
{
    public class ProcessSelector
    {

        /// <summary>
        /// Process input value with bruteforce
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public List<long> ProcessBruteForce(long inputValue)
        {
            List<long> returnValuesList = new List<long>();
            BruteForceHelper helper;
//#if(DEBUG)
//            Debug.WriteLine(string.Format("{0}{1}","Start Time: ", DateTime.Now));
//#endif 
            for (long i = 0; i < inputValue; i++)
            {
                helper = new BruteForceHelper();
                if (helper.ValidateFriendlyNess(i))
                    returnValuesList.Add(i);
            }

//#if(DEBUG)
//            Debug.WriteLine(string.Format("{0}{1}", "End Time: ", DateTime.Now));
//#endif 

            return returnValuesList;
        }

        /// <summary>
        /// Process request with custom Logic
        /*
         * find two digit friendly number by bruteforce 
         * take each putput value
         * Add 0 in butween 
         */
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public List<long> ProcessCustomLogic(long inputValue)
        {
            List<long> returnValuesList = new List<long>();
            returnValuesList = ProcessBruteForce(inputValue<100?inputValue:100);
            if (inputValue <= 100)
                return returnValuesList;
            else
            {
                CustomAlgoHelper myAlgo = new CustomAlgoHelper(inputValue, returnValuesList);
                returnValuesList.AddRange(myAlgo.GenerateAllPossibleCombination());
                return returnValuesList;
            }
        }

    }

}
