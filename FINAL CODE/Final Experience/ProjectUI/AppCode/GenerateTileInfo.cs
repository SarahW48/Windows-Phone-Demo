/* Summary: 
 * this calss is taking the information about template, 
 * weight caculated for every category (only two categories selected)
 * color 
 * family element and generated tiles for the given template
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTileInfo
    {
        public static int ctgrNum = 12;//we have totally 12 categories of apps
        public int popularIndexr = 0;
        public int nonpopularIndex = 0;
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
                                            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation"                                               
                                        };
        static string[] MailText = {
                                       "<font size=\"1\" color=\"white\">RE:Check this deal for Xbox!         <br>Just ordered one! Let's have some fun ...", //Games
                                       "<font size=\"1\" color=\"white\">RE:Let's go to this concert!         <br>Sound's like a good plan to me. I don't...",//Music
                                       "<font size=\"1\" color=\"white\">RE:Let's go see a movie this weekend?<br>Sound's like a good plan to me. I don't...",//Video&Movie
                                       "<font size=\"1\" color=\"white\">Here are the photo!                  <br>Just got my computer. There are also ...",  //Camera&Photo
                                       "<font size=\"1\" color=\"white\">RE:Fwd:[CNN NEWS]Many issues same ...<br>I got that too... Well, as far as I know,", //News
                                       "<font size=\"1\" color=\"white\">Fwd:Green's 3-pointer pushes Spurs...<br>Hey! Check this out! LOS ANGELES (AP) —...",//Sports
                                       "<font size=\"1\" color=\"white\">Fwd:Your Shipping Confirmation       <br>Your Shipping Confirmation! View this ... ",//Shopping&Finance
                                       "<font size=\"1\" color=\"white\">Do you want to go for the party ...  <br>Sarah just told me there is a party at ...",//Social
                                       "<font size=\"1\" color=\"white\">Fwd:50% Off Beer Nutz Bottle Shoppe...<br>$30 to Spend on Wings, Burgers, and ...",  //Food&Restaurants
                                       "<font size=\"1\" color=\"white\">Fwd:Save up to 40% on the Best Books...<br>Picking the best of anything is always...",//Books&Refernce
                                       "<font size=\"1\" color=\"white\">RE:Where did you get those folders?  <br>Forgot the name. But I am pretty sure that...",//Organization
                                       "<font size=\"1\" color=\"white\">Fwd:SuperShuttle Reservation Confirm...<br>The following information summarizes ...",//Travel&Navigation
                                       "<font size=\"1\" color=\"white\">Another round this weekend?          <br>The park is holding it again this weekend...",//Fitness
                                   };
        static string[,] AppName = { // the name of each app
                                       {"","Doodle jump","Angry birds","Fruit Ninja","Plants vs. Zombies","iStunt 2","The Sims 3","MONOPOLY","Uno","Flow Free","Halo Waypoint","Halo Waypoint"},//Games
                                       {"","Free Music Downloader","Free Ringtones","Shazam","iHeartRadio","Last.fm","Guitar Hero 5","OpenMic","BeatBox Free","MP3 Downloader","Mixtapes","Accurate Tuner Free"},//Music
                                       {"YouTube","Netflix","IMDb","Flixster","Vimeo","AMC Theatres","FlashVideo+TubeMusic","VLC play!","YouTube Downloader","onePlayer","Movie Vault - Classic Films",""},//Video&Movie
                                       {"","Phototastic Free","Lomogram","Fhotoroom","Custom Effects","InstaCam","Photo Studio","Bing Wallpaper","EasyEffects","Photo Editor+","3D Photo Maker","Pictures Lab"},//Camera&Photo
                                       {"CNN","USA TODAY","BBC News Mobile","NEWS","Fox News","ABC News","News Channels","eWEEK","Nextgen Reader","New York Times","RapidNews",""},//News
                                       {"ESPN ScoreCenter","Baseball Live","College Football Scoreboard","Basketball Live","Tennis Live","Baseball Pro '12","Real Soccer","Run The Map","QuickScores","All Sports News","Simple Skore",""},//Sports
                                       {"eBay","PayPal","Groupon","Amazon Mobile","ATM Hunter","myShopi","Starbucks Finder","Discount Calc Plus","Newegg","The Home Depot","Shared Shopping List",""},//Shopping&Finance
                                       {"Facebook","Twitter","WhatsApp","LinkedIn","foursquare","Free Talk","Groups for FB","Talk2Me","Kik Messenger","Holidays Calendar","Radar Rabbit",""},//Social
                                       {"Yelp","Betty Crocker","OpenTable","Allrecipes","Epicurious Recipes & Shopping List","Pizza Hut","Restaurant Inspections","Simple Tip","Chef Pro","Food Manager","Find MY Starbucks",""},//Food&Restaurants
                                       {"Amazon Kindle","Wikipedia","eHow","Audible - Audiobooks","Dictionary.com","Free Kindle Book","Free Books","AudioBooks","Ebook Reader","eBook Magic","MangaReader",""},//Books&Refernce
                                       {"Evernote","SkyDrive","Clearer","Tasks","Timer","All My Passwords","Network Dashboard","Mobile Craigslist","Scan","Quick Settings","Tiled Notes",""},//Organization
                                       {"TripAdvisor","Skyscanner","Flight Status","Find places","Mapy.cz","Mango Transit","My Trips","Good Hotel Guide","Compass","Hertz Car Rental","American Airlines",""},//Travel&Navigation
                                       {"MapMyRUN","runtastic","Water Log","Push Up Trainer","MyFitnessPal","Calorie Counter by FatSecret","DailyYoga for Abs","Sound Sleep","Body Fat Calculator","Zombies, Run!","100 Pushups",""},//Fitness
                                };
        string path = "";
        string name = ""; // the name of the app

        /* Generate the tile information */
        public Dictionary<int, String[]> generate(ScreenTemplate currentTemplate, int templateIndex, string color, double[,] input, string game, string family)
        {
            GetIndex(input);//get the two category
            int firstCategory = ((currentTemplate.getLarge().Count + currentTemplate.getMedium().Count + currentTemplate.getSmall().Count - 3)+1)/2;//the number of apps of the first category
            int popularCate = firstCategory;
            int nonpopular=0;
            int appNum = input.GetLength(0);//the total categories
            //normalize input
            double totalweight = 0;
            for (int i = 0; i < appNum; i++)
                totalweight += input[i, 1];
            for (int i = 0; i < appNum; i++)
            {
                input[i, 1] = input[i, 1] * 100 / totalweight;
            }
            // Generate large tile first
            string[] tmplargepath = new string[currentTemplate.getLarge().Count];
            int largepathindex = 0;
            bool setfirst = false;
            if ((input[2, 1] != 0) || (input[4, 1] != 0))//if using hotmail
            {
                setfirst = true;
            }
            Dictionary<int, String[]> tielsInfo = new Dictionary<int, String[]>();
            foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getLarge())
            {
                if (setfirst)//set the first one the 
                {
                    path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/hotmail_L.png";
                    name = "";
                    tmplargepath[largepathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",3," + name + ",";
                    largepathindex++;
                }
                else
                {
                    if (firstCategory >=0)
                    {
                        path = AppCategories[popularIndexr] + "/" + (popularCate - firstCategory).ToString() + ".png";
                        name = AppName[popularIndexr, (popularCate - firstCategory)];
                        tmplargepath[largepathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",3," + name + ",";
                        firstCategory =firstCategory -1;
                        largepathindex++;
                    }
                    else
                    {
                        path = AppCategories[nonpopularIndex] + "/" + (nonpopular).ToString() + ".png";
                        name = AppName[nonpopularIndex, (nonpopular)];
                        tmplargepath[largepathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",3," + name + ",";
                        nonpopular = nonpopular +1;
                        largepathindex++;
                    }
                }
                setfirst = false;
            }
            // Generate medium apps
            string[] tmpmediumpath = new string[currentTemplate.getMedium().Count];
            int mediumpathindex = 0;
            setfirst = true;
            int controller2 = 0;
            int tracker = currentTemplate.getMedium().Count;
            foreach (KeyValuePair<Startpoint, string> pair in currentTemplate.getMedium())
            {
                if (setfirst)
                {
                    path = "http://www.etc.cmu.edu/projects/up-plus/images/contact.png";
                    name = "";
                    tmpmediumpath[mediumpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",2," + name + ",";
                    mediumpathindex++;
                }
                else 
                {
                    if (firstCategory >=0)
                    {
                        path = AppCategories[popularIndexr] + "/" + (popularCate - firstCategory).ToString() + ".png";
                        name = AppName[popularIndexr, (popularCate - firstCategory)];
                        tmpmediumpath[mediumpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",2," + name + ",";
                        firstCategory = firstCategory-1;
                        mediumpathindex++;
                    }
                    else
                    {
                        path = AppCategories[nonpopularIndex] + "/" + (nonpopular).ToString() + ".png";
                        name = AppName[nonpopularIndex, (nonpopular)];
                        tmpmediumpath[mediumpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",2," + name + ",";
                        nonpopular = nonpopular+1;
                        mediumpathindex++;
                    }
                   
                }
                setfirst = false;                
            }
            // Generate small apps
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
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_S.png";
                        name = "";
                        tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                        smallpathindex++;
                        controller++;
                    }
                    else if(controller==1)
                    {
                        if ((controller2 == 0) && (family != "D"))//if the youngest two
                        {
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Kids&Family/familyroom.png";
                            name = "Family room"; // the name of family room
                            tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                            smallpathindex++;
                            controller2++;                            
                        }
                        else
                        {
                            if (firstCategory >=0)
                            {
                                path = AppCategories[popularIndexr] + "/" + (popularCate - firstCategory).ToString() + ".png";
                                name = AppName[popularIndexr, (popularCate - firstCategory)];
                                tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                                firstCategory = firstCategory - 1;
                                smallpathindex++;
                            }
                            else
                            {
                                path = AppCategories[nonpopularIndex] + "/" + (nonpopular).ToString() + ".png";
                                name = AppName[nonpopularIndex, (nonpopular)];
                                tmpsmallpath[smallpathindex] = path + "," + color + "," + pair.Key.x + "," + pair.Key.y + ",1," + name + ",";
                                nonpopular =nonpopular + 1;
                                smallpathindex++;
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
           
            string[] text = { MailText[Convert.ToInt32(input[1, 0])].ToString() };
            tielsInfo.Add(3, text);
          
            return tielsInfo;
        }////////////////////////////////////end of generation

        /* get the index of the two categories that will show on the screen */
        public void GetIndex(double[,] input)
        {
            for (int i = 0; i < input.Length/2; i++)
            { 
                if(input[i,1] >0.0 )
                {
                    if (i < 5)
                    {
                        popularIndexr = i;
                    }
                    else
                    {
                        nonpopularIndex = i;
                    }
                }
            }

        }

    }
}