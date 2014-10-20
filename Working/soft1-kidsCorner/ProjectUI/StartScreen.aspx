
<%@ Page Language="C#" AutoEventWireup="true" Inherits="StartScreen" Codebehind="StartScreen.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN"
 "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <!--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css"> -->
    <script language="javascript" type="text/javascript" src="jquery.min.js"></script>
    <script language="javascript" type="text/javascript" src="jquery-ui-1.8.23.custom.min.js"></script>
</head>
<script language="javascript" type="text/javascript">
    var picid_num = 13;

    $(document).ready(function () {
        generateid();
        setInterval("generateid()", 6000);
        /*$("#pic2").click(function () { 
            $("#pichi").animate({ "top": "-=380px" }, "slow"); 
        });*/
    });
    function generateid() {
        var id1 = Math.floor(Math.random() * picid_num + 1);
        var id2 = Math.floor(Math.random() * picid_num + 1);
        while (id2 == id1) {
            id2 = Math.floor(Math.random() * picid_num + 1);
        }
        //console.log(id1, id2);
        livetile(id1, id2);
    }

    function livetile(id1, id2) {
        tileanimateup(id1);
        setTimeout(function () { tileanimateup(id2) }, 1000);
        setTimeout(function () { tileanimatedown(id1) }, 3000);
        setTimeout(function () { tileanimatedown(id2) }, 4000);
    }

    function tileanimateup(id) {
        $("#pic" + id).animate({ "top": "-=35px" }, "slow");
    }

    function tileanimatedown(id) {
        $("#pic" + id).animate({ "top": "+=35px" }, "slow");
    }

    $(function () {

        var appDescription = {
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png": "<p>Phototastic Free</p>With Phototastic you can create fantastic looking collages of your photos.Create a collage using classic frame borders or choose from one of the film templates like polaroid, photobooth or filmstrip or try out the new facebook cover photo frames.Once finished with arranging your photos apply one of the many effects available.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/1.png": "<p>Lomogram</p>Lomogram is a photo editing app with 30+ filters, lots of borders and light effects that can be combined in numerous ways to achieve unique look. Share your photos with facebook, twitter, flickr, tumblr and vk to impress your friends!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/2.png": "<p>Fhotoroom</p>Fhotoroom is a pro camera, photo sharing network and professional mobile photo editor.Our Pro Camera is focused on achieving the absolutely best results that your camera can produce. Utilizing technology like our custom EV (Auto Exposure), Grid and Level all come together to extend the ability of your camera.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/3.png": "<p>Custom Effects</p>This is an Image processing and customization app. The application Uses AVIARY Free SDK but it features much more advancements and easy to use UI.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/4.png": "<p>InstaCam</p>Try out the InstaCam+ app! Make your own photos unique by adding one of 26+ cool filters(HDR) and 12 great frames and share them to Facebook, Twitter, Foursquare, Tumblr, Weibo, Vkontakte and Flickr. Design more than 235000 filters by yourself and show them to your friends!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/5.png": "<p>Photo Studio</p>Photo Studio allows you to add various visual effects to any picture. Photos can be taken from the camera or selected from the Pictures Hub. Each effect applied to the picture is chosen from a list of available effects. List contains thumbnails with available effects so you can quickly decide which effect you want to add to your photo.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/6.png": "<p>Bing Wallpaper</p>Bing Wallpaper allows you to browse and save high-definition images from Bing which is customized for your Windows Phone wallpaper (portrait: 480x800 pixels, landscape 800x480 pixels) and never available in other Bing picture apps!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/7.png": "<p>EasyEffects</p>Cool and attractive app for people to simply make beautiful pictures, apply effects and share them with friends easily!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/8.png": "<p>Photo Editor+</p>This application allows you to edit images and add different effects to it. This app supports different effects like Ridge, Negative, B/W, Invert etc. You can decorate your image by adding different stylish frames around it. You can also change zoom level, opacity and rotation angel of image and text objects.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/9.png": "<p>3D Photo Maker</p>Make your 3D Photos from camera or album and view as anaglyph (red/cyan glasses required), stereogram (no glasses required) or wigglegram (3D-like effect).",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/10.png": "<p>Pictures Lab</p>The ultimate picture effects app for all device types! If you like to make beautiful photos, then this app is a perfect addition to your phone’s toolset. Pictures Lab provides you with thousands of different modifications for your photos and the WP 7.5",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/0.png": "<p>YouTube</p>Can't wait to see the latest videos posted by your friends? Use this app to play YouTube videos by tapping video links in your email and MMS messages, websites, and apps like Facebook. Tap the YouTube app icon to open YouTube in the browser, where you can sign in and browse millions of videos, including favorites and playlists. This app integrates with the Music & Videos hub so you can get to your most-recently played videos and launch YouTube from the hub.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/1.png": "<p>Netflix</p>Netflix is the world’s leading subscription service for watching TV episodes and movies.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/2.png": "<p>IMDb</p>IMDb is the world's largest collection of movie, TV and celebrity information, and has the leading app for Windows Phone  to find showtimes, watch trailers, browse photo galleries, get US TV listings, find latest DVD and Blu-ray releases, explore popular charts and share movie information.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/3.png": "<p>Flixster</p>Movies by Flixster and Rotten Tomatoes, the top movie app to watch movie trailers, find showtimes, and get critic reviews, is now on Windows Phone!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/4.png": "<p>Vimeo</p>What is Vimeo? It's a friendly place where anyone who takes or loves video can watch, share, discover, and be inspired. Learn more at Vimeo.com.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/5.png": "<p>AMC Theatres</p>Since opening in 1920, AMC Theatres® has been dedicated to delivering the best possible movie-going experience. Now you can experience the magic of AMC at your fingertips! Download the FREE AMC Theatres® mobile application – the newest and most advanced way to access exclusive content, find your local AMC Theatre, get showtimes and buy tickets.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/6.png": "<p>FlashVideo+TubeMusic</p>This app will give you the chance to watch (and save) your favorites series, movies, live sports and music on your WP7!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/7.png": "<p>VLC play!</p>Control your VLC media player on your computer with VLC play! VLC is one of the most popular free media player, which (almost) plays every file type.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/8.png": "<p>YouTube Downloader</p>YouTube Downloader allows you to download video in High-Quality(HQ) and High-Definition(HD) resolution or audio as MP3 from your favorite YouTube clips locally on your device. With this app you can browse YouTube and when you are on the page of the desired video you can download it as video (MP4 360p HQ and MP4 720p HD) or audio (MP3).",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/9.png": "<p>onePlayer</p>onePlayer is an universal media player and controller for  your DLNA home networks. Stream your music, movie and pictures from servers to TV or other DLNA end device. onePlayer explores the available media servers and renderer devices in the WiFi network.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/10.png": "<p>Movie Vault - Classic Films</p>Movie Vault has been designed from scratch for Windows Phone 7 to give you the best possible movie watching experience. Now you can stream great feature length films that feature some of the best actors, actresses, and directors over the last hundred years.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/0.png": "<p>Amazon Kindle</p>The Kindle app is optimized for the Windows Phone, giving users the ability to read Kindle books on a beautiful, easy-to-use interface. You’ll have access to over 750,000* books in the Kindle Store, including best sellers and new releases.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/1.png": "<p>Wikipedia</p>Wikipedia is a free encyclopedia. Wikipedia provides an easier search of Wikipedia for Windows Phone.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/2.png": "<p>eHow</p>Life can be much easier with a little help from the eHow app. With millions of helpful articles at your fingertips, eHow is your source for expert tips and advice on topics spanning Home, Food, Money, Family, Health, Style and more. Search and discover your answers on the go — it’s quick and easy.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/3.png": "<p>Audible - Audiobooks</p>Audible.com, the internet’s premier provider of digital audiobooks and more, is now available for Windows Phone!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/4.png": "<p>Dictionary.com</p>The FREE Dictionary.com app delivers trusted reference content from Dictionary.com and Thesaurus.com, including over 2,000,000 words. It also features audio pronunciation and updated daily content. Get the world’s #1 dictionary app on your phone today!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/5.png": "<p>Free Kindle Book</p>All free ebooks. All you can read. This app sort the newest free ebooks for your Kindle reader.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/6.png": "<p>Free Books</p>Ah, to describe an app in two words... Free Books is just that- Free Books! Free Books is the world's favorite paid book app. Browse our handpicked collections, download any one of our 23,469 classic books instantly, and read with our fully featured ereader",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/7.png": "<p>AudioBooks</p>The app presents to you more than 2500 of the greatest classic books in human history in audio book format to download and listen anytime, anywhere. The books are completely free – so you don't have to pay to download individual books.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/8.png": "<p>Ebook Reader</p>More than 100,000 freely downloadable books. All the greatest classics for hours and hours of pleasant reading.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/9.png": "<p>eBook Magic</p>eBook Magic allows you to read eBooks on your Windows Phone anywhere and at any time",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/10.png": "<p>MangaReader</p>With MangaReader, you instantly get access to thousands of manga's. MangaReader makes extensive use of the Windows Phone platform to enhance the reading and navigating experience.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/0.png": "<p>MapMyRUN</p>Simple to use, for all ages and ability levels. Run and Workout Tracking and Logging: Pace , Live Route Map , Distance, Optionally post your runs and records to Facebook and Twitter. All of your info syncs securely with your free account on www.MapMyRUN.com.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/1.png": "<p>runtastic</p>runtastic is your personal fitness app for all outdoor (running, walking, hiking, biking,...) and indoor activities (treadmill, cardio, yoga, weight lifting). Track your sports and fitness activities – get motivated – burn calories and achieve greater results.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/2.png": "<p>Water Log</p>Water Log is a simple application designed to help remind you to drink water on a daily basis. It can give you notification reminders, as well as be pinned to Start to visually show daily water drinking progress. Use it to track your daily water consumption progress!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/3.png": "<p>Push Up Trainer</p>Push Up Trainer will create a personalized training profile based on your current condition. You can choose a goal of 25, 50 or 100 push ups and the application will guide you through the training sessions, until you reach your defined goal.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/4.png": "<p>MyFitnessPal</p>Lose weight with MyFitnessPal, the fastest and easiest to use calorie counter for Windows Phone 7. With the largest food database of any mobile calorie counter (over 1,200,000 foods), and amazingly fast food and exercise entry, we’ll help you take those extra pounds off! There is no better diet app – period.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/5.png": "<p>Calorie Counter</p>Calorie Counter is the essential app to simply find nutritional info for the food you eat and to keep track of your meals, exercise and weight. The Calorie Counter application has all the cool tools to help you succeed: A food quick pick to find calorie and full nutrition information. A food diary to plan and keep track of what you’re eating. An activity diary to record all the calories you burn.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/6.png": "<p>Daily Yoga for Abs</p>Daily Yoga for Abs provides professional Abs building routine based on a total of 21 yoga asanas, with 3 training durations. We have demonstration videos and voice narration to guide you through the whole sequence. Sessions of 10 minutes, 15 minutes and 20 minutes are provided for varied training targets.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/7.png": "<p>Sound Sleep</p>Sound Sleep is a sleep aid and stress reliever with white noise ambiance and relaxing sounds. Improve your sleep and enhance your mood with Sound Sleep. Relax to calming sounds of nature and ambient music.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/8.png": "<p>Body Fat Calculator</p>Features of this Body Fat Calculator: Calculates all commonly used parameters you need to track body composition changes: Body Fat Mass, Body Mass Index, Waist-to-Hips Ratio and Body Fat Percentage. Supports Imperial and Metric Units (foot/inch/pound and meter/centimeter/kilogram). Designed for Females and Males. Contains section with tips how to make correct body measurements. Works offline, doesn’t need Internet access",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/9.png": "<p>Zombies, Run!</p>You tie your shoes, put on your headphones, take your first steps outside. You’ve barely covered 100 yards when you hear them. They must be close. You can hear every guttural breath, every rattling groan - they’re everywhere. Zombies. There’s only one thing you can do: Run!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/10.png": "<p>100 Pushups</p>An easy to follow training program which will help you reach your goal of being able to do 100 consecutive pushups.For 6 weeks you'll follow a progressive training program that will help you develop your chest muscles, triceps and shoulders. The application will adapt the program to your current fitness level and you'll be able to monitor your progress by examining the logs and chart as you go.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/0.png": "<p>Yelp</p>Looking for a burrito joint open now?  A gas station you can drive to before your tank hits empty?  Yelp for Windows Phone 7 is here to help.  Search for places to eat, shop, drink and play then read reviews from an active community of locals in the know.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/1.png": "<p>Betty Crocker</p>What's for dinner? Ask Betty using the mobile version of the world-famous Betty Crocker cookbook!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/2.png": "<p>OpenTable</p>Restaurant Reservations - Free, Instant, Confirmed.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/3.png": "<p>Allrecipes</p>Allrecipes.com Dinner Spinner is a fun and useful recipe app from the world’s #1 food site, delivering thousands of our members’ favorite quick and easy recipes to your Windows Phone device.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/4.png": "<p>Epicurious Recipes & Shopping List</p>Recipes from the award-winning food site Epicurious.com are now available on your mobile device.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/5.png": "<p>Pizza Hut</p>All your favorites at Pizza Hut are now available on the Windows Phone 7!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/6.png": "<p>Restaurant Inspections</p>Find out what the King County Health Department thinks of your favorite restaurant. Defend yourself and your family from food borne illness for just a few pennies. Live data pulled directly from the King County Health Department; a vast database continuously updated.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/7.png": "<p>Simple Tip</p>Simple Tip is the easiest-to-use tip calculator in the Marketplace. Simple Tip stays true to the Windows Phone Metro style and doesn't have background images that make the screen hard to read or crowd up your screen with a lot of unnecessary clutter.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/8.png": "<p>Chef Pro</p>Chef Pro is your helper in the kitchen! Chef Pro is the definitive application that allows you to access 17,500 recipes divided into categories.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/9.png": "<p>Food Manager</p>Scan or type in your item after your purchase with the corresponding date. The app reminds you before the end of the MHD's and sends them automatically an alarm, the date of expiry.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/10.png": "<p>Find MY Starbucks</p>Find MY Starbucks for Windows Phone provide you an easy way to find a nearby Starbucks Coffee Cafe from your Windows Phone.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png": "<p>Doodle Jump</p>Insanely Addictive! Jump, jump, jump to the top, top, top with the runaway hit now! Guide the Doodler on a springy journey using springs, jet packs and more. Avoid baddies and blast them with your nose balls!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/1.png": "<p>Angry Birds</p>Birds! Slingshots! Destruction! Feathers! Fun! The survival of the Angry Birds is at stake. Dish out revenge on the green pigs who stole the Birds' eggs. Angry Birds features hours of game play, challenging physics-based castle demolition and lots of replay value. Each of the levels requires logic, skill and brute force to crush those greedy pigs!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png": "<p>Free Music Downloader</p>Free music downloader enables users to download Free and Legal Music directly to their phone. Users of any version can download free music files without any limitation. Free Ringtones is a biggest collection of free ringtones available on Window Phone Store.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/1.png": "<p>Free Ringtones</p>Free Ringtones is a biggest collection of free ringtones available on Window Phone Store.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/2.png": "<p>Shazam</p>Hear a song you don’t know? Shazam identifies it instantly.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/3.png": "<p>iHeartRadios</p>iHeartRadio brings you a best-in-class customizable digital listening experience that combines the best of both worlds to deliver everything you want in one free, fully-integrated service: More than 800 of the nation's most popular live broadcast and digital-only radio stations from 150 U.S. cities, plus user-created Custom Stations.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/4.png": "<p>Last.fm</p>www.last.fm is a music recommendation service that lets you effortlessly keep a record of what you listen to and adds it to your Last.fm profile. Based on what you like, Last.fm recommends you more music, concerts and people.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/5.png": "<p>Guitar Hero 5</p>Prepare to rock out on your phone with the newest edition of the #1 selling music series.  Rock out on guitar, drums and bass with up to 32 of the hottest Rock ‘n’ Roll songs and additional downloadable songs from Blink 182, David Bowie, Nirvana, Sublime, Vampire Weekend, and other iconic bands.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/6.png": "<p>OpenMic</p>OpenMic is the karaoke game for your Windows Phone 7 device. Sing along with hits from Kelly Clarkson, Jordin Sparks, and Ke$ha. As you sing, you'll be graded on your performance using the app's built-in pitch detection. You can choose to sing along with the stars, or go it solo and see how well you can do with just you and the band.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/7.png": "<p>BeatBox Free</p>Tired of recording apps which don't let you do anything cool with your recordings? If yes, then BeatBox is for you! Record samples, polish them and make use of in great projects! Projects let you place your samples on a timeline, creating a full track with a plenty of samples.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/8.png": "<p>PMP3 Downloader</p>MP3 Downloader allows you to download MP3 files and store them locally for offline listening. You can download any MP3 file from the Internet and it will be stored in the downloaded MP3 library of this application. MP3 Downloader is a fully featured free application with no ads.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/9.png": "<p>Mixtapes</p>Mixtapes gives you free access to millions of songs organized into mixes by listeners like you. Start listening to great music right away or create an account to track your favorite mixes, songs, and DJs. Stop letting marketing dweebs and computer algorithms pick your music and hear what real people from around the world are listening to.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/10.png": "<p>Accurate Tuner Free</p>Needle and stroboscope chromatic instrument tuner. The needle enables fast and comfortable rough tuning, while two optional stroboscopic animations facilitate fine tuning. Both methods are used at the same time, so it’s not necessary to choose one of them. Detected notes are shown on a musical staff. Adjustable sensitivity will help in not so quiet environments.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/0.png": "<p>CNN</p>CNN connects you to the world, wherever you are. Stay informed with the latest headlines and original stories from around the globe. Follow up-to-the-minute reporting with breaking news alerts and live video. Lead the conversation by sharing today’s news and dig deeper into the stories that matter most to you.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/1.png": "<p>USA TODAY</p>The latest news stories, sports scores, weather and photos you’ve come to expect from USA TODAY are now available for your Windows Phone. Staying informed on the go has never been this quick, easy or enjoyable.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/2.png": "<p>BBC News Mobile</p>Quickly and easily browse, read and share the latest BBC News.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/3.png": "<p>NEWS</p>NEWS is a powerfull newsreader powered by MSNBCs news feeds. Get NEWS today on your Windows Phone 7! The most comprehensive newsreader available and optimized for easy reading on a smartphone.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/4.png": "<p>Fox News</p>With the FOX News app for Windows Phone - read the hottest stories of the day, browse through photo galleries, and watch the latest video clips from FOX News Channel, all for free!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/5.png": "<p>ABC News</p>You can get free latest news updates of ABC News Channel.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/6.png": "<p>News Channels</p>Get all your news needs filled with News Channels",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/7.png": "<p>eWEEK</p>For more than 25-years eWEEK has been the trusted source for the latest news on business-ready IT hardware and software products, expert labs analysis, and guidance for evaluating, acquiring, installing, configuring, and maintaining technology products and services.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/8.png": "<p>Nextgen Reader</p>Dynamic subscriptions hub with featured section to find latest and popular feeds. Read full articles in beautiful clean view powered by Readability, Instapaper or Google mobilizer. Watch YouTube videos, share to social networks like Twitter, Facebook, etc. and save articles to Instapaper, Read It Later & Readability for offline reading.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/9.png": "<p>New York Times</p>All the latest news and headlines from the New York Times",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/10.png": "<p>RapidNews</p>A fast, smooth and highly configurable News reader that lets you browse through 80+ story synopses in one virtual cast. Swipe over collections of local, global and custom breaking news, expand for headlines and sharing, then navigate to the full story or move on.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/0.png": "<p>Evernote</p>This award-winning app lets you remember and recall anything that happens in your life.From notes to ideas to snapshots to recordings, put everything into Evernote and watch as it all instantly synchronizes from your phone to the Web to your PC. New to Windows Phone 7.5 are better social integration, search integration, background synchronization, and pinning of notes, notebooks, tags, searches, maps, and \"new note\" shortcuts audio, text and photo).",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/1.png": "<p>SkyDrive</p>SkyDrive is the place to store your files so you can access them from virtually any device. Windows Phone has built-in access to SkyDrive right from the Office and Pictures hubs. It can also automatically upload pictures that you take to SkyDrive for easy access. Now the SkyDrive app for Windows Phone makes it even easier to manage and share files—all in one place.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/2.png": "<p>Clearer</p>A super sleek and metro todo app that should have been on the windows phone first rather than iphone. Clearer is a much better version of the wildly popular todo app with more features and cooler animations! You have to try it to believe it. Download the trial and give it a shot!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/3.png": "<p>Tasks</p>Put an end to the chaos in your personal affairs with the Tasks app. It will become your best friend for planning, organizing and monitoring the progress of all your projects. Please let us know what you’d like to see in Tasks and we’ll plan accordingly. (We are looking for your feedback to create the next version). Our next major version – 2.0 - will be paid and part of the features below (like Outlook sync and Reminders) will be available only in the paid version.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/4.png": "<p>Timer</p>A simple timer and stopwatch app for Windows Phone. It uses the background capabilities of Windows Phone 7.5 Mango and is able to show alerts even if the app is closed. It is also able to show the next alarm on its live tile. The Timer App uses some new features introduced in Mango. These features allow it to perform actions even when the app is not running. There are a few limitations to these background features! The timer might be some seconds delayed when the app is not running, vibration is not possible for a background alarm and the live tile can only be updated every 30 minutes or when the app is running. So the tile might sometimes show a timer that already started. I hope I can find a way to remove these limitations but currently there doesn't seam to be a way to do this.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/5.png": "<p>All My Passwords</p>{All My Passwords} is the most professional trusted passwords app made for Window Phone 7, all your data will be stored with highly encrypted script to ensure privacy. {All My Passwords} app stores all your private passwords and data in your device after incepting all of it using the most advance encryption process made just for this app (so no one can have access to your data in anyway, even if you lost your phone). {All My Passwords} is a very organized and user friendly app; where you can create folders then add passwords in these folders; even every password has a special category with a special icon.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/6.png": "<p>Network Dashboard</p>Network Dashboard provides a quick, at a glance view into the network status on your Windows Phone. Tap on a tile and you can quickly change the settings. Tap and hold a tile and you can pin it to the Start menu for quick and easy access! REMINDER: When using settings tiles pinned to your start screen, use your Back key to return to start, NOT your Start key. If you don't, your live tiles will get out of sync and any reminders (Paid version) may not work properly.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/7.png": "<p>Mobile Craigslist</p>Craigslist is an extremely fast and accurate Craigslist application on your Windows Phone 7. Extensive list of features:",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/8.png": "<p>Scan</p>Scan is the fastest & most user-friendly QR Code and barcode scanner available. Scan is completely free. There are no \"lite version\" restrictions. It's just simple QR Code and barcode scanning the way it should be. Open the app, point the camera at the code and you’re done! No need to take a photo or press a \"scan\" button like other apps.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/9.png": "<p>Quick Settings</p>The Quick Settings is the essential application for Windows Phone.It can help you quickly opened or closed Airplane Mode, Bluetooth, Cellular, Wi-Fi, and can create independent Quick Tile. The design is simple and free, no ads, you will like it, hurry to download experience it!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/10.png": "<p>Tiled Notes</p>Create a note and pin it to your home screen as a great reminder! <p>- Create/modify/delete multiple live tiles</p><p>- Enable flip to back tile</p><p>- Set background as an image</p><p>- Edit the background color</p><p>- Modify the font size/color/family</p><p>- More upgrades and features to come soon!</p><p>- Added a clear button</p>",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/0.png": "<p>eBay</p>The eBay Mobile application is designed specifically for Windows Phone. Using a streamlined interface that's as elegant as it is practical, eBay members can search, bid, and check their activity on the go. Buyers can submit that last-minute bid on a hard-to-find item, sellers can check on their sales, and act on time-sensitive information on the spot without a computer. eBay is open for business anytime, anywhere on Windows Phone!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/1.png": "<p>PayPal</p>Enjoy PayPal on-the-go with the PayPal Windows Phone app.<p>SEND & REQUEST MONEY<br \>Whether you want to send money as a gift or pay back a loan from a friend – sending money is easy and FREE (when using a bank account or PayPal balance as the funding source)</p><p>MANAGE YOUR ACCOUNT<br \>Check your balance, withdraw funds or view past transactions – anytime, anywhere</p>",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/2.png": "<p>Groupon</p>Groupon features 50%-90% off deals on the best stuff to do, eat, see and buy. Discover your town and the world with Daily Deals, Now! Deals, and Getaway deals. Groupon is available in more than 500 cities around the world, and we add new cities and deals every day.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/3.png": "<p>Amazon Mobile</p>Search & buy millions of products right from your Windows Phone device. The Amazon Mobile App allows Windows Phone users to quickly search, compare prices, read reviews, share products with friends, access Gold Box Deals, and make purchases on Amazon using a simple, yet elegant, interface. To make on-the-go shopping and price comparison even easier, the Amazon Mobile App includes helpful shopping features that allow users to scan a barcode or type a search to quickly compare prices and check availability. Users may also save time by pinning the Amazon barcode scan tile to their Start screen, enabling them to simply tap the tile to take them straight to the barcode scanner.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/4.png": "<p>ATM Hunter</p>Find ATMs located around the world with your Windows Phone’s GPS, by entering an address or an airport location, from wherever you happen to be. You can also find merchants who accept MasterCard® PayPass™.The MasterCard ATM Hunter makes it fast and easy for you to locate the closest ATM location and PayPass acceptance locations. And because the ATM Hunter is location aware, there’s no need to input your address or current location, no matter where in the world you are. The ATM Hunter lets you tailor your search on what you want to do. If you need to make an ATM deposit or want to use your own bank to avoid fees, you can search for your specific bank’s ATMs. If you just need to pick up some cash, you can search for all nearby ATM locations.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/5.png": "<p>myShopi</p>Speed up your shopping with myShopi, the shopping list for all! myShopi, the free shopping list, speeds up your shopping and enables you to save time. The interface is SIMPLE and INTUITIVE and has many images.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/6.png": "<p>Starbucks Finder</p>Let Starbucks Finder quench your coffee craving! Find your closest, open Starbucks stores and pay with your phone. Mobile payment: Pay with your phone! You can pay for your favorite Starbucks drink with your Windows Phone. Just add your Starbucks card number to the app and your barcode is ready to swipe! The app supports multiple Starbucks cards. We take security extremely seriously— your Starbucks card is stored locally on your phone and your card information is never transmitted over the internet.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/7.png": "<p>Discount Calc Plus</p>Discount Calculator helps you compute and track your savings from a product discount. Quickly enter the price of the product, discount percent, and the number of items to compute your savings and your total amount. You can also enter the sales tax percent of your state to compute the tax amount and add this to the total amount of your purchase. Finally, you now save and track your discounts.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/8.png": "<p>Newegg</p>This is the Newegg.com official mobile application. The app allows Windows Phone 7 users to search, shop, read reviews and make purchases on Newegg.com.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/9.png": "<p>The Home Depot</p>The Home Depot app provides the ability to research and purchase over 100,000 products directly from within the app. Now you can find all the details you want and purchase the products that you need right from your mobile device. Now it’s easier than ever for you to get inspired, search, plan, shop and get more done on the go.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/10.png": "<p>Shared Shopping List</p>Have you ever been disappointed when your spouse walked in with the groceries, but didn’t get the coffee you so desperately needed? Ever ended up with 4 gallons of milk in the fridge because each roommate went shopping separately? With the Shared Shopping List, any number of Windows Phones can share the same set of lists, and these woes are a thing of the past.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/0.png": "<p>Facebook</p>Facebook for Windows Phone makes it easy to stay connected and share information with friends. You can post status updates, receive Live Tile updates, check your news feed, review upcoming events, check in to places, manage your inbox, upload photos, publish notes, accept friend requests, pin Places and Messages as Tiles, and look at your friends’ photos, walls and info.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/1.png": "<p>Twitter</p>Discover what’s happening right now, anywhere in the world, with the official Twitter for Windows Phone app. Tweets, real-time search, Suggested users, top Tweets, trending topics and maps show what's happening everywhere—and nearby. ",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/2.png": "<p>WhatsApp</p>WhatsApp Messenger is a smartphone messenger available for Windows Phone, Android, BlackBerry, iPhone, and Nokia phones. WhatsApp uses your 3G or WiFi (when available) to message with friends and family. Switch from SMS to WhatsApp to send and receive messages, pictures, audio notes, and video messages. First year FREE! ($0.99/year after)",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/3.png": "<p>LinkedIn</p>Get on-the-go access to your professional network with LinkedIn for Windows Phone. Find and connect with more than 161M members worldwide, read the latest industry news, keep up-to-date with your groups, explore jobs you might be interested in, and share content with your network from anywhere.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/4.png": "<p>foursquare</p>foursquare helps you explore the world around you. Meet up with friends. Find places to go. Save money with Specials. Have fun exploring!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/5.png": "<p>Free Talk</p>Google voice provides free SMS and cheap international and long distance calling. Now you can do all of that without paying for a Google Voice client as well. With FreeTalk you can send SMS, make calls thru Google Voice, view and manager your inbox, listen to your voicemail and do lot more. And that’s free",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/6.png": "<p>Groups for FB</p>Finally, a way to access all of your Facebook Groups right on your Windows Phone 7 device, in a lovely, easy to use, native Mango application!  Get the groups support that the official Facebook application lacks!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/7.png": "<p>Talk2Me</p>Send and receive recorded voice messages to other Talk2Me users.  Full Mango 7.5 support for Fast App Resume, Push Notifications and two side tiles. Trial has no limits and is ad supported.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/8.png": "<p>Kik Messenger</p>14 million users love Kik! It is the fast, simple, and personal smartphone messenger that connects you to everyone you love to talk to.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/9.png": "<p>Holidays Calendar</p>Holidays Calendar is a nice and simple app that lists various types of holidays: career holidays, national and international holidays, special days and more.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/10.png": "<p>Radar Rabbit</p>Radar Rabbit takes your privacy and safety very seriously. All communication between members on Radar Rabbit happens through an “anonymous” chat service. Only approximate member locations are shown or recorded.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/0.png": "<p>ESPN ScoreCenter</p>ESPN ScoreCenter brings you scores, news, and standings from hundreds of sports leagues around the world.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/1.png": "<p>Baseball Live</p>Tired of sports apps that redirect to a website? Baseball Live provides you the latest news and results in Major League Baseball.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/2.png": "<p>College Football Scoreboard</p>Updated with 2012-13 Schedules & Scores",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/3.png": "<p>Basketball Live</p>Basketball Live provides you the latest news and results in the NBA!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/4.png": "<p>Tennis Live</p>Tennis Live provides you the latest news and results in tennis.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/5.png": "<p>Baseball Pro '12</p>Never miss another game again!, whether you follow your favorite Baseball Team or glance at every single game, Baseball Pro '12 offers you the most comprehensive coverage available on your Windows Phone.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/6.png": "<p>Real Soccer</p>Get ready for a soccer season and battle for the cup with Real Soccer, the benchmark for mobile soccer games. Choose from 245 teams in 8 leagues with nearly every player thanks to the FIFPro license. Face off in 14 stadiums detailed in 3D as you perform amazing moves with a simple and intuitive touch of the screen.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/7.png": "<p>Run The Map</p>Run The Map is a route recorder/analyzer for your outdoor activities (walking, running, biking, etc.). Run The Map represents your tracks on a map in real time and shows you the related information (distance, duration, speed, altitude, etc.). You can then save your results by exporting them or obtain statistics from the data stored in your phone. ",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/8.png": "<p>QuickScores</p>Simple app to get Live sports scores without all the fluff. You can get live sports scores for The National Football League NFL , College NCAA Football, Magor League Baseball MLB, National Basketball Association NBA, College NCAA Basketball, and the National Hockey League NHL.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/9.png": "<p>All Sports News</p>ALL SPORTS NEWS is a powerful sports news reader bringing all the latest news from ESPN to your phone.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/10.png": "<p>Simple Skore</p>Simple Skore is a scoring application which can be used to keep score for two teams in events such as soccer, basketball, baseball, etc.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/0.png": "<p>TripAdvisor</p>All-new design, optimized for Windows Phone and Metro. Plan and have your perfect trip with TripAdvisor. With over 50 million reviews and opinions by real travelers, you'll find the best places to eat, sleep, and play, wherever you travel. TripAdvisor is free and easy to use: •Find hotels, restaurants, and attractions in any destination •Use Near Me Now to discover options near you or any address you enter •My Saves: save hotel, restaurant, and attraction pages so you can find them again easily",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/1.png": "<p>Skyscanner</p>Flight search from Skyscanner. Need a cheap flight, fast? Search millions of routes on over 1,000 airlines and find the lowest priced flights in seconds with the free Skyscanner app for Windows Phone; saves money, saves time. Buy air tickets direct from airlines or travel agents and get the best deals. It’s simple, independent and finds the lowest fares with a few quick taps, wherever you want to fly.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/2.png": "<p>Flight Status</p>This simple program allows you to keep you informed about departure time, departure terminal and gate, arrival time, arrival terminal and gate and the current status of each flight. You can also activate notifications for each aircraft, by which the program will automatically check for updated information about the flights, even though the program is not running. If there has been an update on a flight you will be informed about this.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/3.png": "<p>Find places</p>Features:- Software to find the location nearest you like to find the stadium, restaurants, hotels, banks, schools, etc.- You can customize the search distance.- Built-in compass to measure the speed and makes it easier to move.- Quick navigation and favorites function enables the use of more easily.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/4.png": "<p>Mapy.cz</p>To find the nearest restaurant, cinema or ATM? With Mapy.cz it will be a breeze! Full-featured maps that you can know from www.mapy.cz have Mapy.cz simply by the application in your mobile. There are current map layers - basic, airline, tourist and historical.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/5.png": "<p>Mango Transit</p>Public transit directions, Mango style. Powered by Bing and Nokia. Mango Transit is the most advanced public transit app for Windows Phone. It is designed to be an extension of the native Map app.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/6.png": "<p>My Trips</p>The most highly rated and advanced TripIt.com companion app. Now you can take your TripIt.com plans with you on your phone when you travel! (and edit them!) My Trips connects with the premier travel organization website TripIt.com to synchronize your travel plans and allows you to take it with you on your travels. After you have synchronized My Trips works offline so you don't need a Wi-Fi or mobile internet connection to view your travel plans (handy when you are 30,000 feet up!).",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/7.png": "<p>Good Hotel Guide</p>Hotels and B&Bs of quality and character from the UK's no1 independent hotel guide. The Good Hotel Guide, first published 34 years ago, is totally independent. It receives no payments, hospitality or advertising from hotels selected for an entry in the printed Guide. Hotels pay an administration fee to be on the GHG website and GHG app, but only those hotels that have a free entry in the print edition are eligible. The Guide includes budget B&Bs, good-value hotels as well as luxurious country houses. The hotels that we write about in our Guide are by definition outstanding. It is always based on what our readers tell us backed up by anonymous visits by experienced inspectors.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/8.png": "<p>Compass</p>Compass is a beautiful, free, and easy-to-use compass for your Windows Phone 7.5 (Mango). It allows you to pick a theme from one of the available themes to customize it to your liking. NOW with Gyroscope sensor support to improve real-time motion detection. NOTE: Gyroscope is not required for the Compass to function though you would get better responsiveness in case the phone has one.",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/9.png": "<p>Hertz Car Rental</p>Need a rental car reservation fast? Or have a reservation and need to make a change? Hertz provides speed, savings, and selection at your fingertips. Save your parking spot to find your car quickly & find the nearest gas station. Be sure to enjoy your journey - start with Hertz - we give you all the benefits of car rental in the palm of your hand. With the Hertz Car Rental mobile app, you'll be Travelling at the Speed of Hertz!",
            "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/10.png": "<p>American Airlines</p>Introducing the travel app that understands who you are and where you’re going. From where you’re departing and from what gate. Where you’ll sit and even where you are on the standby list. Get your personalized America Airlines travel information by downloading the app that’s perfect for flying through airports."
        };
        /* var colors = new Array();
        colors[0] = "AA00FF";
        colors[1] = "60A917";
        colors[2] = "008A00";
        colors[3] = "00ABA9";
        colors[4] = "1BA1E2";
        colors[5] = "6A00FF";
        colors[6] = "AA00FF";
        colors[7] = "F472D0";
        colors[8] = "D80073";
        colors[9] = "A20025";
        colors[10] = "E51400";
        colors[11] = "FA6800";
        colors[12] = "F0A30A";
        colors[13] = "E3C800";
        colors[14] = "825A2C";
        colors[15] = "6D8764";
        colors[16] = "647687";
        colors[17] = "76608A";
        colors[18] = "87794E";
        colors[19] = "0050EF";
        colors[20] = "D80073";*/
        var color;
        var curColor = $(".apps").css("background-color");
        var colorIndex = 0;
        var targetApp;

        /* Change the background color of the startscreen */
        $(".colorinput").click(function () {
            color = $(this).attr("id");
            $(".apps").css("background-color", color);
        })

        /* Show the apps lists after click on one app on the startscreen */
        $(".apps").click(function () {
            targetApp = $(this);
            if (targetApp.attr("name") != "large") {
                $("#appspool").attr("style", "visibility:visible; position:absolute; left:0px; top:0px; ");
                $("#bg1").attr("style", "visibility:hidden;");
                $("#bg2").attr("style", "visibility:block;");
                //$(".bg").attr("src", "http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_2.png")
                //$(".bg").attr("style", "position:absolute; width:455; height:454; left: 104px; top: 235px;");
                $("#apptext").attr("style", "visibility:hidden;");
                $("#apptitle").attr("style", "position:absolute; top:-123px; left:0px;");
            }
        })

        /* Hide the apps lists after choosing and swap */
        $(".appsinput").click(function () {
            if (null != targetApp) {
                if (targetApp.attr("name") != "large") {
                    targetApp.attr("src", $(this).attr("src"));
                    document.getElementById(targetApp.attr("id") + "font").innerHTML = $(this).attr("value"); // change the app text
                }
                if (targetApp.attr("id") == "pic0") {
                    picid_num++;
                    targetApp.attr("id", "pic" + picid_num);
                }
                $("#appspool").attr("style", "position:absolute; visibility:hidden;");
                $("#bg2").attr("style", "visibility:hidden;");
                $("#bg1").attr("style", "visibility:block;");
                //$(".bg").attr("src", "http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_1.png")
                //$(".bg").attr("style", "width:455; height:329; left: 200px; top: 600px;left: 104px;top: 362px;position: absolute;");
                $("#apptext").attr("style", "visibility:block;position:absolute; top:40px; left:0px;");
                $("#apptitle").attr("style", "position:absolute; top:8px; left:0px;");
            }
        })

        /* Choose the template */
        $(".templateinput").click(function () {
            var templateId = $(this).attr("id");
            inputData("template", templateId);
            var colorId = color;
            inputData("color", colorId);
            document.forms["form_change"].submit();
        })

        function inputData(formname, formvalue) {
            var element = document.createElement("input");
            element.setAttribute("name", formname);
            element.setAttribute("value", formvalue);
            element.setAttribute("type", "hidden");
            var foo = document.getElementById("form_change");
            foo.appendChild(element);
        }

        $(".apps").mouseover(function () {
            var pic = $(this).attr("src");
            var dp = appDescription[pic];
            if (dp != null) {
                $("#descriptionbox").attr("style", "visibility:block; background-color:#3FA9F5;height:360px;width:280px;position:absolute; left:880px; top:274px; color:White;");
                $("#description").append(dp);
            }
        })
        $(".appsinput").mouseover(function () {
            var pic = $(this).attr("src");
            var dp = appDescription[pic];
            if (dp != null) {
                $("#descriptionbox").attr("style", "visibility:block; background-color:#3FA9F5;height:360px;width:280px;position:absolute; left:880px; top:274px; color:White;");
                $("#description").append(dp);
            }
        })

        $(".apps").mouseout(function () {
            $("#description").empty();
            $("#descriptionbox").attr("style", "visibility:hidden;");
        })
        $(".appsinput").mouseout(function () {
            $("#description").empty();
            $("#descriptionbox").attr("style", "visibility:hidden;");
        })
    })
</script>

<body style="margin:0px 0px; padding:0px;background-image:url('http://www.etc.cmu.edu/projects/up-plus/journey_images/backimage.jpg');
	font-family: Arial, Arial Bold;
	overflow:hidden;">
    <!--<button type="button" id="changeColor">Change color</button>-->
    
    <form id="form1" runat="server"></form>

    <div style = "position:absolute;  color:White; font-family: Arial, Arial Bold; font-size:300%; top: 80px; left: 110px;">
        <p id="phonetitle" runat="server"></p>
    </div>
    <div id="startscreentitle" style="background-color:#3FA9F5;height:90px;width:90%;margin-left:5%;" ></div>
    <div id="descriptionbox" style="visibility:hidden;"><p id="descriptionname" style="position:relative; top:5px; left:10px;width:260px;text-align:left;"></p><p id="description" style="position:relative; top:5px; left:10px;width:260px;text-align:justify;"></p> </div>
    <div>
        <div id="bg1" style="visibility:block;">
        &nbsp;<img class="bg" 
                src="http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_1.png" 
                style="width:455; height:329;left: 104px;top: 360px;position: absolute;opacity:"/>      
        </div>
        <div id="bg2" style="visibility:hidden;">
        &nbsp;<img class="bg" 
                src="http://www.etc.cmu.edu/projects/up-plus/images/tweak/tweak_bg_2.png" 
                style="position:absolute; width:455; height:454; left: 104px; top: 235px;"/>      
        </div>
        <div style = "margin-left: 100px; margin-top: 30px; position:absolute;  color:White; font-family: Arial, Arial Bold; font-size:100%; top: 345px; left: 22px; width: 482px; height: 50px;">
        <div id="apptitle" style = "position:absolute; top:8px; left:0px;">Change Apps</div>
            <br /><div id="apptext" style="visibility:block;position:absolute; top:40px; left:0px;">Click on the app you want to change</div>
        </div>
        <div id = "appspool" style="visibility:hidden;">
            <div style = "margin-left: 100px; margin-top: 0px; position:absolute;color:White; font-family: Arial, Arial Bold; font-size:100%; top: 285px; left: 14px; width: 428px;">
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png" value = "Phototastic Free" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/1.png" value = "Netflix" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/0.png" value = "Amazon Kindle" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Books&Refernce/1.png" value = "Wikipedia" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Fitness/0.png" value = "MapMyRUN" style="width:48px; height:48px;"/>           
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Video&Movie/0.png" value = "YouTube" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/0.png" value = "Yelp" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Food&Restaurants/1.png" value = "Betty Crocker" style="width:48px; height:48px;"/>
                <br />
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png" value = "Doodle Jump" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/1.png" value = "Angry Birds" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png" value = "Free Music Downloader" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/1.png" value = "Shazam" style="width:48px; height:48px;"/> 
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/0.png" value = "CNN" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/News/1.png" value = "USA TODAY" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/0.png" value = "Evernote" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Organization/1.png" value = "SkyDrive" style="width:48px; height:48px;"/>
                <br />
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/0.png" value = "eBays" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Shopping&Finance/1.png" value = "PayPal" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/0.png" value = "Facebook" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Social/1.png" value = "Twitter" style="width:48px; height:48px;"/>            
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/0.png" value = "ESPN ScoreCenter" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Sports/1.png" value = "Baseball Live" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/0.png" value = "TripAdvisor" style="width:48px; height:48px;"/>
                <img class="appsinput" src="http://www.etc.cmu.edu/projects/up-plus/images/tiles/Travel&Navigation/1.png" value = "Skyscanner" style="width:48px; height:48px;"/>
            </div>
        </div>

        <div id = "colors" style="display:block;">   
            <div style = "margin-left: 100px; margin-top: 10px; position:absolute;color:White; font-family: Arial, Arial Bold; font-size:100%; top: 545px; left: 5px; width: 470px; height: 150px;">
                    &nbsp;&nbsp;&nbsp;Change colors
                <br />
                <div style="width: 352px; height: 67px; margin-top: 0px;">
                <div style="width: 43px; height: 44px; margin-top: 8px;margin-left: 392px;"><img class="colorinput" id="#f0a30a" 
                        src="images/colors/amber.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 347px;"><img class="colorinput" id="#825a2c" src="images/colors/brown.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 304px;"><img  class="colorinput" id="#0050ef" src="images/colors/cobalt.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 262px;"><img  class="colorinput" id="#a20025" src="images/colors/crimson.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 217px;"><img  class="colorinput" id="#1ba1e2" src="images/colors/cyan.png" style="width: 43px; height: 44px;"/></div>       
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 0px;"><img  class="colorinput" id="#008a00" src="images/colors/emerald.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 44px;"><img  class="colorinput" id="#60a917" src="images/colors/green.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 89px;"><img  class="colorinput" id="#6a00ff" src="images/colors/indigo.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 133px;"><img  class="colorinput" id="#a4c400" src="images/colors/lime.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 174px;"><img  class="colorinput" id="#d80073" src="images/colors/magenta.png" style="width: 43px; height: 44px;"/></div>
                <br />
                <div style="width: 43px; height: 44px; margin-top: -19px;margin-left: 392px;"><img  class="colorinput" id="#76608a" src="images/colors/mauve.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 348px;"><img  class="colorinput" id="#6d8764" src="images/colors/olive.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 306px;"><img  class="colorinput" id="#FA6800" src="images/colors/orange.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 42px; height: 44px; margin-top: -44px;margin-left: 262px;"><img  class="colorinput" id="#F472D0" src="images/colors/pink.png" style="width: 42px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 218px;"><img  class="colorinput" id="#E51400" src="images/colors/red.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 174px;"><img  class="colorinput" id="#7a3b3f" src="images/colors/sienna.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 130px;"><img  class="colorinput" id="#647687" src="images/colors/steel.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 44px; height: 44px; margin-top: -44px;margin-left: 88px;"><img  class="colorinput" id="#00ABA9" src="images/colors/teal.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 43px; height: 44px; margin-top: -44px;margin-left: 43px;"><img  class="colorinput" id="#AA00FF" src="images/colors/violet.png" style="width: 43px; height: 44px;"/></div>
                <div style="width: 44px; height: 44px; margin-top: -44px;margin-left: -1px;"><img  class="colorinput" id="#d8c100" src="images/colors/yellow.png" style="width: 43px; height: 44px;"/></div>
                </div>
            </div>
        </div>

        <div id = "templates" style="display:block;">
            <div style = "margin-left: 100px; margin-top: 10px; position:absolute;color:White; font-family: Arial, Arial Bold; font-size:100%; top: 439px; left: 20px; width: 486px; height: 142px;">
                <div>Change templates
                </div>
                <div style="margin-top: 12px; height: 75px;"><img class="templateinput"  id="0" src="images/templates/template1.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="1" src="images/templates/template2.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="2" src="images/templates/template3.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="3" src="images/templates/template4.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="4" src="images/templates/template5.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="5" src="images/templates/template6.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="6" src="images/templates/template7.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="7" src="images/templates/template8.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="8" src="images/templates/template9.png" style="width:36px; height:63px;"/>
                <img class="templateinput"  id="9" src="images/templates/template10.png" style="width:36px; height:63px;"/>
                </div>
            </div>
            <br />
        </div>
    </div>
    <div id="starscreentiles" runat="server"></div>
    <div style="background-color:#3FA9F5;top:800px;left:60px;height:90px;width:1150px; position:absolute;" ></div>
    <form id="form_change" method="get" action="StartScreen.aspx" name="thisForm"></form>		
    </body>
</html>
