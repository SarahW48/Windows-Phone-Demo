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
    /* how many pictures to choose from */
    //public static int choiceNum = 15; 
    const int maxCtgCnt = 13;
    // the total choices number
    static int questionNum = 17;
    static int[] jrnInput = new int[questionNum * 2];

    int ctgrNum = GenerateTileInfo.ctgrNum;
    public static double[,] input = new double[maxCtgCnt, 2]; //the weight value
    //public static string[] choices = new string[choiceNum];//used to record the choices
    public static string connectionString = "Server=tcp:k7ymy247qu.database.windows.net,1433;Database=Record;User ID=jingying@k7ymy247qu;Password=Hjy6666#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
    public static Elements[] shuffle;
    static string color;
    //static int colorindex = 2;
    //static int templateIndex = 0;
    static bool firstDspl = true;
    static bool isTweak = false;
    static bool firstTpl = false;
    static Dictionary<int, ScreenTemplate[]> templates = new Dictionary<int, ScreenTemplate[]>();
    ScreenTemplate currentTemplate;
    static int tplIndex = 0;
    static string username;
    string gameElement = "";
    string familyElement = "";
    static string importantname;
    static string user;
    static string importantone;
    static string[] lockscreen = {
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper1", 
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper2",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper3",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper4",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper5",                                        
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper6",
                                            "http://www.etc.cmu.edu/projects/up-plus/images/lockscreen/wallpaper7",
                                                                   
                                  };

    private void Page_Load(object sender, EventArgs e)
    {
        int i;
        Random random = new Random(DateTime.Now.Millisecond);

        /* First generate the startscreen */
        if (firstDspl)
        {
            //创建template的办法 template的坐标需要手动输入
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

            int template = random.Next(0, 10);
            currentTemplate = templates[template][1];

            int mm = 1;
            string vals;
            for (i = 0; i < questionNum; i++)
            {

                // get the name of the pic from the journey
                vals = Request.QueryString[(mm).ToString()];
                // set the input array according to the input
                if (i == 6)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        jrnInput[i * 2 + j] = 0;
                    }
                    if (vals.StartsWith("A"))
                        jrnInput[i * 2] = 1;
                    else if (vals.StartsWith("B"))
                        jrnInput[i * 2 + 1] = 1;
                    else if (vals.StartsWith("C"))
                        jrnInput[i * 2 + 2] = 1;
                    else if (vals.StartsWith("D"))
                        jrnInput[i * 2 + 3] = 1;
                    else if (vals.StartsWith("E"))
                        jrnInput[i * 2 + 4] = 1;
                    else if (vals.StartsWith("F"))
                        jrnInput[i * 2 + 5] = 1;
                    i += 2;
                    mm++;
                    continue;
                }
                else if (vals.StartsWith("A"))
                {
                    jrnInput[i * 2] = 1;
                }
                else
                {
                    jrnInput[i * 2] = 0;
                }
                mm++;
                jrnInput[i * 2 + 1] = 1 - jrnInput[i * 2];
            }
            username = Request.QueryString["username"];
            importantname = Request.QueryString["importantname"];
            user = Request.QueryString["user"];
            importantone = Request.QueryString["importantone"];
            color = Request.QueryString["color"];
            color = "#" + color;
            gameElement = Request.QueryString["1"];
            familyElement = Request.QueryString["2"];
        }
        /* Generate the startscreen by tweaking */
        else {
            tplIndex = Convert.ToInt32(Request.QueryString["template"]);
            if ((tplIndex < 0) || (tplIndex > 9))
                throw new Exception("Invalid template!");
            else
                currentTemplate = templates[tplIndex][1];

            string newcolor = Request.QueryString["color"];
            if(newcolor != "undefined")
                color = newcolor;
        }
        //else if (!isTweak)
         //   return;
        
        //GetChoices();     

            WeightComputer wc = new WeightComputer(jrnInput, input, ctgrNum);
            input = Calculate_Input(input);

            Response.Write("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js\"></script> <script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js\"></script> <link rel=\"stylesheet\" type=\"text/css\" href=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css\"/>");
            //Response.Write("<script language=\"javascript\" type=\"text/javascript\"> $(document).ready(function(){ $(\"#pic2\").click(function(){ $(\"#pichi\").animate({\"top\": \"-=380px\"}, \"slow\"); }); }); </script>");
            Response.Write("<script type=\"text/javascript\" src=\"js/kidcorner.js\"></script>");
           
            //往模板里面放图
            GenerateTileInfo gen = new GenerateTileInfo();
            Dictionary<int, String[]> info = gen.generate(currentTemplate, 0, color, input, gameElement, familyElement);
            GenerateTiles gg = new GenerateTiles();
            Tile[] tiles = gg.generateTile(info, username, importantname);

            starscreentiles.InnerHtml +="<img id = \"frame\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/frame.png\" style=\"position:absolute; left:595px; top:190px; width:250px; height:500px\">";
            int lockscreennum = random.Next(0, 7);

            if (Request.QueryString["2"] == "E" || Request.QueryString["2"] == "I")//if the second is child
            {
                Response.Write("<div style=\"position:absolute; left:770px; top:437px; clip:rect(0px,60px,20px,0px); z-index:3\"><div id= \"arrow\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"pic\" src=\"http://www.etc.cmu.edu/projects/up-plus/images/toright.png\" style=\"width:60px; height:20px\"></div></div>");
                Response.Write("<div style=\"position:absolute; left:615px; top:272px; clip:rect(0px,211px,380px,0px); z-index:2\"><div id= \"kidcorner\" style=\"position:absolute; left:0px; top:0px\"></div></div>");
            } 

            starscreentiles.InnerHtml +=("<div style=\"position:absolute; left:615px; top:272px; clip:rect(0px,211px,380px,0px); z-index:1\"><div id= \"pichi\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"pic2\" src=\"" + lockscreen[lockscreennum] + "\" style=\"width:211px; height:380px\"></div></div>");
            
            for (int k = 0; k < tiles.Length; k++)
            {
                starscreentiles.InnerHtml += tiles[k].GetHtml();

            }
            phonetitle.InnerHtml += username + "'s <br/>Windows Phone 8";
            //Response.Write("<div style=\"margin-left: 5px\">");
            /* display the color from the front end in the first time */
            if (firstDspl)
                firstDspl = false;
    }

    private static double[,] Calculate_Input(double[,] input)
    {
        double totalweight = 0;

        for (int i = 0; i < input.GetLength(0); i++)
            totalweight += input[i, 1];
        for (int i = 0; i < input.GetLength(0); i++)
        {
            input[i, 1] = input[i, 1] * 100 / totalweight;
            Console.WriteLine(i + " " + input[i, 1]);//应该一个是60 一个是40
        }
        return input;
    }

    private static double[,] Calculate_RandomInput(double[,] input)
    {
        //double totalweight = 0;
        Random random = new Random(DateTime.Now.Millisecond);

        List<int> order = new List<int>(16); // re-arrange the 16 index
        int t = 0;
        while (t < 13)
        {
            random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            input[t, 1] = random.Next(0,7); 
            t++;
        }

        return input;
    }
    /*
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random random = new Random(DateTime.Now.Millisecond);
        int tmpColor = random.Next(0, 8);
        while (colorindex == tmpColor)
            tmpColor = random.Next(0, 8);
        colorindex = tmpColor;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Random random = new Random(DateTime.Now.Millisecond);
        int tmpTemplate = random.Next(0, templates.Count());
        while (tmpTemplate == templateIndex)
            tmpTemplate = random.Next(0, templates.Count());
        templateIndex = tmpTemplate;
    }
    */

    private void StoreData(string[] choice, bool bl)
    {
        string insertSQL = "INSERT INTO Test(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, result)  VALUES (@p1, @p2,@p3, @p4, @p5, @p6,@p7, @p8, @p9, @p10,@p11, @p12,@p13, @p14,@p15, @result )";
        //user name jingying; pass: Hjy6666#
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(insertSQL, con);
        cmd.Parameters.AddWithValue("@p1", choice[0]);
        cmd.Parameters.AddWithValue("@p2", choice[1]);
        cmd.Parameters.AddWithValue("@p3", choice[2]);
        cmd.Parameters.AddWithValue("@p4", choice[3]);
        cmd.Parameters.AddWithValue("@p5", choice[4]);
        cmd.Parameters.AddWithValue("@p6", choice[5]);
        cmd.Parameters.AddWithValue("@p7", choice[6]);
        cmd.Parameters.AddWithValue("@p8", choice[7]);
        cmd.Parameters.AddWithValue("@p9", choice[8]);
        cmd.Parameters.AddWithValue("@p10", choice[9]);
        cmd.Parameters.AddWithValue("@p11", choice[10]);
        cmd.Parameters.AddWithValue("@p12", choice[11]);
        cmd.Parameters.AddWithValue("@p13", choice[12]);
        cmd.Parameters.AddWithValue("@p14", choice[13]);
        cmd.Parameters.AddWithValue("@p15", choice[14]);
        cmd.Parameters.AddWithValue("@result", bl.ToString());
        int added = 0;
        con.Open();
        added = cmd.ExecuteNonQuery();
        con.Close();  
    }
    /*
    public void GetChoices()
    {
        int ii = 0;
        for (int j = 1; j < choiceNum+1; j++)
        {
            choices[ii] = Request.QueryString[(j).ToString()];
            ii++;
        }
    }*/
    /*
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        StoreData(choices, shuffle[0].isTrue);
        Response.Redirect("Thankyou.htm");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        //Response.Write(shuffle[1].isTrue);
        StoreData(choices, shuffle[1].isTrue);
        Response.Redirect("Thankyou.htm");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        //Response.Write(shuffle[2].isTrue);
        StoreData(choices, shuffle[2].isTrue);
        Response.Redirect("Thankyou.htm");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Button clickedButton = (Button)sender;
        //Response.Write(shuffle[3].isTrue);
        StoreData(choices, shuffle[3].isTrue);
        Response.Redirect("Thankyou.htm");
    }*/

    protected void Button1_Click1(object sender, EventArgs e)
    {
       /* Random random = new Random(DateTime.Now.Millisecond);
        int tmpTemplate = random.Next(0, templates.Count());
        while (tmpTemplate == templateIndex)
            tmpTemplate = random.Next(0, templates.Count());
        templateIndex = tmpTemplate;*/
        if (!firstTpl)
            firstTpl = true;
        isTweak = true;
        tplIndex = (++tplIndex) % templates.Count();
        //Response.Clear();
        Page_Load(sender, e);
        isTweak = false;
    }

    protected void Button2_Click1(object sender, EventArgs e)
    {
        isTweak = true;
        Page_Load(sender, e);
        isTweak = false;
    }

   /* protected void Button3_Click(object sender, EventArgs e)
    {
        Random random = new Random(DateTime.Now.Millisecond);
        int tmpColor = random.Next(0, 8);
        while (colorindex == tmpColor)
            tmpColor = random.Next(0, 8);
        colorindex = tmpColor;
    }   */

}



