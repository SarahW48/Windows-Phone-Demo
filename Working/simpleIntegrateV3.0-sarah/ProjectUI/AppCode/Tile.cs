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
    private string username;
    private string importantname;
    private string picid;
    private string name;


    public string ImageUrl { get; set; }

    public string GetHtml()
    {
        string htmlString;

       if (path == "images/tiles/build-in/mail_L.png")
        {
      
            htmlString = "<div style=\"background:url('" + path + "'); background-size:205px 99px; background-color:" + color + "; left:" + x.ToString() + "; top:" + y.ToString() + "; width: 205 px; height: 99px; position: absolute\">";
            htmlString += "<div style=\"margin-left: 5px\">";
            htmlString += "<p style= \"margin-top: 1px\";><font size=\"3\" color=\"white\">" + username + "</font><br>";
            htmlString += "<font size=\"1\" color=\"white\">" + importantname + " said: Don't forget brunch!</font></p>";
            htmlString += "</div>";
            htmlString += "</div>";
        }

        else
        {
            htmlString = "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div style=\"background-image:url('images/tiles/app.png'); background-color:" + color + ";left:0px; top:0px; width:" + width + ";height:" + length + "; position: absolute\"> ";
            htmlString += "<div style=\"position:absolute;margin-left:5px;bottom: 0px\">";
            htmlString += "<b><font size=\"3\" color=\"white\">" + name + "</font></b>";
            htmlString += "</div></div></div>";
            //htmlString = "<img src='" + path + "' style=' background-color:" + color + ";position:absolute; left:" + x.ToString() + "; top:" + y.ToString() + "; width:" + width + "; length:" + length + ";'/>";
            //htmlString = "<img src= \"images/tiles/violet.png\" style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; width:" + width + "; length:" + length + "; z-index:-1\">";
            htmlString += "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div style=\"position:absolute; left:0px; top:0px\">";
            htmlString += "<img id = \"pic" + picid + "\" src='" + path + "' style=' background-color:" + color + ";position:absolute; width:" + width + "; length:" + length + ";'/>";
            htmlString += "</div> </div>";

        }
        return htmlString;
    }



    public Tile(string tilePath, string tileColor, string tx, string ty, string tsize, string name1, string name2, int pic, string tilename)
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
        username = name1;
        importantname = name2;
        picid = pic.ToString();
        name = tilename;
    }
}

