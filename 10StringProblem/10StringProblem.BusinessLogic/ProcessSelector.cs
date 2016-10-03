using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10StringProblem.BusinessLogic
{
    public class ProcessSelector
    {

        /// <summary>
        /// Process input value with bruteforce
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public List<long> ProcessBruteForce(long inputValue)
        {
            List<long> returnValuesList = new List<long>();
            for (long i = 0; i < inputValue; i++)
            {
                AlgoHelper helper = new AlgoHelper();
                if (helper.ValidateFriendlyNess(i))
                    returnValuesList.Add(i);
            }

            return returnValuesList;
        }

    }

}
