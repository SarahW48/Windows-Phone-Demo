/* Summary: 
 * the class is getting the information (strings) from GenerateTileInfo.cs
 * extract data from it and use them to gemerate tile objects
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTiles
    {
        public Tile[] generateTile(Dictionary<int, String[]> info, string name1, string name2)
        {
            int pic_cnt = 0; // picid for animation
            string[] large = info[0];
            string[] medium = info[1];
            string[] small = info[2];
            string[] text = info[3];
            Tile[] tiles;
            if (small != null)
            {
                tiles = new Tile[large.Length + medium.Length + small.Length];
            }
            else
            {
                tiles = new Tile[large.Length + medium.Length];
            }
            // Fill information to generate tiles
            for (int j = 0; j < large.Length; j++)
            {
               if ((CutString(large[j])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/hotmail_L.png") || (CutString(large[j])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png") || (CutString(large[j])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png") || (CutString(large[j])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png"))
                {
                    tiles[j] = new Tile(CutString(large[j])[0],
                                   CutString(large[j])[1],
                                   CutString(large[j])[2],
                                   CutString(large[j])[3],
                                   CutString(large[j])[4],
                                   name1, name2, text[0], "0l", CutString(large[j])[5]);
                }
                else
                {
                    pic_cnt++;
                    tiles[j] = new Tile(CutString(large[j])[0],
                                    CutString(large[j])[1],
                                    CutString(large[j])[2],
                                    CutString(large[j])[3],
                                    CutString(large[j])[4],
                                    null, null, null, Convert.ToString(pic_cnt), CutString(large[j])[5]);
                }
            }
            int index = 0;
            for (int j = large.Length; j < large.Length + medium.Length; j++)
            {
                if (CutString(medium[index])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/contact.png")
                {
                    pic_cnt++;
                    tiles[j] = new Tile(CutString(medium[index])[0],
                                CutString(medium[index])[1],
                                CutString(medium[index])[2],
                                CutString(medium[index])[3],
                                CutString(medium[index])[4],
                                null, name2, null, Convert.ToString(pic_cnt), CutString(medium[index])[0]);

                }
                else
                {
                pic_cnt++;
                tiles[j] = new Tile(CutString(medium[index])[0],
                                CutString(medium[index])[1],
                                CutString(medium[index])[2],
                                CutString(medium[index])[3],
                                CutString(medium[index])[4],
                                null, null, null, Convert.ToString(pic_cnt), CutString(medium[index])[5]);
                }
                index++;
            }
            index = 0;
            if (small != null)
            {
                for (int j = large.Length + medium.Length; j < large.Length + medium.Length + small.Length; j++)
                {
                    if (CutString(small[index])[0] == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_S.png")
                    {
                        tiles[j] = new Tile(CutString(small[index])[0],
                                        CutString(small[index])[1],
                                        CutString(small[index])[2],
                                        CutString(small[index])[3],
                                         CutString(small[index])[4],
                                         null, null, null, "0s", CutString(small[index])[0]);

                    }
                    else
                    {
				    pic_cnt++;
                    tiles[j] = new Tile(CutString(small[index])[0],
                                        CutString(small[index])[1],
                                        CutString(small[index])[2],
                                        CutString(small[index])[3],
                                         CutString(small[index])[4],
                                         null, null, null, Convert.ToString(pic_cnt), CutString(small[index])[5]);
                    }
                    index++;
                  
                }
            }
            return tiles;
        }
        /* Cut the information string into tile attributes */
        /*including path, the startpoint of the tile, size, name*/
        private static string[] CutString(string Input_Stri)
        {
            int endpoint = 0;
            int countlength = 0;
            string[] Output_Stri = new string[6];
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