using System;
using System.Collections.Generic;
using System.Text;
//using System.Data;
//using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;

namespace testApriori1
{

    public class ItemSet
    {
        private string items;
        private int sup;
        public string Items
        {
            get { return items; }
            set { items = value; }
        }
        public int Sup
        {
            get { return sup; }
            set { sup = value; }
        }
        public ItemSet()
        {
            items = null;
            sup = 0;
        }
    }

    public class TestApriori
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            ArrayList D = GetEventsFromDB();//event set  
            ArrayList I = GetItems1FromDB();//itemset  
            float s = 0.5f;//support threshold  

            List<ItemSet> L = new List<ItemSet>();//all frequent itemset  
            L = Apriori(D, I, s);

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            Dictionary<string, double> rules = new Dictionary<string, double>();
            for (int i = 0; i < L.Count; i++)
            {
                Console.WriteLine(L[i].Items + " support is: " + L[i].Sup);
                //Console.WriteLine(L[i].Sup);
                Regex r = new Regex(",");
                string[] subitems = r.Split(L[i].Items.ToString());
                Array.Sort(subitems);
                string temp = null;
                foreach (string subitem in subitems)
                {
                    temp = temp + subitem;
                }
           
                dictionary.Add(temp, L[i].Sup);
            }
       
            for (int i = 0; i < L.Count; i++)
            {
                string originalString = L[i].Items;
                List<string[]> subsets = CreateSubsets(originalString.Split(','));

                foreach (string[] subset in subsets)
                {
                    Array.Sort(subset);
                }
                for (int j = 0; j < subsets.Count; j++)
                {
                    for (int k = 0; k < subsets.Count; k++)
                    {
                        if (j != k)
                        {
                            bool hasSame = false;
                            foreach (string subseta in subsets[j])
                            {
                                foreach (string subsetb in subsets[k])
                                {
                                    if (subseta.Equals(subsetb))
                                    {
                                        hasSame = true;
                                        break;
                                    }
                                }
                            }
                            if (hasSame == false)
                            {
                                int valuex = dictionary[string.Join("", subsets[j])];
                                string[] subsetxy = new string[subsets[j].Length + subsets[k].Length];
                                subsets[j].CopyTo(subsetxy, 0);
                                subsets[k].CopyTo(subsetxy, subsets[j].Length);
                                Array.Sort(subsetxy);
                             
                                int valuexy = dictionary[string.Join("", subsetxy)];
                                double conf = System.Convert.ToDouble(valuexy) / System.Convert.ToDouble(valuex);
                                if (!rules.ContainsKey(string.Join(",", subsets[j]) + " -> " + string.Join(",", subsets[k])))
                                {
                                    rules.Add(string.Join(",", subsets[j]) + " -> " + string.Join(",", subsets[k]), conf);
                                    Console.WriteLine("conf for " + string.Join(",", subsets[j]) + " -> " + string.Join(",", subsets[k]) + " = " + conf);

                                }

                            }
                        }
                    }
                }
            }
            Console.WriteLine(DateTime.Now);
            Console.Read();
        }

        #region-----subset generater-----
        static List<T[]> CreateSubsets<T>(T[] originalArray)
        {
            List<T[]> subsets = new List<T[]>();

            for (int i = 0; i < originalArray.Length; i++)
            {
                int subsetCount = subsets.Count;

                subsets.Add(new T[] { originalArray[i] });

                for (int j = 0; j < subsetCount; j++)
                {
                    T[] newSubset = new T[subsets[j].Length + 1];
                    subsets[j].CopyTo(newSubset, 0);
                    newSubset[newSubset.Length - 1] = originalArray[i];

                    subsets.Add(newSubset);

                }


            }

            return subsets;
        }
        #endregion-----subset generater-----

        #region-----Apriori Recurrence-----
        static List<ItemSet> Apriori(ArrayList D, ArrayList I, float sup)
        {
            List<ItemSet> L = new List<ItemSet>();//all frequent itemset  
            if (I.Count == 0) return L;
            else
            {
                int[] Icount = new int[I.Count];  
                ArrayList Ifrequent = new ArrayList();//init the frequent itemset with 1-th frequent itemset  

                //traverse events and count  
                Regex r = new Regex(",");
                for (int i = 0; i < D.Count; i++)
                {
                    string[] subD = r.Split(D[i].ToString());
                    for (int j = 0; j < I.Count; j++)
                    {
                        string[] subI = r.Split(I[j].ToString());
                        bool subIInsubD = true;
                        for (int m = 0; m < subI.Length; m++)
                        {
                            bool subImInsubD = false;
                            for (int n = 0; n < subD.Length; n++)
                                if (subI[m] == subD[n])
                                {
                                    subImInsubD = true;
                                    continue;
                                }
                            if (subImInsubD == false) subIInsubD = false;
                        }
                        if (subIInsubD == true) Icount[j]++;
                    }
                }

                  
                for (int i = 0; i < Icount.Length; i++)
                {
                    if (Icount[i] >= sup * D.Count)
                    {
                        Ifrequent.Add(I[i]);
                        ItemSet iSet = new ItemSet();
                        iSet.Items = I[i].ToString();
                        iSet.Sup = Icount[i];
                        L.Add(iSet);
                    }
                }

                I.Clear();
                I = AprioriGen(Ifrequent);

                L.AddRange(Apriori(D, I, sup));
                return L;
            }
        }
        #endregion-----Apriori Recurrence-----

        #region-------Apriori-gen---------
        static ArrayList AprioriGen(ArrayList L)
        {
            ArrayList Lk = new ArrayList();
            Regex r = new Regex(",");
            for (int i = 0; i < L.Count; i++)
            {
                string[] subL1 = r.Split(L[i].ToString());
                for (int j = i + 1; j < L.Count; j++)
                {
                    string[] subL2 = r.Split(L[j].ToString());
                    //join sets
                    string temp = L[j].ToString();
                    for (int m = 0; m < subL1.Length; m++)
                    {
                        bool subL1mInsubL2 = false;
                        for (int n = 0; n < subL2.Length; n++)
                        {
                            if (subL1[m] == subL2[n]) subL1mInsubL2 = true;
                        }
                        if (subL1mInsubL2 == false) temp = temp + "," + subL1[m];
                    }
                    
                    string[] subTemp = r.Split(temp);
                    if (subTemp.Length == subL1.Length + 1)
                    {
                        bool isExists = false;
                        for (int m = 0; m < Lk.Count; m++)
                        {
                            bool isContained = true;
                            for (int n = 0; n < subTemp.Length; n++)
                            {
                                if (!Lk[m].ToString().Contains(subTemp[n])) isContained = false;
                            }
                            if (isContained == true) isExists = true;
                        }
                        if (isExists == false) Lk.Add(temp);
                    }

                }
            }
            return Lk;
        }
        #endregion-------Apriori-gen---------

        #region-------get items from database---------
        static ArrayList GetItems1FromDB()
        {
            ArrayList Items1 = new ArrayList();
            Items1.Add("a");
            Items1.Add("b");
            Items1.Add("c");
            Items1.Add("d");
            Items1.Add("e");
            return Items1;
        }
        #endregion-------get items from database---------

        #region-------get events from database--------
        static ArrayList GetEventsFromDB()
        {
            ArrayList events = new ArrayList();
            events.Add("a,c,d");
            events.Add("b,c,e");
            events.Add("a,b,c,e");
            events.Add("b,e");
            return events;
        }
        #endregion--------get events from database--------

    }
}