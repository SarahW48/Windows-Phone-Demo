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
    public static int choiceNum = 15; //how many pictures to choose from
    const int maxCtgCnt = 13;
    int ctgrNum = GenerateTileInfo.ctgrNum;
    public static double[,] input = new double[maxCtgCnt, 2]; //the weight value
    public static string[] choices = new string[choiceNum];//used to record the choices
    public static string connectionString = "Server=tcp:k7ymy247qu.database.windows.net,1433;Database=TestFriNight;User ID=jingying@k7ymy247qu;Password=Hjy6666#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
    public static Elements[] shuffle;
    string color;
    static bool firstDspl = true;
    static string username;
    String path1 = "";
    String path2 = ""; 
    Dictionary<int, ScreenTemplate[]> templates;
    String gameElement = "";
    static int salt = 0;
    static Elements[] ele = new Elements[3];
    public static int[] shu = new int[3];
    public static int[] inputFakeIndex = new int[maxCtgCnt-2];
    public static int time = 0;
    public int[] indexChoose= new int[3];
    public static int first = 0;
    private void Page_Load(object sender, EventArgs e)
    {
        if (first == 0)
        {
            GetChoices();
            gameElement = Request.QueryString["1"];

            int i;
            Random random = new Random(DateTime.Now.Millisecond);

            // the total choices number
            int questionNum = 17;

            // the total result(personality) number
            //int resultNum = 16;

            // the name of each choice
            //string[] vals = new string[choiceNum];

            int[] jrnInput = new int[questionNum * 2];
            //创建template的办法 template的坐标需要手动输入
            templates = new Dictionary<int, ScreenTemplate[]>();
            /*
            template1 t0 = new template1();
            ScreenTemplate[] template0 = t0.GenerateTemplate();
            templates.Add(0, template0);
            template2 t1 = new template2();
            ScreenTemplate[] template1 = t1.GenerateTemplate();
            templates.Add(1, template1);
            */
            template9 t2 = new template9();
            ScreenTemplate[] template2 = t2.GenerateTemplate();
            templates.Add(0, template2);
            /*
            template4 t3 = new template4();
            ScreenTemplate[] template3 = t3.GenerateTemplate();
            templates.Add(3, template3);
            template5 t4= new template5();
            ScreenTemplate[] template4 = t4.GenerateTemplate();
            templates.Add(4, template4);
            template6 t5 = new template6();
            ScreenTemplate[] template5 = t5.GenerateTemplate();
            templates.Add(5, template5);
            */
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
            string importantname = Request.QueryString["importantname"];
            color = Request.QueryString["color"];
            color = "#" + color;

            WeightComputer wc = new WeightComputer(jrnInput, input, ctgrNum);
            input = Calculate_Input(input);
            inputFakeIndex = FindNotCate(input);
            //shuffle the templates position 
            shu[0] = 0;
            shu[1] = 1;
            shu[2] = 2;
            shu = RandomStringArrayTool.RandomizeStrings(shu);

            //start putting icons, the real one
            ScreenTemplate currentTemplate = templates[0][1];
            //ScreenTemplate currentTemplate = templates[0][shu[0]];
            GenerateTileInfo gen = new GenerateTileInfo();
            Dictionary<int, String[]> info = gen.generate(currentTemplate, 0, color, input, gameElement);
            GenerateTiles gg = new GenerateTiles();
            Tile[] tiles = gg.generateTile(info, username, importantname);
            path1 = "";
            for (int j = 0; j < tiles.Length; j++)
            {
                path1 = path1 + getCate(tiles[j].path) + "/";
            }
            //Response.Write("        this is the right one  " + shu[0].ToString());


            /////////22222222222222
            //input = Calculate_RandomInput(input);
            Calculate_FakeInput(inputFakeIndex);
            time++;
            salt++;
            ScreenTemplate currentTemplate1 = templates[0][0];
            GenerateTileInfo gen1 = new GenerateTileInfo();
            Dictionary<int, String[]> info1 = gen.generate(currentTemplate1, 0, color, input, gameElement);
            GenerateTiles gg1 = new GenerateTiles();
            Tile[] tiles1 = gg.generateTile(info1, username, importantname);

            salt++;
            //33333333333333fake
            //input = Calculate_RandomInput(input);
            Calculate_FakeInput(inputFakeIndex);
            ScreenTemplate currentTemplate2 = templates[0][2];
            //ScreenTemplate currentTemplate2 = templates[0][shu[2]];
            GenerateTileInfo gen2 = new GenerateTileInfo();
            Dictionary<int, String[]> info2 = gen.generate(currentTemplate2, 0, color, input, gameElement);
            GenerateTiles gg2 = new GenerateTiles();
            Tile[] tiles2 = gg2.generateTile(info2, username, importantname);

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
            ele[1] = el0;
            ele[0] = el1;
            ele[2] = el2;
        }
        first++;
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
            Console.WriteLine(i + " " + input[i, 1]);
        }
        return input;
    }



    private void StoreData(string[] choice, bool bl, String c1, String c2)
    {
        DateTime thisDay = DateTime.Today;
        string insertSQL = "INSERT INTO Test(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, result, name, OurGuess, choose,date)  VALUES (@p1, @p2,@p3, @p4, @p5, @p6,@p7, @p8, @p9, @p10,@p11, @p12,@p13, @p14,@p15, @result, @name, @guess, @choose, @date )";
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
        cmd.Parameters.AddWithValue("@name", username);
        cmd.Parameters.AddWithValue("@guess", path1);
        cmd.Parameters.AddWithValue("@choose", path2);
        cmd.Parameters.AddWithValue("@date", thisDay);
        int added = 0;
        con.Open();
        added = cmd.ExecuteNonQuery();
        con.Close();  
    }

    public void GetChoices()
    {
        int ii = 0;
        for (int j = 1; j < choiceNum+1; j++)
        {
            choices[ii] = Request.QueryString[(j).ToString()];
            ii++;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        path2 = "";

        for (int j = 0; j < ele[0].tiles.Length; j++)
        {
            path2 = path2 + getCate(ele[0].tiles[j].path) + "/";
        }

        StoreData(choices, ele[0].isTrue, path1, path2);
        Session["istrue"] = ele[0].isTrue.ToString(); 

        Response.Redirect("Thankyou.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        path2 = "";

        for (int j = 0; j < ele[1].tiles.Length; j++)
        {
            path2 = path2 + getCate(ele[1].tiles[j].path) + "/";
        }

        StoreData(choices, ele[1].isTrue, path1, path2);
        Session["istrue"] = ele[1].isTrue.ToString();

        Response.Redirect("Thankyou.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        path2 = "";

        for (int j = 0; j < ele[2].tiles.Length; j++)
        {
            path2 = path2 + getCate(ele[2].tiles[j].path) + "/";
        }

        StoreData(choices, ele[2].isTrue, path1, path2);
        Session["istrue"] = ele[2].isTrue.ToString();
        Response.Redirect("Thankyou.aspx");
         
    }

    /*
    protected void Button4_Click(object sender, EventArgs e)
    {
        //Button clickedButton = (Button)sender;
        //Response.Write(shuffle[3].isTrue);
        path2 = "";
        for (int j = 0; j < shuffle[3].tiles.Length; j++)
        {
            path2 = path2 +  getCate(shuffle[3].tiles[j].path) +"/";
        }
        StoreData(choices, shuffle[3].isTrue, path1, path2);
        Response.Redirect("Thankyou.htm");
    }
    */

    public String getCate(String s)
    {
        //http://www.etc.cmu.edu/projects/up-plus/images/tiles/---52
        
        int l= s.Length;
        int start = 52;
        String ss = s.Substring(52);
        return ss;
    }

    private static int[] getFirst2MaxIndex(double[,] arr)
    {
        int indexMax = 0;
        int indexSec = 0;
        
        int[] re = new int[2];
        if (arr.Length < 2)
            throw new Exception("invalid array!");
        indexMax = (arr[0, 1] > arr[1, 1]) ? 0 : 1;
        indexSec = (arr[0, 1] > arr[1, 1]) ? 1: 0;

        for (int i = 0; i < arr.Length/2; i++)
        {
            if (arr[i,1] > arr[indexSec,1])
            {
                indexSec = i;//change the second
                if (arr[indexSec,1] > arr[indexMax,1])
                {
                    int tmp = indexMax;
                    indexMax = indexSec;
                    indexSec = tmp;
                }
            }
        }
        re[0] = indexMax;
        re[1] = indexSec;
        //HttpContext.Current.Response.Write("<font color=\"black\">"+ indexMax +" ");
        //HttpContext.Current.Response.Write("<font color=\"black\">" + indexSec + " " +"<br>");
        return re;
    }

    private static double[,] Calculate_RandomInput(double[,] input)
    {
        int t = 0;
        Random random = new Random(DateTime.Now.Millisecond);
        input[0, 0] = 0;
        input[0, 1] = 0.0;
        t++;
        while (t < 13)
        {         
            //random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            input[t, 0] = t;
            input[t, 1] = ((double)random.Next(0, 10000) + 10*salt + salt)%100;
            //HttpContext.Current.Response.Write("<font color=\"black\">"+input[t, 1]);
            t++;
        }

        int[] index = getFirst2MaxIndex(input);
        //HttpContext.Current.Response.Write("after 000 :   ");
        for (int j = 0; j < input.Length / 2; j++)
        {
            if (j != index[0] && j != index[1])
            {
                input[j, 1] = 0.0;
            }
            //HttpContext.Current.Response.Write("<font color=\"black\">" + input[j, 1] );
           
        }
        return input;
    }

    public static int[] FindNotCate(double[,] input)
    {
        int[] record = new int[input.Length/2-2];
        int r=0;
        for (int j = 0; j < input.Length / 2; j++)
        {
            if (input[j, 1] == 0.0)
            {
                record[r] = j;
                r++;
            }
        }
        return record;
    }

    //the input is the index that weight is 0
    public static void Calculate_FakeInput(int[] inputFake)
    {
        if (time == 0)
        {
            for (int j = 0; j < inputFake.Length + 2; j++)
            {
                if (j == inputFake[2] || j == inputFake[inputFake.Length - 2])
                {
                    input[j, 1] = 50.0;
                }
                else
                    input[j, 1] = 0.0;
            }
        }
        else
        {
            for (int j = 0; j < inputFake.Length + 2; j++)
            {
                if (j == inputFake[3] || j == inputFake[inputFake.Length - 3])
                {
                    input[j, 1] = 50.0;
                }
                else
                    input[j, 1] = 0.0;
            }       
        }
        
    }
}



