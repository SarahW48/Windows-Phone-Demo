using System;

// Define the delegate that represents the event.
public delegate void PriceChangedEventHandler();

public class Tile
{
    public string Name { get; set; }

    // Define the event.
    public event PriceChangedEventHandler PriceChanged;

    private string color;
    private string x;// start point
    private string y;
    private string size;
    public string path;
    private string width;
    private string length;


    public string ImageUrl { get; set; }

    public string GetHtml()
    {
        string htmlString;
        htmlString = "<h1>" + Name + "</h1><br>";

        htmlString += "<img src='" + path + "' style=' background-color:" + color + ";position:absolute; left:" + x.ToString() + "; top:" + y.ToString() + "; width:" + width + "; length:" + length + ";'/>";
        return htmlString;
    }



    public Tile(string tilePath, string tileColor, string tx, string ty, string tsize)
    {
        color = tileColor;
        path = tilePath;
        x = tx;
        y = ty;
        size = tsize;
        if (size == "1")
        {
            width = "47px";
            length = "47px";
        }
        else if (size == "2")
        {
            width = "100px";
            length = "100px";
        }
        else if(size=="3")
        {
            width = "205px";
            length = "85px";

        }

    }
}

