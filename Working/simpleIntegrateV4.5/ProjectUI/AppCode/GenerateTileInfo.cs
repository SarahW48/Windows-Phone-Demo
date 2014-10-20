using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTileInfo
    {
        static string[] colors = new string[8] { "red", "yellow", "orange", "magenta", "purple", "brown", "blue", "green" };
        public static int ctgrNum = 13;
        //string color;
        static string[] AppCategories = {
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games", 
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News",                                        
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation",   
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness"                                            
                                        };

        static string[] MailText = {//这个地方到时候再改成不同的说的话，第一行应该是题目，第二行是内容
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//book_reference
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//business
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//education
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//entertainment
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//government_politics
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//health_fitness
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//kids_family
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//lifestyle
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//music_video
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//news_weather
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//personal_finance
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//photo
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//social
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//sports
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//tools_productivity
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't..."//travel_navigation
                                   };

        static string[,] AppName = { // the name of each app
                                       {"Book1","Book1","Book1","Book1","Book1","Book1","Book1","Book1","Book1","Book1"},//book_reference
                                       {"Business1","Business1","Business1","Business1","Business1","Business1","Business1","Business1","Business1","Business1"},//business
                                       {"Education1","Education1","Education1","Education1","Education1","Education1","Education1","Education1","Education1","Education1"},//education
                                       {"Entertainment","Entertainment","Entertainment","Entertainment","Entertainment","Entertainment","Entertainment","Entertainment","Entertainment","Entertainment"},//entertainment
                                       {"Government_politics","Government_politics","Government_politics","Government_politics","Government_politics","Government_politics","Government_politics","Government_politics","Government_politics","Government_politics"},//government_politics
                                       {"Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness","Health_fitness"},//health_fitness
                                       {"Kids_family","Kids_family","Kids_family","Kids_family","Kids_family","Kids_family","Kids_family","Kids_family","Kids_family","Kids_family"},//kids_family
                                       {"Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle","Lifestyle"},//lifestyle
                                       {"Music_video","Music_video","Music_video","Music_video","Music_video","Music_video","Music_video","Music_video","Music_video","Music_video"},//music_video
                                       {"News_weather","News_weather","News_weather","News_weather","News_weather","News_weather","News_weather","News_weather","News_weather","News_weather"},//news_weather
                                       {"Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance","Personal_finance"},//personal_finance
                                       {"Photo","Photo","Photo","Photo","Photo","Photo","Photo","Photo","Photo","Photo"},//photo
                                       {"Social","Social","Social","Social","Social","Social","Social","Social","Social","Social"},//social
                                       {"Sports","Sports","Sports","Sports","Sports","Sports","Sports","Sports","Sports","Sports"},//sports
                                       {"Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity","Tools_productivity"},//tools_productivity
                                       {"Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation","Travel_navigation"}//travel_navigation     
                                };
        static string[] GameName = {"Angry Bird", "Blablabla", "", ""}; // the name of game category


        int randonapp;
        string path = "";
        string name = ""; // the name of the app
        double thredup = 0;
        Random random = new Random(DateTime.Now.Millisecond);

        int call_message_randindex;// = random.Next(0, 2);

        public Dictionary<int, String[]> generate(ScreenTemplate currentTemplate, int templateIndex, string color, double[,] input, string game)
        {
            call_message_randindex = random.Next(0, 2);
            int appMaxIndex = 9;
            int appNum = input.GetLength(0);
            int[] appIndex = new int[appNum];
            for (int i = 0; i < appNum; i++)
            {
                appIndex[i] = 0;
            }
            //normalize input
            double totalweight = 0;
            for (int i = 0; i < appNum; i++)
                totalweight += input[i, 1];
            for (int i = 0; i < appNum; i++)
            {
                input[i, 1] = input[i, 1] * 100 / totalweight;
                //HttpContext.Current.Response.Write(input[i, 0] + " " + input[i, 1]);//应该一个是60 一个是40
            }

            //先放large的
            //Console.WriteLine("");
            string[] tmplargepath = new string[currentTemplate.getLarge().Count];
            int largepathindex = 0;
            bool setfirst = true;
            bool setsecond = true;
            Dictionary<int, String[]> tielsInfo = new Dictionary<int, String[]>();
            foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getLarge())
            {
                if (setfirst)
                {
                    setfirst = false;
                    path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/hotmail_L.png";
                    name = "";
                    tmplargepath[largepathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",3," + name + ",";
                    Console.WriteLine(tmplargepath[largepathindex]);
                    Console.WriteLine(tmplargepath[largepathindex]);
                    largepathindex++;
                }
                else
                {
                    randonapp = random.Next(1, 99);
                    //Console.WriteLine(randonapp);
                    thredup = 0;
                    for (int i = 0; i < appNum; i++)
                    {
                        thredup += input[i, 1];
                        if (randonapp <= thredup)
                        {
                            //AppCategories[i]的第 appIndex[i]个图片
                            path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                            name = AppName[i, appIndex[i]];
                            tmplargepath[largepathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",3," + name + ",";
                            Console.WriteLine(tmplargepath[largepathindex]);
                            largepathindex++;
                            if (appIndex[i] < appMaxIndex)
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
                    if (call_message_randindex == 0)
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_M.png";
                    else
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/message_M.png";
                    name = "";
                    tmpmediumpath[mediumpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",2," + name + ",";
                    Console.WriteLine(tmpmediumpath[mediumpathindex]);
                    mediumpathindex++;
                }
                else
                {
                    randonapp = random.Next(0, 100);
                    Console.WriteLine(randonapp);
                    thredup = 0;
                    for (int i = 0; i < appNum; i++)
                    {
                        thredup += input[i, 1];
                        if (randonapp < thredup)
                        {//  AppCategories[i]的第 appIndex[i]个图片
                            path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                            name = AppName[i, appIndex[i]];
                            tmpmediumpath[mediumpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",2," + name + ",";
                            Console.WriteLine(tmpmediumpath[mediumpathindex]);
                            mediumpathindex++;
                            if (appIndex[i] < appMaxIndex)
                                appIndex[i]++;
                            break;
                        }
                    }
                }
            }

            //最后放small的//////////////////////////////////////////////////////////////////
            string[] tmpsmallpath = new string[currentTemplate.getSmall().Count];
            int smallpathindex = 0;
            int controller = 0;
            if (currentTemplate.getSmall().Count > 0)
            {

                setfirst = true;
                foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getSmall())
                {
                    if (controller == 0)
                    {
                        if (call_message_randindex == 1)
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_S.png";
                        else
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/message_S.png";
                        name = "";
                        tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                        Console.WriteLine(tmpsmallpath[smallpathindex]);
                        smallpathindex++;
                        controller++;

                    }
                    else if ((controller == 1 || controller == 2) && (game == "A" || game == "B" || game == "C" || game == "D" || game == "F" || game == "G" || game == "J" || game == "I"))//if not the oldest two
                    {
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/" + (controller - 1).ToString() + ".png";
                        name = GameName[controller - 1]; // the name of game catergory, need to be changed later
                        //name = AppName[0, appIndex[controller - 1]]; 
                        tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                        Console.WriteLine(tmpsmallpath[smallpathindex]);
                        smallpathindex++;
                        controller++;
                    }
                    
                    /*else if (setsecond)
                    {
                        setsecond = false;
                        //这个地方是要出avatar的地方
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/0.png";
                        tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1,";
                        Console.WriteLine(tmpsmallpath[smallpathindex]);
                        smallpathindex++;
                    }*/
                    else
                    {
                        randonapp = random.Next(0, 100);
                        Console.WriteLine(randonapp);
                        thredup = 0;
                        for (int i = 0; i < appNum; i++)
                        {

                            thredup += input[i, 1];
                            if (randonapp < thredup)
                            {//  AppCategories[i]的第 appIndex[i]个图片
                                path = AppCategories[i] + "/" + appIndex[i].ToString() + ".png";
                                name = AppName[i, appIndex[i]];
                                tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                                Console.WriteLine(tmpsmallpath[smallpathindex]);
                                smallpathindex++;

                                if (appIndex[i] < appMaxIndex)
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
            string[] text = { MailText[Convert.ToInt32(input[0, 0])].ToString() };
            tielsInfo.Add(3, text);
          
            return tielsInfo;
        }////////////////////////////////////end of generate



    }
}