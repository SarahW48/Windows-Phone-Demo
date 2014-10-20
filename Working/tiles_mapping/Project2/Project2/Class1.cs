using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;  

namespace Project2
{
    class Startpoint
    {
        public int x;
        public int y;
        public Startpoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class ScreenTemplate
    {
        public Dictionary<Startpoint, string> Small = new Dictionary<Startpoint, string>();
        public Dictionary<Startpoint, string> Medium = new Dictionary<Startpoint, string>();
        public Dictionary<Startpoint, string> Large = new Dictionary<Startpoint, string>();
        public ScreenTemplate(string Small, string Medium, string Large)
        {
            int x, y;
            Regex rspace = new Regex(" ");
            Regex rcomma = new Regex(",");

            string[] subSmalls = rspace.Split(Small);
            foreach (string subSmall in subSmalls)
            {
                string[] point = rcomma.Split(subSmall);
                x = Convert.ToInt32(point[0]);
                y = Convert.ToInt32(point[1]);
                this.Small.Add(new Startpoint(x, y), "");
                Console.WriteLine("S " + x + " " + y);
            }

            string[] subMediums = rspace.Split(Medium);
            foreach (string subMedium in subMediums)
            {
                string[] point = rcomma.Split(subMedium);
                x = Convert.ToInt32(point[0]);
                y = Convert.ToInt32(point[1]);
                this.Medium.Add(new Startpoint(x, y), "");
                Console.WriteLine("M " + x + " " + y);
            }

            string[] subLarges = rspace.Split(Large);
            foreach (string subLarge in subLarges)
            {
                string[] point = rcomma.Split(subLarge);
                x = Convert.ToInt32(point[0]);
                y = Convert.ToInt32(point[1]);
                this.Large.Add(new Startpoint(x, y), "");
                Console.WriteLine("L " + x + " " + y);
            }
        }
    }
    class Class1
    {
        static string[] AppCategories = {
                                            "entertainment", 
                                            "music_video",
                                            "tools_productivity",
                                            "lifestyle",
                                            "kids_family",
                                            "news_weather",
                                            "travel_navigation",
                                            "health_fitness",
                                            "photo",
                                            "social",
                                            "sports",
                                            "personal_finance",
                                            "business",
                                            "books_reference",
                                            "education",
                                            "government_politics"
                                        };

        static string[] colors = new string[8] { "red", "yellow", "orange", "magenta", "purple", "brown", "blue", "green" };

        static void Main(string[] args)
        {
            int i;
            Random random = new Random(DateTime.Now.Millisecond);
            int[] appIndex = new int[16];
            for(i=0;i<16;i++){
                appIndex[i]=0;
            }
            int colorindex = random.Next(0, 8);
            Console.WriteLine(">>>>"+colorindex);
            //创建template的办法 template的坐标需要手动输入
            Dictionary<int,ScreenTemplate> templates=new Dictionary<int,ScreenTemplate>();
            string Small = "";
            string Medium = "";
            string Large = "";



            Small = "1,2 3,4 5,6 7,8";
            Medium = "5,6 7,8 9,0";
            Large = "2,3 5,7 8,3";
            ScreenTemplate template0= new ScreenTemplate(Small,Medium,Large);
            templates.Add(0,template0);


            Small = "2,2 2,2 2,2 2,2";
            Medium = "5,6 7,8 9,0";
            Large = "2,3 5,7 8,3";
            ScreenTemplate template1= new ScreenTemplate(Small,Medium,Large);
            templates.Add(1,template1);

            //这儿是input 值设置为薇薇传过来的数
            int[,] input = { { 0, 30 }, { 1, 20 }};
            
            
            //计算百分比
            int totalweight = 0;
            for (i = 0; i < input.Length / 2;i++ )
                totalweight+=input[i,1];
            for (i = 0; i < input.Length / 2; i++)
            {
                input[i, 1] = input[i, 1] * 100 / totalweight;
                Console.WriteLine(i + " " + input[i, 1]);//应该一个是60 一个是40
            }
            

            //随机出来一个模板（现在设置为随机）
            int templateIndex = random.Next(0, templates.Count());//随机一个0到2之间的数，不包括2
            Console.WriteLine(templateIndex);
            //往模板里面放图
            int randonapp;
            string path = "";
            int thredup = 0;
            if (templates.ContainsKey(templateIndex))
            {
                ScreenTemplate currentTemplate = templates[templateIndex];
                //先放large的
                Console.WriteLine("");
                string[] tmplargepath = new string[currentTemplate.Large.Count];
                int largepathindex = 0;
                bool setfirst = true;
                foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.Large)
                {
                    if (setfirst)
                    {
                        setfirst=false;
                        path = "/mail_large.png";
                        tmplargepath[largepathindex] = "\""+path+"\","+colors[colorindex]+","+ pair.Key.x + "," + pair.Key.y + ",3";
                         Console.WriteLine(tmplargepath[largepathindex]);
                            largepathindex++;
                    }
                    else
                    {
                        randonapp = random.Next(0, 100);
                        Console.WriteLine(randonapp);
                        thredup = 0;
                        for (i = 0; i < input.Length / 2; i++)
                        {
                            thredup += input[i, 1];
                            if (randonapp < thredup)
                            {//  AppCategories[i]的第 appIndex[i]个图片
                                path = AppCategories[i] + "/" + appIndex[i].ToString() + "_large.png";
                                tmplargepath[largepathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",3";
                                Console.WriteLine(tmplargepath[largepathindex]);
                                largepathindex++;
                                appIndex[i]++;
                                break;
                            }
                        }
                    }
                }

                //第二个放medium的
                Console.WriteLine("");
                string[] tmpmediumpath = new string[currentTemplate.Medium.Count];
                int mediumpathindex = 0;
                setfirst = true;
                foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.Medium)
                {
                    if (setfirst)
                    {
                        setfirst = false;
                        path = "/call_medium.png";
                        tmpmediumpath[mediumpathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",2";
                        Console.WriteLine(tmpmediumpath[mediumpathindex]);
                        mediumpathindex++;
                    }
                    else
                    {
                        randonapp = random.Next(0, 100);
                        Console.WriteLine(randonapp);
                        thredup = 0;
                        for (i = 0; i < input.Length / 2; i++)
                        {
                            thredup += input[i, 1];
                            if (randonapp < thredup)
                            {//  AppCategories[i]的第 appIndex[i]个图片
                                path = AppCategories[i] + "/" + appIndex[i].ToString() + "_medium.png";
                                tmpmediumpath[mediumpathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",2";
                                Console.WriteLine(tmpmediumpath[mediumpathindex]);
                                mediumpathindex++;
                                appIndex[i]++;
                                break;
                            }
                        }
                    }
                }
                //最后放small的
                Console.WriteLine("");
                string[] tmpsmallpath = new string[currentTemplate.Small.Count];
                int smallpathindex=0;
                setfirst = true;
                foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.Small)
                {
                    if (setfirst)
                    {
                        setfirst = false;
                        path = "/message_small.png";
                        tmpsmallpath[smallpathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1";
                        Console.WriteLine(tmpsmallpath[smallpathindex]);
                        smallpathindex++;
                    }
                    else
                    {
                        randonapp = random.Next(0, 100);
                        Console.WriteLine(randonapp);
                        thredup = 0;
                        for (i = 0; i < input.Length / 2; i++)
                        {
                            if (setfirst)
                            {
                                setfirst = false;
                                path = "/message_small.png";
                                tmpsmallpath[smallpathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1";
                                Console.WriteLine(tmpsmallpath[smallpathindex]);
                                smallpathindex++;
                            }
                            else
                            {
                                thredup += input[i, 1];
                                if (randonapp < thredup)
                                {//  AppCategories[i]的第 appIndex[i]个图片
                                    path = AppCategories[i] + "/" + appIndex[i].ToString() + "_small.png";
                                    tmpsmallpath[smallpathindex] = "\"" + path + "\"," + colors[colorindex] + "," + pair.Key.x + "," + pair.Key.y + ",1";
                                    Console.WriteLine(tmpsmallpath[smallpathindex]);
                                    smallpathindex++;

                                    appIndex[i]++;
                                    break;
                                }
                            }
                        }
                    }
                }


                //显示的部分
                Console.WriteLine("display!!!");
                for (i = 0; i < currentTemplate.Large.Count; i++)
                    Console.WriteLine(tmplargepath[i]);
                for (i = 0; i < currentTemplate.Medium.Count; i++)
                    Console.WriteLine(tmpmediumpath[i]);
                for (i = 0; i < currentTemplate.Small.Count; i++)
                    Console.WriteLine(tmpsmallpath[i]);


                


            }
            else
                Console.WriteLine("no template for " + templateIndex);
        
           
            
            
            Console.Read();
        }

    }
}
