using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class RandomStringArrayTool
    {
        static Random _random = new Random();

        public static Elements[] RandomizeStrings(Elements[] arr)
        {
            List<KeyValuePair<int, Elements>> list = new List<KeyValuePair<int, Elements>>();
            // Add all strings from array
            // Add new random int each time
            foreach (Elements s in arr)
            {
                list.Add(new KeyValuePair<int, Elements>(_random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            Elements[] result = new Elements[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, Elements> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }

    }
}