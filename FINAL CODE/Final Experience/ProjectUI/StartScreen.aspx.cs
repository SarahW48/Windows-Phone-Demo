/* StartScreen.aspx.cs
 * 
 * Summary: Receive data from the frontend and compute the weight for each catefory, 
 *          choose one category from popular apps group and one category from the 
 *          non-popular apps group, then generate the startscreen with random template, 
 *          add lock screen and title in the final page
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ProjectUI.AppCode;//.ScreenTemplate;
using System.Data.SqlClient;
using System.Web.Configuration;//passing sonnection string

public partial class StartScreen : System.Web.UI.Page
{
    // How many pictures to choose from 
    // Question num changed and category changed 
    const int popularCtgCnt = 5;
    const int nonpopularmaxCtgCnt = 7;

    // Index for the questions that has multiple answers 
    const int FOURAWNSERQS1 = 0;
    const int FOURAWNSERQS2 = 2;
    const int FOURAWNSERQS3 = 4;
    const int THREEAWNSERQS1 = 13;
    const int SEVENAWNSERQS1 = 3;
    const int SEVENAWNSERQS2 = 6;
    const int FIVEAWNSERQS1 = 12;
    const int EIGHTAWNSERQS1 = 10;
    // Total question numbers 
    static int questionNum = 14;
    // Total picture numbers 
    static int pictureTotal = 54;
    static int[] jrnInput = new int[pictureTotal];
    int ctgrNum = GenerateTileInfo.ctgrNum;
    // The weight matrix for popular categories 
    public static double[,] input = new double[popularCtgCnt, 2];
    // The weight matrix for non-popular categories 
    public static double[,] input2 = new double[nonpopularmaxCtgCnt, 2]; //the weight value
    // The weight matrix for all categories 
    public static double[,] input3 = new double[12, 2];
    static string color;
    // Flag for first-time display 
    static bool firstDspl = true;
    static Dictionary<int, ScreenTemplate[]> templates = new Dictionary<int, ScreenTemplate[]>();
    ScreenTemplate currentTemplate;
    static int tplIndex = 0;
    // Store imformation from the front end 
    static string username;
    static string useravatar;
    string familyElement = "";
    static string importantname;
    static string kids;
    // Lock screen pictures 
    static string[] lockscreen = {
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper2",
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper3",
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper4",
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper5",                                        
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper6",
                                  "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper7",                               
                                  };

    private void Page_Load(object sender, EventArgs e)
    {
        // Iterator 
        int i;
        Random random = new Random(DateTime.Now.Millisecond);
        // First generate the startscreen 
        if (firstDspl)
        {
            // Add the templates into Dictionary 
            template1 t0 = new template1();
            ScreenTemplate[] template0 = t0.GenerateTemplate();
            templates.Add(0, template0);
            template2 t1 = new template2();
            ScreenTemplate[] template1 = t1.GenerateTemplate();
            templates.Add(1, template1);
            template3 t2 = new template3();
            ScreenTemplate[] template2 = t2.GenerateTemplate();
            templates.Add(2, template2);
            template4 t3 = new template4();
            ScreenTemplate[] template3 = t3.GenerateTemplate();
            templates.Add(3, template3);
            template5 t4 = new template5();
            ScreenTemplate[] template4 = t4.GenerateTemplate();
            templates.Add(4, template4);
            template6 t5 = new template6();
            ScreenTemplate[] template5 = t5.GenerateTemplate();
            templates.Add(5, template5);
            template7 t6 = new template7();
            ScreenTemplate[] template6 = t6.GenerateTemplate();
            templates.Add(6, template6);
            template8 t7 = new template8();
            ScreenTemplate[] template7 = t7.GenerateTemplate();
            templates.Add(7, template7);
            template9 t8 = new template9();
            ScreenTemplate[] template8 = t8.GenerateTemplate();
            templates.Add(8, template8);
            template10 t9 = new template10();
            ScreenTemplate[] template9 = t9.GenerateTemplate();
            templates.Add(9, template9);

            int template = random.Next(0, 9);
            currentTemplate = templates[template][1];
            curTemplateId.InnerHtml = template.ToString();
        }
        // Generate the startscreen by tweaking the template 
        else {
            // Get the new template 
            tplIndex = Convert.ToInt32(Request.QueryString["template"]);
            if ((tplIndex < 0) || (tplIndex > 9))
                throw new Exception("Invalid template!");
            else
            {
                currentTemplate = templates[tplIndex][1];
                curTemplateId.InnerHtml = tplIndex.ToString();
            }
            // Get the new color if defined 
            string newcolor = Request.QueryString["color"];
            if(newcolor != "undefined")
                color = newcolor;
        }
        // Get the variables submitted  
        if (Request.QueryString["username"] != null)
            username = Request.QueryString["username"];
        if (Request.QueryString["importantname"] != null)
        {
            importantname = Request.QueryString["importantname"];
            if (importantname == "please enter his/her name")
                importantname = "Someone";
        }
        if (Request.QueryString["1"] != null)
        {
            kids = Request.QueryString["1"];
            familyElement = kids;
        }
        if (Request.QueryString["useravatar"] != null)
            useravatar = Request.QueryString["useravatar"];
        string vals;
        int index = 0;
        Random rnd = new Random();
        // Get the picture choices and deal with the questions that has multiple answers
        if (Request.QueryString[(1).ToString()] != null)
        {
            for (i = 0; i < pictureTotal; i++)
            {
                jrnInput[i] = 0;
            }
            for (i = 0; i < questionNum; i++)//get all the pictures 0: selected; 1: not selected
            {
                // Get the name of the pic from the journey 
                vals = Request.QueryString[(i+1).ToString()];
                // Set the input array according to the input 
                int index2 = 0;
                // Theses question has 4 choices 
                if (i == FOURAWNSERQS1 || i == FOURAWNSERQS2 || i == FOURAWNSERQS3)
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    else if (vals.StartsWith("C"))
                    {
                        index2 = index + 2;
                    }
                    else if (vals.StartsWith("D"))
                    {
                        index2 = index + 3;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
                // Theses question has 3 choices 
                else if (i == THREEAWNSERQS1)
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    else if (vals.StartsWith("C"))
                    {
                        index2 = index + 2;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
                // Theses question has 7 choices 
                else if (i == SEVENAWNSERQS1 || i == SEVENAWNSERQS2)
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    else if (vals.StartsWith("C"))
                    {
                        index2 = index + 2;
                    }
                    else if (vals.StartsWith("D"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("E"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("F"))
                    {
                        index2 = index + 3;
                    }

                    else if (vals.StartsWith("G"))
                    {
                        index2 = index + 3;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
                // Theses question has 5 choices 
                else if (i == FIVEAWNSERQS1)
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    else if (vals.StartsWith("C"))
                    {
                        index2 = index + 2;
                    }
                    else if (vals.StartsWith("D"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("E"))
                    {
                        index2 = index + 3;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
                // Theses question has 8 choices 
                else if (i == EIGHTAWNSERQS1)
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    else if (vals.StartsWith("C"))
                    {
                        index2 = index + 2;
                    }
                    else if (vals.StartsWith("D"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("E"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("F"))
                    {
                        index2 = index + 3;
                    }

                    else if (vals.StartsWith("G"))
                    {
                        index2 = index + 3;
                    }
                    else if (vals.StartsWith("H"))
                    {
                        index2 = index + 3;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
                else
                {
                    if (vals.StartsWith("A"))
                    {
                        index2 = index;
                    }
                    else if (vals.StartsWith("B"))
                    {
                        index2 = index + 1;
                    }
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index] = 0;
                    index++;
                    jrnInput[index2] = 1;
                }
            }
            // Get the background color value
            if (Request.QueryString["color"] != null)
            {
                color = Request.QueryString["color"];
                color = "#" + color;
            }
            // If female 
            if (useravatar == "H" || useravatar == "G" || useravatar == "F" || useravatar == "E")
            {
                input[3, 1] = +0.12;

                input2[1, 1] = +(-0.05);
                input2[3, 1] = +0.07;
                input2[5, 1] = +0.05;
            }
            // If male 
            else
            {
                input2[1, 1] = +0.11;
            }
            
            // 1st young 
            if (useravatar == "E" || useravatar == "D")
            {
                input2[0, 1] = +0.2;
                input2[1, 1] = +(-0.03);
                input2[2, 1] = +(-0.03);
                input2[2, 1] = +(-0.05);
            }
            // 2nd young 
            if (useravatar == "C" || useravatar == "F")
            {
                input2[5, 1] = +0.3;
            }
            // 3rd young 
            else if (useravatar == "B" || useravatar == "G")
            {
                input[0, 1] = +(-0.04);
                input[2, 1] = +0.09;
                input[3, 1] = +0.06;
                input[4, 1] = +0.04;

                input2[2, 1] = +0.08;
                input2[3, 1] = +0.16;
                input2[4, 1] = +0.06;
                input2[5, 1] = +0.01;
                input2[6, 1] = +0.01;
            }
            // 4th young 
            else if (useravatar == "A" || useravatar == "H")
            {
                input[0, 1] = 0.06;
                input[1, 1] = +(-0.04);
                input[2, 1] = +0.06;
                input[3, 1] = +0.04;
                input[4, 1] = +0.06;

                input2[0, 1] = +0.2;
                input2[1, 1] = +(-0.03);
                input2[2, 1] = +(-0.03);
                input2[2, 1] = +(-0.05);

            }

        }

        // Compute the weight matrix 
        WeightComputer wc = new WeightComputer(jrnInput, input, input2, ctgrNum);
        for (int j = 0; j < 5; j++)
        {
            input3[j, 1] = input[j, 1];
        }
        for (int j = 0; j < 7; j++)
        {
            input3[j + 5, 1] = input2[j, 1];
        }
        input3 = Calculate_Input(input3);      
        Response.Write("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js\"></script> <script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js\"></script> <link rel=\"stylesheet\" type=\"text/css\" href=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css\"/>");
        Response.Write("<script type=\"text/javascript\" src=\"js/kidcorner.js\"></script>");
        // Put pictures in template 
        GenerateTileInfo gen = new GenerateTileInfo();
        Dictionary<int, String[]> info = gen.generate(currentTemplate, 0, color, input3, useravatar, familyElement);
        GenerateTiles gg = new GenerateTiles();
        Tile[] tiles = gg.generateTile(info, username, importantname);
        starscreentiles.InnerHtml += "<img id = \"frame\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/frame.png\" style=\"position:absolute; left:595px; top:190px; width:250px; height:500px\">";
        if (Request.QueryString["1"] != null)
        {
            int lockscreennum = random.Next(0, 6);
            // If the second is child 
            if ((kids == "A" || kids == "B") && (useravatar != "D") && (useravatar != "E"))
            {
                Response.Write("<div style=\"position:absolute; left:720px; top:437px; clip:rect(-190px,211px,230px,0px);  z-index:3\"><div id= \"arrow\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"pic\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/tokidcorner.png\" style=\"width:110px; height:40px\"></div></div>");
                Response.Write("<div style=\"position:absolute; left:615px; top:272px; clip:rect(0px,211px,380px,0px); z-index:1\"><div id= \"kidcorner\" style=\"position:absolute; left:0px; top:0px\"><img id = \"corner\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/kidcorner.png\" style=\"width:211px; height:380px\"></div></div>");                
            }
            starscreentiles.InnerHtml += ("<div style=\"position:absolute; left:615px; top:615px; clip:rect(-190px,211px,230px,0px); z-index:3\"><div id= \"unlock\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"unlock-pic\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/unlock.png\" style=\"width:215px; height:40px\"></div></div>");
            starscreentiles.InnerHtml += ("<div style=\"position:absolute; left:615px; top:272px; clip:rect(0px,211px,380px,0px); z-index:2\"><div id= \"pichi\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"piclock\" src=\"" + lockscreen[lockscreennum] + "\" style=\"width:211px; height:380px\"></div></div>");
        }
        // Write the start screen code into front end 
        for (int k = 0; k < tiles.Length; k++)
        {
            starscreentiles.InnerHtml += tiles[k].GetHtml();
        }
        // Write the tite into front end 
        if (username == "please enter your name")
            phonetitle.InnerHtml += "Your Windows Phone 8";
        else
            phonetitle.InnerHtml += username + "'s Windows Phone 8";
        if (firstDspl)
            firstDspl = false;   
    }

    // Normalize the matrix 
    private static double[,] Calculate_Input(double[,] input)
    {
        double totalweight = 0;

        for (int i = 0; i < input.GetLength(0); i++)
            totalweight += input[i, 1];
        for (int i = 0; i < input.GetLength(0); i++)
        {
            input[i, 1] = input[i, 1] * 100 / totalweight;
            Console.WriteLine(i + " " + input[i, 1]);
        }
        return input;
    }
}



