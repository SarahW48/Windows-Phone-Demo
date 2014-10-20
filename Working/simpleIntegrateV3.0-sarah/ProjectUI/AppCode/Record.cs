using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class Record
    {
        public Record(int i, double w)
        {
            index = i;
            weight = w;
        }
        public int index;
        public double weight;
    }
}