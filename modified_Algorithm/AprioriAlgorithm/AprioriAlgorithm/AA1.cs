
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;
using MySql.Data.MySqlClient;


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
        
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
           
            Console.WriteLine(DateTime.Now);
  
                            ArrayList D = new ArrayList();
                            ArrayList I = new ArrayList();
                            ConnectToSQL(D, I);
                            float s = 0.0f;//support threshold  

                            List<ItemSet> L = new List<ItemSet>();//all frequent Itemset  
                            L = Apriori(D, I, s);

                            Dictionary<string, int> dictionary = new Dictionary<string, int>();
                            Dictionary<string, double> rules = new Dictionary<string, double>();

                            Console.WriteLine("*************************************");
                            Console.WriteLine("       Itemset Support Value:        ");
                            Console.WriteLine("*************************************");
                            for (int i = 0; i < L.Count; i++)
                            {
                                Console.WriteLine(L[i].Items+ " support is: " + L[i].Sup);
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
            string[] picseries={
            "COL_1_1*", "COL_1_2*", 
            "COL_2_-1*", "COL_2_1*","COL_2_2*","COL_2_3*","COL_2_4*","COL_2_5*","COL_2_6*","COL_2_7*","COL_2_8*","COL_2_9*","COL_2_10*","COL_2_11*","COL_2_12*","COL_2_13*","COL_2_14*",
            "COL_3_-1*","COL_3_1*","COL_3_2*","COL_3_3*","COL_3_4*","COL_3_5*","COL_3_6*",
            "COL_4_1*","COL_4_2*","COL_4_3*","COL_4_4*",
            "COL_5_1*","COL_5_2*",
            "COL_6_1*","COL_6_2*",
            "COL_7_1*","COL_7_2*","COL_7_3*","COL_7_4*",
            "COL_8_1*","COL_8_2*","COL_8_3*","COL_8_4*","COL_8_5*","COL_8_6*","COL_8_7*",
            "COL_9_1*","COL_9_2*","COL_9_3*","COL_9_4*",
            "COL_10_1*","COL_10_2*",
            "COL_11_1*","COL_11_2*",
            "COL_12_1*","COL_12_2*",
            "COL_13_1*","COL_13_2*",
            "COL_14_1*","COL_14_2*",
            "COL_15_1*","COL_15_2*","COL_15_3*","COL_15_4*","COL_15_5*","COL_15_6*","COL_15_7*",
            "COL_16_1*","COL_16_2*","COL_16_3*",
            "COL_17_1*","COL_17_2*",
            "COL_18_1*","COL_18_2*",
            "COL_19_1*","COL_19_2*",
            "COL_20_1*","COL_20_2*",
            "COL_21_1*","COL_21_2*",
            "COL_22_1*","COL_22_2*","COL_22_3*","COL_22_4*","COL_22_5*","COL_22_6*","COL_22_7*","COL_22_8*",
            "COL_23_1*","COL_23_2*",
            "COL_24_1*","COL_24_2*","COL_24_3*","COL_24_4*","COL_24_5*",
            "COL_25_1*","COL_25_2*","COL_25_3*",
            "COL_26_1*","COL_26_2*","COL_26_3*","COL_26_4*",
            "COL_27_1*","COL_27_2*",
            "COL_28_1*","COL_28_2*",
            "COL_29_1*","COL_29_2*"
            };
            string[] appseries ={
                 "AppCategory_30_1*", "AppCategory_30_2*", "AppCategory_30_3*", "AppCategory_30_4*",
                 "AppCategory_30_5*","AppCategory_31_1*", "AppCategory_31_2*", "AppCategory_31_3*", 
                 "AppCategory_31_4*", "AppCategory_31_5*","AppCategory_31_6*", "AppCategory_31_7*"
                                };

            double[,] RawWeight = new double[picseries.Length, appseries.Length];
        
            for (int i = 0; i <picseries.Length ; i++)
            {
                if (dictionary.ContainsKey(picseries[i]))
                {
                    int value = dictionary[picseries[i]];
                    for (int j = 0; j < appseries.Length; j++)
                    {
                            if (dictionary.ContainsKey(picseries[i] + appseries[j]))
                            {
                                int tmp = dictionary[picseries[i] + appseries[j]];
                                double outvalue = Convert.ToDouble(tmp) / Convert.ToDouble(value);
                                RawWeight[i, j] = Math.Round(outvalue, 2);
                                         
                            }
                            else if (dictionary.ContainsKey(appseries[j] + picseries[i]))
                            {
                                int tmp = dictionary[appseries[j] + picseries[i]];
                                double outvalue = Convert.ToDouble(tmp) / Convert.ToDouble(value);
                                RawWeight[i, j] = Math.Round(outvalue, 2);
                            }
                            else
                            {
                                RawWeight[i, j] = 0;
                            }
                    }
                }
                else
                {
                    for (int j = 0; j <  appseries.Length; j++)
                    {
                        RawWeight[i, j] = 0;
                    }        
                }
                     
            }
                     
            double threshold = 0.35f;
            double smallestAverageOfPopular = 100;
            double smallestAverageOfUnPopular = 100;
                        double[] average = new double[12]; 
            for (int i = 0; i < appseries.Length; i++)
            {
                double total = 0;
                for (int j = 0; j < picseries.Length; j++)
                {
                    if ((j < 17) || (j > 23 && j < 28) || (j > 29 && j < picseries.Length-10))//some questions we decided not to use
                    {
                        total += RawWeight[j, i];
                    }
                }
  
                average[i]=total/90;
                if(i < 5 &&  average[i] < smallestAverageOfPopular)
                    smallestAverageOfPopular =  average[i];
                if(i >= 5 &&  average[i] < smallestAverageOfUnPopular)
                    smallestAverageOfUnPopular =  average[i];
        
            }
            for (int i = 0; i < appseries.Length; i++)
            {
                for (int j = 0; j < picseries.Length; j++)
                {
                    if (RawWeight[j, i] != 0)
                    {
                        RawWeight[j, i] = (RawWeight[j, i] - average[i]) / average[i];
                        if (Math.Abs(RawWeight[j, i]) > threshold)
                        {

                            if (RawWeight[j, i] > average[i])
                                RawWeight[j, i] = average[i];
                            else
                                RawWeight[j, i] = (i < 5 ? smallestAverageOfPopular : smallestAverageOfUnPopular) * -1;

                        }
                        else RawWeight[j, i] = 0;
                    }
                }
            }

            for (int i = 0; i < picseries.Length; i++)
            {
                Console.Write(  String.Format("{0,15}", picseries[i]+"{"));
                for (int j = 0; j < appseries.Length; j++)
                    Console.Write(String.Format("{0,8}", (Math.Round(RawWeight[i, j], 2).ToString() + ",")));
                Console.WriteLine("}");
  
            }
            Console.WriteLine("\n");

       

        //following is original how we could get all the rules. For our project, we don't need that
        /*
                  Console.WriteLine("*************************************");
                  Console.WriteLine("          Strong Rules:              ");
                  Console.WriteLine("*************************************");
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
                                        // Console.WriteLine("conf for " + string.Join(",", subsets[j]) + " -> " + string.Join(",", subsets[k]) + " = " + conf);
                                        if (conf >= 0.75)
                                        {
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
                    }
             */
        Console.WriteLine(DateTime.Now);

                      Console.SetOut(oldOut);
                      writer.Close();
                      ostrm.Close();
                      Console.WriteLine("Done");
                Console.Read();
 
        }

   #region-----Subsets Creater-----
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
   #endregion-----Subsets Creater-----

   #region-----Apriori recurrence-----
   static List<ItemSet> Apriori(ArrayList D, ArrayList I, float sup)
   {
       List<ItemSet> L = new List<ItemSet>();//all frequent Itemset 
       if (I.Count == 0) return L;
       else
       {
           int[] Icount = new int[I.Count]; 
           ArrayList Ifrequent = new ArrayList();//init frequent Itemset

           //traverse and count  
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

           //add itemset beyond threshold  
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
           Console.WriteLine("L.Count!=" + Ifrequent.Count);
           L.AddRange(Apriori(D, I, sup));
           return L;
       }
   }
   #endregion-----Apriori recurrence-----

   #region-------Apriori-gen generate k-frequent Itemset---------
   static ArrayList AprioriGen(ArrayList L)
   {

       ArrayList Lk = new ArrayList();
       Regex r = new Regex(",");
       if (L.Count < 2000)//in this project we only consider relations betweem two items, <one picture, one appcategory>
       {
           for (int i = 0; i < L.Count; i++)
           {

               string[] subL1 = r.Split(L[i].ToString());
               for (int j = i + 1; j < L.Count; j++)
               {
                   string[] subL2 = r.Split(L[j].ToString());
                  
                        //get the join of two sets
                       string temp = L[j].ToString();
                       for (int m = 0; m < subL1.Length; m++)
                       {
                           bool subL1mInsubL2 = false;
                           for (int n = 0; n < subL2.Length; n++)
                           {
                               if (subL1[m] == subL2[n])
                               {
                                   subL1mInsubL2 = true;
                               }
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
       }
       return Lk;
   }
   #endregion-------Apriori-gen generate k-frequent Itemset---------

   #region--------Set Eventset and 1-frequent Itemset from db--------
   static void ConnectToSQL(ArrayList D, ArrayList I)
   {
            string connectionString = "server=localhost;database=csv_db;uid=nmao;pwd=1234";
            MySqlConnection sqlCon = new MySqlConnection(connectionString);
            sqlCon.Open();

            //string selectString = "SELECT * FROM nmaotest ";
            string selectString = "SELECT * FROM `table 10`";
            MySqlCommand sqlCmd = sqlCon.CreateCommand();

            sqlCmd.CommandText = selectString;

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();
            mySqlDataAdapter.SelectCommand = sqlCmd;

            DataSet myDataSet = new DataSet();


            Console.WriteLine("*************************************");
            Console.WriteLine("       Entrys from DB :              ");
            Console.WriteLine("*************************************");
            //string dataTableName = "nmaotest";
            string dataTableName = "table 10";
            mySqlDataAdapter.Fill(myDataSet, dataTableName);

            DataTable myDataTable = myDataSet.Tables[dataTableName];

            Regex r = new Regex("|");
       
            for (int i = 0; i < myDataTable.Rows.Count; i++)
            {
                string eventtmp = "";
                string tmp;


                for (int j = 1; j < 30; j++)
                {
                   
                        string colname = "COL ";
                        colname += j.ToString();
                        string picname = "COL_";
                        picname += j.ToString();
                        tmp = picname + "_";
                        if (myDataTable.Rows[i][colname] == "")
                        {
                            if (j == 13)
                                tmp = tmp + "2"+"*";
                            else
                                tmp = tmp + "*"+"*";
                        }
                        else
                            tmp = tmp + myDataTable.Rows[i][colname]+"*";
                     
                        eventtmp += tmp;
                        if (!I.Contains(tmp))
                        {
                            if (j == 13 || myDataTable.Rows[i][colname] != "") I.Add(tmp);

                        }
                        eventtmp += ",";
                   
                }
                for (int j = 30; j < 32; j++)
                {
                    string colname = "COL ";
                    colname += j.ToString();
                    string picname = "AppCategory_";
                    picname += j.ToString();
                    tmp = picname + "_";
                    if (myDataTable.Rows[i][colname] == "")
                    {
                            tmp = tmp + "*"+"*";
                    }
                    else
                        tmp = tmp + myDataTable.Rows[i][colname]+"*";
              
                    eventtmp += tmp;
              
                    if (!I.Contains(tmp))
                    {
                        if (myDataTable.Rows[i][colname] != "")
                        I.Add(tmp);
                    }
                    eventtmp += ",";
                }
                string[] subshorts = r.Split(myDataTable.Rows[i]["COL 32"].ToString());
                for (int m = 0; m < subshorts.Length-1; m++)
                {
                    if (subshorts[m] != "" && subshorts[m] != "|")
                    {
                        tmp = "AppCategory_32_" + subshorts[m] + "*";
                       
                        eventtmp += tmp;
                        if (!I.Contains(tmp)) I.Add(tmp);
                        eventtmp += ",";
                    }
                }
                D.Add(eventtmp);
                Console.WriteLine("Entry[" + i + "]:" + eventtmp);
            }
            
            sqlCon.Close();
        }
        #endregion--------Set Eventset and 1-frequent Itemset from db--------

    }
}
