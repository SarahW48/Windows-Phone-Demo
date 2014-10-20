/* Summary: this is the tile object 
 * this object cntains the information of the tiles
 */
using System;

/* Define the delegate that represents the event.
 * public delegate void PriceChangedEventHandler();
 */
public class Tile
{
    public string Name { get; set; }
    private string color;
    private string x;// start point
    private string y;
    private string size;
    public string path;//image path
    private string width;
    private string length;
    private string username;
    private string importantname;
    private string emailtext;
    public static int standard_length = 50, standard_boundary = 1, start_x = 620, start_y = 272;
    private string picid;
    private string name;

    public string ImageUrl { get; set; }

    public string GetHtml()
    {

        string htmlString;
        if (path == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/buildin/hotmail_L.png")
        {

            htmlString = "<div class=\"apps\" name=\"large\" style=\"background:url('" + path + "'); background-size:" + standard_length * 4  + "px " + (standard_length * 2 - standard_boundary * 2) + "px; background-color:" + color + "; left:" + x.ToString() + "px; top:" + y.ToString() + "px; width: " + standard_length * 4  + "px; height: " + (standard_length * 2 - standard_boundary * 2) + "px; position: absolute\">";
            htmlString += "<div style=\"margin-left: 5px\">";
            htmlString += "<p style= \"margin-top: 1px\";><font size=\"3\" color=\"white\">" + importantname + "</font><br>";
            htmlString += "<id = \"email\">" + emailtext + "</font></p>";
            htmlString += "</div>";
            htmlString += "</div>";
        }
        else if ((path == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Music/0.png") || (path == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Games/0.png") || (path == "http://www.etc.cmu.edu/projects/up-plus/images/tiles/Camera&Photo/0.png"))
        {
            htmlString = "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div class=\"apps\" style=\"background-image:url('http://www.etc.cmu.edu/projects/up-plus/images/app.png'); background-color:" + color + ";left:0px; top:0px; width:" + width + ";height:" + length + "; position: absolute\"> ";
            htmlString += "<div style=\"position:absolute;margin-left:5px;bottom: 0px\">";
            htmlString += "<b><font id = \"pic" + picid + "font\" size=\"1\" color=\"white\">" + name + "</font></b>";
            htmlString += "</div></div></div>";
            htmlString += "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div style=\"position:absolute; left:0px; top:0px\">";
            htmlString += "<img class=\"apps\" name=\"large\" value = \"\" id = \"pic" + picid + "\" src='" + path + "' style=' background-color:" + color + ";position:absolute; width:" + width + "; length:" + length + ";'/>";
            htmlString += "</div> </div>";
        }

        else if (path == "http://www.etc.cmu.edu/projects/up-plus/images/contact.png")
        {
            htmlString = "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div class=\"apps\" style=\"background-image:url('http://www.etc.cmu.edu/projects/up-plus/images/app.png'); background-color:" + color + ";left:0px; top:0px; width:" + width + ";height:" + length + "; position: absolute\"> ";
            htmlString += "<div style=\"position:absolute;margin-left:5px;bottom: 0px\">";
            htmlString += "<b><font id = \"pic" + picid + "font\" size=\"1\" color=\"white\">" + importantname + "</font></b>";
            htmlString += "</div></div></div>";
            htmlString += "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div style=\"position:absolute; left:0px; top:0px\">";
            htmlString += "<img class=\"apps\" name=\"ms\" value = \"\" id = \"pic" + picid + "\" src='" + path + "' style='background-color:" + color + ";position:absolute; width:" + width + "; length:" + length + ";'/>";
            htmlString += "</div> </div>";
        }
        else
        {
            htmlString = "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div class=\"apps\" style=\"background-image:url('http://www.etc.cmu.edu/projects/up-plus/images/app.png'); background-color:" + color + ";left:0px; top:0px; width:" + width + ";height:" + length + "; position: absolute\"> ";
            htmlString += "<div style=\"position:absolute;margin-left:5px;bottom: 0px\">";
            htmlString += "<b><font id = \"pic" + picid + "font\" size=\"1\" color=\"white\">" + name + "</font></b>";
            htmlString += "</div></div></div>";
            htmlString += "<div style=\"position:absolute; left:" + x.ToString() + "px; top:" + y.ToString() + "px; clip:rect(0px," + width + "," + length + ",0px);\">";
            htmlString += "<div style=\"position:absolute; left:0px; top:0px\">";
            htmlString += "<img class=\"apps\" name=\"ms\" value = \"\" id = \"pic" + picid + "\" src='" + path + "' style=' background-color:" + color + ";position:absolute; width:" + width + "; length:" + length + ";'/>";
            htmlString += "</div> </div>";
        }
        return htmlString;
    }

    public Tile(string tilePath, string tileColor, string tx, string ty, string tsize, string name1, string name2, string text, string pic, string tilename)
    {
        color = tileColor;
        path = tilePath;
        x = tx;
        y = ty;
        size = tsize;
        if (size == "1")
        {
            width = (standard_length-standard_boundary*2) + "px";
            length = (standard_length-standard_boundary*2) + "px";
            
        }
        else if (size == "2")
        {
            width = (standard_length * 2 - standard_boundary ) + "px";
            length = (standard_length * 2 - standard_boundary * 2) + "px";
        }
        else if (size == "3")
        {
            width = standard_length * 4  + "px";
            length = (standard_length * 2 - standard_boundary * 2) + "px";
        }
        username = name1;
        importantname = name2;
        emailtext = text;
        picid = pic;
        name = tilename;
    }
}
