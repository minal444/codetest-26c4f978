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
        /// 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <returns></returns>
        public List<long> ProcessBruteForce(long inputValue)
        {
            List<long> returnValuesList = new List<long>();
            AlgoHelper helper;
//#if(DEBUG)
//            Debug.WriteLine(string.Format("{0}{1}","Start Time: ", DateTime.Now));
//#endif 
            for (long i = 0; i < inputValue; i++)
            {
                helper = new AlgoHelper();
                if (helper.ValidateFriendlyNess(i))
                    returnValuesList.Add(i);
            }

//#if(DEBUG)
//            Debug.WriteLine(string.Format("{0}{1}", "End Time: ", DateTime.Now));
//#endif 

            return returnValuesList;
        }

        

    }

}
