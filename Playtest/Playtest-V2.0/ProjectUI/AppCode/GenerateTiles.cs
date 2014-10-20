﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTiles
    {
        public Tile[] generateTile(Dictionary<int, String[]> info, string name1, string name2)
        {
            string[] large = info[0];
            string[] medium = info[1];
            string[] small = info[2];
            string[] text = info[3];
            //HttpContext.Current.Response.Write(text[0]);

            Tile[] tiles;
            if (small != null)
            {
                tiles = new Tile[large.Length + medium.Length + small.Length];
            }
            else
            {
                tiles = new Tile[large.Length + medium.Length];
            }
            //Console.WriteLine("");
            for (int j = 0; j < large.Length; j++)
            {
                if (null == large[j])
                    continue;
                if (CutString(large[j])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/hotmail_L.png")
                {
                    tiles[j] = new Tile(CutString(large[j])[0],
                                   CutString(large[j])[1],
                                   CutString(large[j])[2],
                                   CutString(large[j])[3],
                                   CutString(large[j])[4],
                                   name1, name2, text[0]);
                }
                else
                {
                    tiles[j] = new Tile(CutString(large[j])[0],
                                    CutString(large[j])[1],
                                    CutString(large[j])[2],
                                    CutString(large[j])[3],
                                    CutString(large[j])[4],
                                    null, null, null);
                }
            }
            int index = 0;
            for (int j = large.Length; j < large.Length + medium.Length; j++)
            {
                if (null == medium[index])
                    continue;
                tiles[j] = new Tile(CutString(medium[index])[0],
                                CutString(medium[index])[1],
                                CutString(medium[index])[2],
                                CutString(medium[index])[3],
                                CutString(medium[index])[4],
                                null, null, null);
                index++;
            }
            index = 0;
            if (small != null)
            {
                for (int j = large.Length + medium.Length; j < large.Length + medium.Length + small.Length; j++)
                {
                    if (null == small[index])
                        continue;
                    tiles[j] = new Tile(CutString(small[index])[0],
                                        CutString(small[index])[1],
                                        CutString(small[index])[2],
                                        CutString(small[index])[3],
                                         CutString(small[index])[4],
                                         null, null, null);
                    index++;
                    //Response.Write("<img src='" + CutString(tmpsmallpath[j])[0] + "' style=' background-color:" + CutString(tmpsmallpath[j])[1] + ";position:absolute; left:" + CutString(tmpsmallpath[j])[2] + "; top:" + CutString(tmpsmallpath[j])[3] + "; width:" + CutString(tmpsmallpath[j])[4] + "; length:" + CutString(tmpsmallpath[j])[0] + ";'/>");
                }
            }
            return tiles;
        }

        private static string[] CutString(string Input_Stri)
        {
            if (null == Input_Stri)
            {
                throw new Exception("Null input in CutString!"); ;
            }
            int endpoint = 0;
            int countlength = 0;
            string[] Output_Stri = new string[5];
            char[] Inputarray = Input_Stri.ToCharArray();
            for (int j = 0; j < Output_Stri.Length; j++)
            {
                for (int i = endpoint; i < Input_Stri.Length; i++)
                {
                    countlength++;
                    if (Inputarray[i] == ',')
                    {
                        Output_Stri[j] = Input_Stri.Substring(endpoint, countlength - 1);
                        Output_Stri[j] = Output_Stri[j].Trim();
                        countlength = 0;
                        endpoint = i + 1;
                        break;
                    }
                }
            }
            return Output_Stri;
        }
    }
}