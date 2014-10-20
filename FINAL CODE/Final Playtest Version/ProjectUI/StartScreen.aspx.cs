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
    const int popularCtgCnt = 5;//ch
    const int nonpopularmaxCtgCnt = 7;//ch
    static int questionNum = 15;
    static int pictureTotal = 56;
    static int[] jrnInput = new int[pictureTotal];
    int ctgrNum = GenerateTileInfo.ctgrNum;
    public static double[,] input = new double[popularCtgCnt, 2]; //the weight value
    //ch
    public static double[,] input2 = new double[nonpopularmaxCtgCnt, 2]; //the weight value
    public static double[,] input3 = new double[12, 2]; //the weight value   
    public static string connectionString = "Server=tcp:k7ymy247qu.database.windows.net,1433;Database=finalTest;User ID=jingying@k7ymy247qu;Password=Hjy6666#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";  
    public static Elements[] shuffle;
    string color;
    public static String path1 = "";
    public static  String path2 = "";
    public static String path3 = "";
    Dictionary<int, ScreenTemplate[]> templates;
    static int salt = 0;
    static Elements[] ele = new Elements[3];
    public static int[] shu = new int[3];
    public static int time = 0;
    public int[] indexChoose= new int[3];
    public static int first = 0;
    public static string username;
    public static string useravatar;
    public static string importantname;
    string gameElement = "";
    string familyElement = "";
    //static string kids;
    static string[] choices;
    public static double[,] inputFake = new double[popularCtgCnt, 2]; //the weight value
    public static double[,] inputFake2 = new double[nonpopularmaxCtgCnt, 2]; //the weight value
    public static double[,] inputFake3 = new double[12, 2];
    public static double[,] inputFakeTwo = new double[popularCtgCnt, 2]; //the weight value
    public static double[,] inputFakeTwo2 = new double[nonpopularmaxCtgCnt, 2]; //the weight value
    public static double[,] inputFakeTwo3 = new double[12, 2];
    static string timeConsume;
    private void Page_Load(object sender, EventArgs e)
    {
        int i;
        gameElement = Request.QueryString["1"];
        timeConsume = Request.QueryString["time"];
        // the total choices number
        int[] jrnInput = new int[pictureTotal];
        //using one template for test
        templates = new Dictionary<int, ScreenTemplate[]>();
        template9 t2 = new template9();
        ScreenTemplate[] template2 = t2.GenerateTemplate();
        templates.Add(0, template2);
        string vals;
        int index = 0;
        choices = new string[pictureTotal];
        username = Request.QueryString["userName"];
        useravatar = Request.QueryString["useravatar"];
        importantname = Request.QueryString["importantname"];
        if (Request.QueryString[(1).ToString()] != null)
        {
            for (i = 0; i < pictureTotal; i++)
            {
                jrnInput[i] = 0;
            }

            for (i = 0; i < questionNum; i++)//get all the pictures 0: selected; 1: not selected
            {
                // get the name of the pic from the journey
                vals = Request.QueryString[(i + 1).ToString()];
                choices[i] = vals;
                // set the input array according to the input
                int index2 = 0;
                //this is the weight added seperately for the first choice (person representaion)
                if (i == 0 || i == 2 || i == 4)// theses question has 4 choices
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
                else if (i == 14)// theses question has 3 choices
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
                else if (i == 3 || i == 7)// theses question has 7 choices
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

                else if (i == 13)// theses question has 5 choices
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
                else if (i == 11)// theses question has 8 choices
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
                else// theses question has 2 choices
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
            if (Request.QueryString["color"] != null)
            {
                color = Request.QueryString["color"];
                color = "#" + color;
            }
            if (useravatar == "H" || useravatar == "G" || useravatar == "F" || useravatar == "E")
            {
                input[3, 1] = +0.12;

                input2[1, 1] = +(-0.05);
                input2[3, 1] = +0.07;
                input2[5, 1] = +0.05;
            }
            // if male
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
        shu[0] = 0;
        shu[1] = 1;
        shu[2] = 2;
        shu = RandomStringArrayTool.RandomizeStrings(shu);
        //start putting icons, the real one
        ScreenTemplate currentTemplate = templates[0][1];
        GenerateTileInfo gen = new GenerateTileInfo();
        Dictionary<int, String[]> info = gen.generate(currentTemplate, 0, color, input3, useravatar, familyElement);
        GenerateTiles gg = new GenerateTiles();
        Tile[] tiles = gg.generateTile(info, username, importantname);
        path2 = "";
        for (int j = 0; j < tiles.Length; j++)
        {
            path2 = path2 + getCate(tiles[j].path) + "/";
        }
        /////////22222222222222
        ToRandom(1);
        for (int j = 0; j < 5; j++)
        {
            inputFake3[j, 1] = inputFake[j, 1];
        }
        for (int j = 0; j < 7; j++)
        {
            inputFake3[j + 5, 1] = inputFake2[j, 1];
        }
        ScreenTemplate currentTemplate1 = templates[0][0];//the left most one
        GenerateTileInfo gen1 = new GenerateTileInfo();
        Dictionary<int, String[]> info1 = gen.generate(currentTemplate1, 0, color, inputFake3, useravatar, familyElement);
        GenerateTiles gg1 = new GenerateTiles();
        Tile[] tiles1 = gg.generateTile(info1, username, importantname);
        path1 = "";
        for (int j = 0; j < tiles1.Length; j++)
        {
            path1 = path1 + getCate(tiles1[j].path) + "/";
        }

        ToRandom(2);
        for (int j = 0; j < 5; j++)
        {
            inputFake3[j, 1] = inputFake[j, 1];
        }
        for (int j = 0; j < 7; j++)
        {
            inputFake3[j + 5, 1] = inputFake2[j, 1];
        }
        ScreenTemplate currentTemplate2 = templates[0][2];
        GenerateTileInfo gen2 = new GenerateTileInfo();
        Dictionary<int, String[]> info2 = gen.generate(currentTemplate2, 0, color, inputFake3, useravatar, familyElement);
        GenerateTiles gg2 = new GenerateTiles();
        Tile[] tiles2 = gg2.generateTile(info2, username, importantname);
        path3 = "";
        for (int j = 0; j < tiles2.Length; j++)
        {
            path3 = path3 + getCate(tiles2[j].path) + "/";
        }
        shuffle = new Elements[3];

        Elements el0, el1, el2;
        el0 = new Elements();
        el1 = new Elements();
        el2 = new Elements();
        el0.tiles = tiles;
        el0.isTrue = true;
        el1.tiles = tiles1;
        el1.isTrue = false;
        el2.tiles = tiles2;
        el2.isTrue = false;
        ele[0] = el0;
        ele[1] = el1;
        ele[2] = el2;
        for (int j = 0; j < 3; j++)
        {
            for (int jj = 0; jj < ele[j].tiles.Count(); jj++)
            {
                Response.Write(ele[j].tiles[jj].GetHtml());

            }
        }

    }

    private static double[,] Calculate_Input(double[,] input)
    {
        double totalweight = 0;

        for (int i = 0; i < input.GetLength(0); i++)
            totalweight += input[i, 1];
        for (int i = 0; i < input.GetLength(0); i++)
        {
            input[i, 1] = input[i, 1] * 100 / totalweight;
            //Console.WriteLine(i + " " + input[i, 1]);
        }
        return input;
    }

    private void StoreData(string[] choice, bool bl, String c1, String c2, String c3, String chose)
    {
        DateTime thisDay = DateTime.Today;
        string insertSQL = "INSERT INTO test(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, path1, path2, path3, result, choice, date,time, userName )  VALUES (@p1, @p2,@p3, @p4, @p5, @p6,@p7, @p8, @p9, @p10,@p11, @p12,@p13, @p14,@p15, @path1, @path2, @path3, @result, @choice, @date, @time, @userName )";
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
        cmd.Parameters.AddWithValue("@path1", path1);
        cmd.Parameters.AddWithValue("@path2", path2);
        cmd.Parameters.AddWithValue("@path3", path3);
        cmd.Parameters.AddWithValue("@result", bl.ToString());
        cmd.Parameters.AddWithValue("@choice", chose);
        cmd.Parameters.AddWithValue("@date", thisDay);
        cmd.Parameters.AddWithValue("@time", timeConsume);
        cmd.Parameters.AddWithValue("@userName", username);
        int added = 0;
        con.Open();

        added = cmd.ExecuteNonQuery();
        con.Close();  
    }

    public void GetChoices()
    {
        for (int j = 1; j < questionNum+1; j++)
        {
            choices[j] = Request.QueryString[(j).ToString()];
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        StoreData(choices, false, path1, path2, path3, "1");
        Session["istrue"] = false; 

        Response.Redirect("Thankyou.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        StoreData(choices, true, path1, path2, path3, "2");
        Session["istrue"] = true;
        Session["path"] = path1+"  "+path2+"  "+path3;
        Session["timeIn"] = first;
        Response.Redirect("Thankyou.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        StoreData(choices, false, path1, path2, path3, "3");
        Session["istrue"] = false;
        Response.Redirect("Thankyou.aspx");
         
    }


    public String getCate(String s)
    {
        int l= s.Length;
        //int start = 52;
        String ss = s.Substring(52);
        return ss;
    }

    public void ToRandom(int random)
    {
        int index = 0;

        for (int j = 0; j < 5; j++)//random the famouse
        {
            if (input[j, 1] != 0)
            {
                index = (j + random) % 5;
                inputFake[index, 1] = 1;
                inputFake[j, 1] = 0;
                break;
            }
        }
        for (int j = 0; j < 7; j++)//random the not famouse
        {
            if (input2[j, 1] != 0)
            {
                index = (j + random) % 7;
                inputFake2[index, 1] = 1;
                inputFake2[j, 1] = 0;
                break;
            }
        }
    }
}



