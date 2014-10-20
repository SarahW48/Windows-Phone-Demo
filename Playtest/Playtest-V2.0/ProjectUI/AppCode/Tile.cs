using System;

// Define the delegate that represents the event.
public delegate void PriceChangedEventHandler();

public class Tile
{
    public string Name { get; set; }

    // Define the event.
    //public event PriceChangedEventHandler PriceChanged;

    private string color;
    private string x;// start point
    private string y;
    private string size;
    public string path;
    private string width;
    private string length;
    private string username;
    private string importantname;
    private string emailtext;
    public static int standard_length = 50, standard_boundary = 1, start_x = 600, start_y = 100;


    public string ImageUrl { get; set; }

    public string GetHtml()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        string htmlString;

        if (path == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/build-in/mail_L.png")
        {

            htmlString = "<div class=\"apps\" style=\"background:url('" + path + "'); background-size:225px 99px; background-color:" + color + "; left:" + x.ToString() + "; top:" + y.ToString() + "; width: 205 px; height: 99px; position: absolute\">";
            htmlString += "<div style=\"margin-left: 5px\">";
            htmlString += "<p style= \"margin-top: 1px\";><font size=\"3\" color=\"white\">" + importantname + random.Next(1, 5) + "</font><br>";
            //htmlString += "<font size=\"1\" color=\"white\">" + importantname + " said: Don't forget brunch!</font></p>";
            htmlString += "<font size=\"1\" color=\"white\">" + emailtext + "</font></p>";
            htmlString += "</div>";
            htmlString += "</div>";
        }

        //这儿要加一堆就是使call和message上面随机数字，随机方法如上
        //
        //
        else
        {
            htmlString = "<img class=\"apps\" src='" + path + "' style=' background-color:" + color + ";position:absolute; left:" + x.ToString() + "; top:" + y.ToString() + "; width:" + width + "; length:" + length + ";'/>";
        }
        return htmlString;
    }



    public Tile(string tilePath, string tileColor, string tx, string ty, string tsize, string name1, string name2, string text)
    {
        color = tileColor;
        path = tilePath;
        x = tx;
        y = ty;
        size = tsize;
        if (size == "1")
        {
            width = (standard_length - standard_boundary * 2) + "px";
            length = (standard_length - standard_boundary * 2) + "px";

        }
        else if (size == "2")
        {
            width = (standard_length * 2 - standard_boundary) + "px";
            length = (standard_length * 2 - standard_boundary * 2) + "px";
        }
        else if (size == "3")
        {
            width = (standard_length * 4 - standard_boundary) + "px";
            length = (standard_length - standard_boundary * 2) + "px";
        }
        username = name1;
        importantname = name2;
        emailtext = text;
    }
}