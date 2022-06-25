using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAAProject
{
    public class SearchingAlgorithms
    {
        /// <summary>
        /// Linear Search implementation
        /// </summary>
        /// <param name="inputarray"></param>
        /// <param name="searchelement"></param>
        /// <returns></returns>
        public int LinearSearch(long[] inputarray,int searchelement)
        {
            for (int i = 0; i < inputarray.Length; i++)
            {
                if (inputarray[i] == searchelement)
                {
                    return i + 1;//position of element i.e. index+1
                }
            }
            return -1;
        }

        /// <summary>
        /// Binary search implementation
        /// </summary>
        /// <param name="inputarray"></param>
        /// <param name="searchelement"></param>
        /// <returns></returns>
        public int BinarySeach(long[] inputarray, int searchelement)
        {
            int low = 0;
            int high = inputarray.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (inputarray[mid] < searchelement)
                {
                    low = mid + 1;
                }
                else if (inputarray[mid] > searchelement)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid + 1;//position of element i.e. index+1
                }
            }
            return -1;
        }
    }
}