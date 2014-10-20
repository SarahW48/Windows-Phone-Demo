using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTileInfo
    {
        static string[] colors = new string[8] { "red", "yellow", "orange", "magenta", "purple", "brown", "blue", "green" };

        static string[] AppCategories = { "images/tiles/book_reference", 
                                            "images/tiles/business",
                                            "images/tiles/education",
                                            "images/tiles/entertainment",
                                            "images/tiles/government_politics",                                        
                                            "images/tiles/health_fitness",
                                            "images/tiles/kids_family",
                                            "images/tiles/lifestyle",
                                            "images/tiles/music_video",
                                            "images/tiles/news_weather",
                                            "images/tiles/personal finance",
                                            "images/tiles/photo",
                                            "images/tiles/social",
                                            "images/tiles/sports",
                                            "images/tiles/tools_productivity",   
                                            "images/tiles/travel_navigation"    


                                   
                                        };

        static string[] MailText = {//这个地方到时候再改成不同的说的话，第一行应该是题目，第二行是内容
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//book_reference
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//business
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//education
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//entertainment
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//government_politics
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//health_fitness
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//kids_family
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//lifestyle
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//music_video
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//news_weather
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//personal_finance
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//photo
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//social
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//sports
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't...",//tools_productivity
                                       "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't..."//travel_navigation
                                   };
        int randonapp;
        string path = "";
        double thredup = 0;
        Random random = new Random(DateTime.Now.Millisecond);

        int call_message_randindex;// = random.Next(0, 2);

        public Dictionary<int, String[]> generate(ScreenTemplate currentTemplate, int templateIndex, int colorindex, double[,] input)
        {
            call_message_randindex = random.Next(0, 2);
            int[] appIndex = new int[16];///16???
            for (int i = 0; i < 16; i++)
            {
                appIndex[i] = 0;
            }
            //normalize input
            double totalweight = 0;
            for (int i = 0; i < input.Length / 2; i++)
                totalweight += input[i, 1];
            for (int i = 0; i < input.Length / 2; i++)
            {
                input[i, 1] = input[i, 1] * 100 / totalweight;
                //HttpContext.Current.Response.Write(input[i, 0] + " " + input[i, 1]);//应该一个是60 一个是40
            }
            
            //先放large的
            Console.WriteLine("");
            string[] tmplargepath = new string[currentTemplate.getLarge().Count];
            int largepathindex = 0;
            bool setfirst = true;
            bool setsecond = true;
            Dictionary<int,String[]> tielsInfo = new Dictionary<int, String[]>();
            foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getLarge())
            {
                if (setfirst)
                {
                    setfirst=false;
                    path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/mail_L.png";
                    tmplargepath[largepathindex] = path+","+colors[colorindex]+","+ pair.Key.x + "," + pair.Key.y + ",3,";
                    Console.WriteLine(tmplargepath[largepathindex]);                    
                    Console.WriteLine(tmplargepath[largepathindex]);
                    largepathindex++;
                 }
                 else
                 {
                     randonapp = random.Next(1, 99);
                     Console.WriteLine(randonapp);
                     thredup = 0;
                     for (int i = 0; i < input.Length / 2; i++)
                     {
                        thredup += input[i, 1];
                        if (randonapp <= thredup)
                        {
                            //AppCategories[i]的第 appIndex[i]个图片
                            path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                            tmplargepath[largepathindex] = path + ","  + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",3,";
                                Console.WriteLine(tmplargepath[largepathindex]);
                                largepathindex++;
                                appIndex[i]++;
                                break;
                            }
                        }
                    }
                }

                //第二个放medium的////////////////////////////////////////////////////
                Console.WriteLine("");
                string[] tmpmediumpath = new string[currentTemplate.getMedium().Count];
                int mediumpathindex = 0;
                setfirst = true;
                foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getMedium())
                {
                    if (setfirst)
                    {
                        setfirst = false;
                        if(call_message_randindex == 0)
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/call_M.png";
                        else
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/message_M.png";
                        tmpmediumpath[mediumpathindex] = path+","  + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",2,";
                        Console.WriteLine(tmpmediumpath[mediumpathindex]);
                        mediumpathindex++;
                    }
                    else
                    {
                        randonapp = random.Next(0, 100);
                        Console.WriteLine(randonapp);
                        thredup = 0;
                        for (int i = 0; i < input.Length / 2; i++)
                        {
                            thredup += input[i, 1];
                            if (randonapp < thredup)
                            {//  AppCategories[i]的第 appIndex[i]个图片
                                path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                                tmpmediumpath[mediumpathindex] = path + "," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",2,";
                                Console.WriteLine(tmpmediumpath[mediumpathindex]);
                                mediumpathindex++;
                                appIndex[i]++;
                                break;
                            }
                        }
                    }
                }

                //最后放small的//////////////////////////////////////////////////////////////////
                string[] tmpsmallpath = new string[currentTemplate.getSmall().Count];
                int smallpathindex = 0;
                if (currentTemplate.getSmall().Count > 0)
                {

                    setfirst = true;
                    foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getSmall())
                    {
                        if (setfirst)
                        {
                            setfirst = false;
                            if (call_message_randindex == 1)
                                path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/call_S.png";
                            else
                                path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/message_S.png";
                            tmpsmallpath[smallpathindex] = path + "," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1,";
                            Console.WriteLine(tmpsmallpath[smallpathindex]);
                            smallpathindex++;

                        }
                        else if(setsecond)
                        {
                            setsecond = false;
                            //这个地方是要出avatar的地方
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/photo/9.png";
                            tmpsmallpath[smallpathindex] = path + "," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1,";
                            Console.WriteLine(tmpsmallpath[smallpathindex]);
                            smallpathindex++;
                        }
                        else
                        {
                            randonapp = random.Next(0, 100);
                            Console.WriteLine(randonapp);
                            thredup = 0;
                            for (int i = 0; i < input.Length / 2; i++)
                            {
                                
                                    thredup += input[i, 1];
                                    if (randonapp < thredup)
                                    {//  AppCategories[i]的第 appIndex[i]个图片
                                        path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                                        tmpsmallpath[smallpathindex] = path + "," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1,";
                                        Console.WriteLine(tmpsmallpath[smallpathindex]);
                                        smallpathindex++;

                                        appIndex[i]++;
                                        break;
                                    }
                                
                            }
                        }
                    }
                }
                tielsInfo.Add(0, tmplargepath);
                tielsInfo.Add(1, tmpmediumpath);
                if (currentTemplate.getSmall().Count > 0)
                {
                    tielsInfo.Add(2, tmpsmallpath);
                }
                else
                {
                    tielsInfo.Add(2, null);
                }
                //string[] text = { "RE:Let's go see a movie this weekend?<font size=\"1\" color=\"white\"><br>Sound's like a good plan to me. I don't..." };
                string[] text ={MailText[Convert.ToInt32(input[0, 0])].ToString()};
                tielsInfo.Add(3, text);
                return tielsInfo;
        }////////////////////////////////////end of generate



    }
}