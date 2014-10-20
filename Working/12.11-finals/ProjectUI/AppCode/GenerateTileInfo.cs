using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class GenerateTileInfo
    {
        static string[] colors = new string[8] { "red", "yellow", "orange", "magenta", "purple", "brown", "blue", "green" };
        public static int ctgrNum = 12;
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

        static string[,] AppDescription = { // the descriptions of each app
                                              {//Games
                                                "",
                                                "Insanely Addictive! Jump, jump, jump to the top, top, top with the runaway hit now! Guide the Doodler on a springy journey using springs, jet packs and more. Avoid baddies and blast them with your nose balls!",
                                                "Birds! Slingshots! Destruction! Feathers! Fun! The survival of the Angry Birds is at stake. Dish out revenge on the green pigs who stole the Birds' eggs. Angry Birds features hours of game play, challenging physics-based castle demolition and lots of replay value. Each of the levels requires logic, skill and brute force to crush those greedy pigs!",
                                                "Swipe your finger across the screen to deliciously slash and splatter fruit like a true ninja warrior. Be careful of bombs – they are explosive to touch and will put a swift end to your juicy adventure! Fruit Ninja also uses Xbox LIVE achievements, so players can unlock achievements and shoot for the top of the leaderboards while racking up gamer score points. Your success will also please the wise ninja Sensei, who will accompany your journey with wise words and fun fruit facts. Fruit Ninja is the messiest and most satisfying fruit game ever!",
                                                "Get ready to soil your plants! A mob of fun-loving zombies is about to invade your home, and the only defense is your arsenal of plants. Use peashooters, wall-nuts, cherry bombs and more to mulchify 26 types of zombies before they reach your front door. The fun never dies!",
                                                "Hit the slopes for some serious shredding in the most fun snowboarding game ever created! To survive you will have to perform impossible stunts, dodge deadly saws and do incredible jumps in a world where gravity laws have been broken! ",
                                                "Make your Sim neurotic, funny, or shy. Draw from a wide array of built-in theme sets to bring your Sim to life with any appearance, clothing, and accessories you choose. Also make sure to fulfill your Sim’s basic needs like eating and sleeping to increase the activities you can do together.",
                                                "Play through 3 levels of difficulty and save games in progress. Also customize the number of players, “house rules,” and even the game environment. From Marvin Gardens and Water Works to Park Place, own and manage the famous holdings of the MONOPOLY board, which comes to life with animated tokens and interactive features.",
                                                "The world-famous card game is faithfully reproduced for mobile and also features exciting new rules. Relive all the crazy fun of UNO™: match colors or numbers with all your favorite cards or challenge yourself with increasingly difficult games in Tournament Mode.  Playing UNO™ has never been so fun and easy, so be the first to get rid of all your cards!",
                                                "Connect matching colors with pipe to create a flow. Pair all colors, and cover the entire board to solve each puzzle. But watch out, pipes will break if they cross or overlap!Free play through hundreds of levels, or race against the clock in Time Trial mode. Gameplay ranges from simple and relaxed, to challenging and frenetic, and everywhere in between. How you play is up to you. So, give Flow Free a try, and experience \"mind like water\"!",
                                                "GameHalo Waypoint is the official hub for Halo content and Halo: Reach Career data on your Windows Phone!  Waypoint features ATLAS, the official multiplayer companion for Halo: Reach.  Check out overhead views of multiplayer and firefight maps, as well as beautifully illustrated versions from Brady Games.  The maps show weapon and vehicle locations, and you can get real-time position and score information for Multiplayer games, for you and your team.  With Halo Waypoint, you have direct access to official Halo news and announcements before anyone else.",
                                                "The game promises action filled 21 stages that would keep you jumping off your seats! Gain an extra life at 10,000 points! Outsmart the ghosts to eat all the dots for advancing to the next level. Use the four bold dots smartly when cornered and gobble up the enemies for extra points as they turn blue.Choose between the two types of controls provided depending on your preference. Swipe your fingers to use the flick motion (preferred) or your thumb for the virtual Joystick!"
                                              },
                                              {//Music
                                                "",
                                                "Free music downloader enables users to download Free and Legal Music directly to their phone. Users of any version can download free music files without any limitation. Free Ringtones is a biggest collection of free ringtones available on Window Phone Store.",
                                                "Free Ringtones is a biggest collection of free ringtones available on Window Phone Store.",
                                                "Hear a song you don’t know? Shazam identifies it instantly.",
                                                "iHeartRadio brings you a best-in-class customizable digital listening experience that combines the best of both worlds to deliver everything you want in one free, fully-integrated service: More than 800 of the nation's most popular live broadcast and digital-only radio stations from 150 U.S. cities, plus user-created Custom Stations.",
                                                "www.last.fm is a music recommendation service that lets you effortlessly keep a record of what you listen to and adds it to your Last.fm profile. Based on what you like, Last.fm recommends you more music, concerts and people.",
                                                "Prepare to rock out on your phone with the newest edition of the #1 selling music series.  Rock out on guitar, drums and bass with up to 32 of the hottest Rock ‘n’ Roll songs and additional downloadable songs from Blink 182, David Bowie, Nirvana, Sublime, Vampire Weekend, and other iconic bands.", 
                                                "OpenMic is the karaoke game for your Windows Phone 7 device. Sing along with hits from Kelly Clarkson, Jordin Sparks, and Ke$ha. As you sing, you'll be graded on your performance using the app's built-in pitch detection. You can choose to sing along with the stars, or go it solo and see how well you can do with just you and the band.",
                                                "Tired of recording apps which don't let you do anything cool with your recordings? If yes, then BeatBox is for you! Record samples, polish them and make use of in great projects! Projects let you place your samples on a timeline, creating a full track with a plenty of samples.",
                                                "MP3 Downloader allows you to download MP3 files and store them locally for offline listening. You can download any MP3 file from the Internet and it will be stored in the downloaded MP3 library of this application. MP3 Downloader is a fully featured free application with no ads.",
                                                "Mixtapes gives you free access to millions of songs organized into mixes by listeners like you. Start listening to great music right away or create an account to track your favorite mixes, songs, and DJs. Stop letting marketing dweebs and computer algorithms pick your music and hear what real people from around the world are listening to.",
                                                "Needle and stroboscope chromatic instrument tuner. The needle enables fast and comfortable rough tuning, while two optional stroboscopic animations facilitate fine tuning. Both methods are used at the same time, so it’s not necessary to choose one of them. Detected notes are shown on a musical staff. Adjustable sensitivity will help in not so quiet environments."
                                              }, 
                                              {//Video&Movie
                                                "Can't wait to see the latest videos posted by your friends? Use this app to play YouTube videos by tapping video links in your email and MMS messages, websites, and apps like Facebook. Tap the YouTube app icon to open YouTube in the browser, where you can sign in and browse millions of videos, including favorites and playlists. This app integrates with the Music & Videos hub so you can get to your most-recently played videos and launch YouTube from the hub.",
                                                "Netflix is the world’s leading subscription service for watching TV episodes and movies.",
                                                "IMDb is the world's largest collection of movie, TV and celebrity information, and has the leading app for Windows Phone  to find showtimes, watch trailers, browse photo galleries, get US TV listings, find latest DVD and Blu-ray releases, explore popular charts and share movie information.",
                                                "Movies by Flixster and Rotten Tomatoes, the top movie app to watch movie trailers, find showtimes, and get critic reviews, is now on Windows Phone!",
                                                "What is Vimeo? It's a friendly place where anyone who takes or loves video can watch, share, discover, and be inspired. Learn more at Vimeo.com.",
                                                "Since opening in 1920, AMC Theatres® has been dedicated to delivering the best possible movie-going experience. Now you can experience the magic of AMC at your fingertips! Download the FREE AMC Theatres® mobile application – the newest and most advanced way to access exclusive content, find your local AMC Theatre, get showtimes and buy tickets.",
                                                "This app will give you the chance to watch (and save) your favorites series, movies, live sports and music on your WP7!",
                                                "Control your VLC media player on your computer with VLC play! VLC is one of the most popular free media player, which (almost) plays every file type.",
                                                "YouTube Downloader allows you to download video in High-Quality(HQ) and High-Definition(HD) resolution or audio as MP3 from your favorite YouTube clips locally on your device. With this app you can browse YouTube and when you are on the page of the desired video you can download it as video (MP4 360p HQ and MP4 720p HD) or audio (MP3).",
                                                "onePlayer is an universal media player and controller for  your DLNA home networks. Stream your music, movie and pictures from servers to TV or other DLNA end device. onePlayer explores the available media servers and renderer devices in the WiFi network.",
                                                "Movie Vault has been designed from scratch for Windows Phone 7 to give you the best possible movie watching experience. Now you can stream great feature length films that feature some of the best actors, actresses, and directors over the last hundred years.",
                                                ""
                                              },
                                              {//Camera&Photo
                                                "",
                                                "With Phototastic you can create fantastic looking collages of your photos.Create a collage using classic frame borders or choose from one of the film templates like polaroid, photobooth or filmstrip or try out the new facebook cover photo frames.Once finished with arranging your photos apply one of the many effects available.",
                                                "Lomogram is a photo editing app with 30+ filters, lots of borders and light effects that can be combined in numerous ways to achieve unique look. Share your photos with facebook, twitter, flickr, tumblr and vk to impress your friends!",
                                                "Fhotoroom is a pro camera, photo sharing network and professional mobile photo editor.Our Pro Camera is focused on achieving the absolutely best results that your camera can produce. Utilizing technology like our custom EV (Auto Exposure), Grid and Level all come together to extend the ability of your camera.",
                                                "This is an Image processing and customization app. The application Uses AVIARY Free SDK but it features much more advancements and easy to use UI.",
                                                "Try out the InstaCam+ app! Make your own photos unique by adding one of 26+ cool filters(HDR) and 12 great frames and share them to Facebook, Twitter, Foursquare, Tumblr, Weibo, Vkontakte and Flickr. Design more than 235000 filters by yourself and show them to your friends!",
                                                "Photo Studio allows you to add various visual effects to any picture. Photos can be taken from the camera or selected from the Pictures Hub. Each effect applied to the picture is chosen from a list of available effects. List contains thumbnails with available effects so you can quickly decide which effect you want to add to your photo.",
                                                "Bing Wallpaper allows you to browse and save high-definition images from Bing which is customized for your Windows Phone wallpaper (portrait: 480x800 pixels, landscape 800x480 pixels) and never available in other Bing picture apps!",
                                                "Cool and attractive app for people to simply make beautiful pictures, apply effects and share them with friends easily!",
                                                "This application allows you to edit images and add different effects to it. This app supports different effects like Ridge, Negative, B/W, Invert etc. You can decorate your image by adding different stylish frames around it. You can also change zoom level, opacity and rotation angel of image and text objects.",
                                                "Make your 3D Photos from camera or album and view as anaglyph (red/cyan glasses required), stereogram (no glasses required) or wigglegram (3D-like effect).",
                                                "The ultimate picture effects app for all device types! If you like to make beautiful photos, then this app is a perfect addition to your phone’s toolset. Pictures Lab provides you with thousands of different modifications for your photos and the WP 7.5"
                                              },
                                              {//News
                                                "CNN connects you to the world, wherever you are. Stay informed with the latest headlines and original stories from around the globe. Follow up-to-the-minute reporting with breaking news alerts and live video. Lead the conversation by sharing today’s news and dig deeper into the stories that matter most to you.",
                                                "The latest news stories, sports scores, weather and photos you’ve come to expect from USA TODAY are now available for your Windows Phone. Staying informed on the go has never been this quick, easy or enjoyable.",
                                                "Quickly and easily browse, read and share the latest BBC News.",
                                                "NEWS is a powerfull newsreader powered by MSNBCs news feeds. Get NEWS today on your Windows Phone 7! The most comprehensive newsreader available and optimized for easy reading on a smartphone.",
                                                "With the FOX News app for Windows Phone - read the hottest stories of the day, browse through photo galleries, and watch the latest video clips from FOX News Channel, all for free!",
                                                "You can get free latest news updates of ABC News Channel.",
                                                "Get all your news needs filled with News Channels",
                                                "For more than 25-years eWEEK has been the trusted source for the latest news on business-ready IT hardware and software products, expert labs analysis, and guidance for evaluating, acquiring, installing, configuring, and maintaining technology products and services.",
                                                "Dynamic subscriptions hub with featured section to find latest and popular feeds. Read full articles in beautiful clean view powered by Readability, Instapaper or Google mobilizer. Watch YouTube videos, share to social networks like Twitter, Facebook, etc. and save articles to Instapaper, Read It Later & Readability for offline reading.",
                                                "All the latest news and headlines from the New York Times",
                                                "A fast, smooth and highly configurable News reader that lets you browse through 80+ story synopses in one virtual cast. Swipe over collections of local, global and custom breaking news, expand for headlines and sharing, then navigate to the full story or move on.",
                                                ""
                                              },
                                              {//Sports
                                                "ESPN ScoreCenter brings you scores, news, and standings from hundreds of sports leagues around the world.",
                                                "Tired of sports apps that redirect to a website? Baseball Live provides you the latest news and results in Major League Baseball.",
                                                "Updated with 2012-13 Schedules & Scores",
                                                "Basketball Live provides you the latest news and results in the NBA!",
                                                "Tennis Live provides you the latest news and results in tennis.",
                                                "Never miss another game again!, whether you follow your favorite Baseball Team or glance at every single game, Baseball Pro '12 offers you the most comprehensive coverage available on your Windows Phone.",
                                                "Get ready for a soccer season and battle for the cup with Real Soccer, the benchmark for mobile soccer games. Choose from 245 teams in 8 leagues with nearly every player thanks to the FIFPro license. Face off in 14 stadiums detailed in 3D as you perform amazing moves with a simple and intuitive touch of the screen.",
                                                "Run The Map is a route recorder/analyzer for your outdoor activities (walking, running, biking, etc.). Run The Map represents your tracks on a map in real time and shows you the related information (distance, duration, speed, altitude, etc.). You can then save your results by exporting them or obtain statistics from the data stored in your phone. ",
                                                "Simple app to get Live sports scores without all the fluff. You can get live sports scores for The National Football League NFL , College NCAA Football, Magor League Baseball MLB, National Basketball Association NBA, College NCAA Basketball, and the National Hockey League NHL.",
                                                "ALL SPORTS NEWS is a powerful sports news reader bringing all the latest news from ESPN to your phone.",
                                                "Simple Skore is a scoring application which can be used to keep score for two teams in events such as soccer, basketball, baseball, etc.",
                                                ""
                                              },
                                              {//Shopping&Finance
                                                "The eBay Mobile application is designed specifically for Windows Phone. Using a streamlined interface that is as elegant as it is practical, eBay members can search, bid, and check their activity on the go.",
                                                "Enjoy PayPal on-the-go with the PayPal Windows Phone app.",
                                                "Groupon features 50%-90% off deals on the best stuff to do, eat, see and buy. Discover your town and the world with Daily Deals, Now! Deals, and Getaway deals. Groupon is available in more than 500 cities around the world, and we add new cities and deals every day.", 
                                                "Search & buy millions of products right from your Windows Phone device.",
                                                "Find ATMs located around the world with your Windows Phone’s GPS, by entering an address or an airport location, from wherever you happen to be. You can also find merchants who accept MasterCard® PayPass™.",
                                                "Speed up your shopping with myShopi, the shopping list for all !myShopi, the free shopping list, speeds up your shopping and enables you to save time. The interface is SIMPLE and INTUITIVE and has many images.",
                                                "Let Starbucks Finder quench your coffee craving! Find your closest, open Starbucks stores and pay with your phone.",
                                                "Discount Calculator helps you compute and track your savings from a product discount. Quickly enter the price of the product, discount percent, and the number of items to compute your savings and your total amount.",
                                                "The app allows Windows Phone 7 users to search, shop, read reviews and make purchases on Newegg.com.",
                                                "The Home Depot app provides the ability to research and purchase over 100,000 products directly from within the app",
                                                "Have you ever been disappointed when your spouse walked in with the groceries, but didn’t get the coffee you so desperately needed? Ever ended up with 4 gallons of milk in the fridge because each roommate went shopping separately? With the Shared Shopping List, any number of Windows Phones can share the same set of lists, and these woes are a thing of the past.",
                                                ""
                                              },
                                              {//Social
                                                "Facebook for Windows Phone makes it easy to stay connected and share information with friends. You can post status updates, receive Live Tile updates, check your news feed, review upcoming events, check in to places, manage your inbox, upload photos, publish notes, accept friend requests, pin Places and Messages as Tiles, and look at your friends’ photos, walls and info.",
                                                "Discover what’s happening right now, anywhere in the world, with the official Twitter for Windows Phone app. Tweets, real-time search, Suggested users, top Tweets, trending topics and maps show what's happening everywhere—and nearby. ",
                                                "WhatsApp Messenger is a smartphone messenger available for Windows Phone, Android, BlackBerry, iPhone, and Nokia phones. WhatsApp uses your 3G or WiFi (when available) to message with friends and family. Switch from SMS to WhatsApp to send and receive messages, pictures, audio notes, and video messages. First year FREE! ($0.99/year after)",
                                                "Get on-the-go access to your professional network with LinkedIn for Windows Phone. Find and connect with more than 161M members worldwide, read the latest industry news, keep up-to-date with your groups, explore jobs you might be interested in, and share content with your network from anywhere.",
                                                "foursquare helps you explore the world around you. Meet up with friends. Find places to go. Save money with Specials. Have fun exploring!",
                                                "Google voice provides free SMS and cheap international and long distance calling. Now you can do all of that without paying for a Google Voice client as well. With FreeTalk you can send SMS, make calls thru Google Voice, view and manager your inbox, listen to your voicemail and do lot more. And that’s free",
                                                "Finally, a way to access all of your Facebook Groups right on your Windows Phone 7 device, in a lovely, easy to use, native Mango application!  Get the groups support that the official Facebook application lacks!",
                                                "Send and receive recorded voice messages to other Talk2Me users.  Full Mango 7.5 support for Fast App Resume, Push Notifications and two side tiles. Trial has no limits and is ad supported.",
                                                "14 million users love Kik! It is the fast, simple, and personal smartphone messenger that connects you to everyone you love to talk to.",
                                                "Holidays Calendar is a nice and simple app that lists various types of holidays: career holidays, national and international holidays, special days and more.",
                                                "Radar Rabbit takes your privacy and safety very seriously. All communication between members on Radar Rabbit happens through an “anonymous” chat service. Only approximate member locations are shown or recorded.", 
                                                ""
                                              },
                                              {//Food&Restaurants
                                                "Looking for a burrito joint open now?  A gas station you can drive to before your tank hits empty?  Yelp for Windows Phone 7 is here to help.  Search for places to eat, shop, drink and play then read reviews from an active community of locals in the know.",
                                                "What's for dinner? Ask Betty using the mobile version of the world-famous Betty Crocker cookbook!",
                                                "Restaurant Reservations - Free, Instant, Confirmed.",
                                                "Allrecipes.com Dinner Spinner is a fun and useful recipe app from the world’s #1 food site, delivering thousands of our members’ favorite quick and easy recipes to your Windows Phone device.",
                                                "Recipes from the award-winning food site Epicurious.com are now available on your mobile device.",
                                                "All your favorites at Pizza Hut are now available on the Windows Phone 7!",
                                                "Find out what the King County Health Department thinks of your favorite restaurant. Defend yourself and your family from food borne illness for just a few pennies. Live data pulled directly from the King County Health Department; a vast database continuously updated.",
                                                "Simple Tip is the easiest-to-use tip calculator in the Marketplace. Simple Tip stays true to the Windows Phone Metro style and doesn't have background images that make the screen hard to read or crowd up your screen with a lot of unnecessary clutter.",
                                                "Chef Pro is your helper in the kitchen! Chef Pro is the definitive application that allows you to access 17,500 recipes divided into categories.",
                                                "Scan or type in your item after your purchase with the corresponding date. The app reminds you before the end of the MHD's and sends them automatically an alarm, the date of expiry.",
                                                "Find MY Starbucks for Windows Phone provide you an easy way to find a nearby Starbucks Coffee Cafe from your Windows Phone.",
                                                ""
                                              },
                                              {//Books&Refernce
                                                "The Kindle app is optimized for the Windows Phone, giving users the ability to read Kindle books on a beautiful, easy-to-use interface. You’ll have access to over 750,000* books in the Kindle Store, including best sellers and new releases.",
                                                "Wikipedia is a free encyclopedia. Wikipedia provides an easier search of Wikipedia for Windows Phone.",
                                                "Life can be much easier with a little help from the eHow app. With millions of helpful articles at your fingertips, eHow is your source for expert tips and advice on topics spanning Home, Food, Money, Family, Health, Style and more. Search and discover your answers on the go — it’s quick and easy.",
                                                "Audible.com, the internet’s premier provider of digital audiobooks and more, is now available for Windows Phone!",
                                                "The FREE Dictionary.com app delivers trusted reference content from Dictionary.com and Thesaurus.com, including over 2,000,000 words. It also features audio pronunciation and updated daily content. Get the world’s #1 dictionary app on your phone today!", 
                                                "All free ebooks. All you can read. This app sort the newest free ebooks for your Kindle reader.",
                                                "Ah, to describe an app in two words... Free Books is just that- Free Books! Free Books is the world's favorite paid book app. Browse our handpicked collections, download any one of our 23,469 classic books instantly, and read with our fully featured ereader",
                                                "The app presents to you more than 2500 of the greatest classic books in human history in audio book format to download and listen anytime, anywhere. The books are completely free – so you don't have to pay to download individual books.",
                                                "More than 100,000 freely downloadable books. All the greatest classics for hours and hours of pleasant reading.",
                                                "eBook Magic allows you to read eBooks on your Windows Phone anywhere and at any time",
                                                "With MangaReader, you instantly get access to thousands of manga's. MangaReader makes extensive use of the Windows Phone platform to enhance the reading and navigating experience.",
                                                 ""
                                              },
                                              {//Organization
                                                  "","","","","","","","","","","",""                        },
                                            //  Free Ringtones is a biggest collection of free ringtones available on Window Phone Store. 
                                          };


        string path = "";
        string name = ""; // the name of the app
        Random random = new Random(DateTime.Now.Millisecond);

        int call_message_randindex;// = random.Next(0, 2);

        public Dictionary<int, String[]> generate(ScreenTemplate currentTemplate, int templateIndex, string color, double[,] input, string game, string family)
        {
            GetIndex(input);//get the two category
            int firstCategory = ((currentTemplate.getLarge().Count + currentTemplate.getMedium().Count + currentTemplate.getSmall().Count - 3)+1)/2;
            int popularCate = firstCategory;
            int nonpopular=0;
            //call_message_randindex = random.Next(0, 2);
            int appNum = input.GetLength(0);//the total categories
            int[] appIndex = new int[2];
            for (int i = 0; i < 2; i++)//a category
            {
                appIndex[i] = 0;//this is the index of every category
            }
            //normalize input
            double totalweight = 0;
            for (int i = 0; i < appNum; i++)
                totalweight += input[i, 1];
            for (int i = 0; i < appNum; i++)
            {
                input[i, 1] = input[i, 1] * 100 / totalweight;
            }

            //先放large的
            string[] tmplargepath = new string[currentTemplate.getLarge().Count];
            int largepathindex = 0;
            bool setfirst = false;
            if ((input[2, 1] != 0) || (input[4, 1] != 0))//if using hotmail
            {
                setfirst = true;
            }
            //bool setsecond = true;
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

            //第二个放medium的////////////////////////////////////////////////////
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

                    /*    if (call_message_randindex == 0)
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_M.png";
                        else
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/message_M.png";*/

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
                        path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_S.png";
                       /* if (call_message_randindex == 1)
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/phonecall_S.png";
                        else
                            path = "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/message_S.png"; */
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
                            //name = AppName[0, appIndex[controller - 1]]; 
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
        }////////////////////////////////////end of generate

        public void GetIndex(double[,] input)//get the index of the 
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