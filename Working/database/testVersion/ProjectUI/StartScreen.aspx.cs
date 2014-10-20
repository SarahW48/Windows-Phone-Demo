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
    public static int choiceNum = 29; // how many chices
    public static double[,] input = new double[16, 2]; //the weight value
    public static string[] choices = new string[choiceNum];//used to record the choices
    public static string connectionString = "Server=tcp:k7ymy247qu.database.windows.net,1433;Database=Record;User ID=jingying@k7ymy247qu;Password=Hjy6666#;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
    public static Elements[] shuffle;
    public static void Set_Input(double[] arr, int len)
    {
        for (int i = 0; i < len; i++) 
        {
            input[i, 1] = arr[i];
        }
    }

    private void Page_Load(object sender, EventArgs e)
    {
            int i;
            Random random = new Random(DateTime.Now.Millisecond);

            // the name of each choice
            string[] vals = new string[choiceNum];

            /* input array from the journey
             * get from the js 
             * used to compute the weight of the personality 
             */
            int[] jrnInput = new int[choiceNum * 2];

            int colorindex = random.Next(0, 8);
            Console.WriteLine(">>>>"+colorindex);
            //创建template的办法 template的坐标需要手动输入
            Dictionary<int,ScreenTemplate[]> templates=new Dictionary<int,ScreenTemplate[]>();
            //ScreenTemplate[] st= new ScreenTemplate[3];
            //Dictionary<int, ScreenTemplate[]> templates = new Dictionary<int, ScreenTemplate[]>();
            string Small = "";
            string Medium = "";
            string Large = "";

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
            template5 t4= new template5();
            ScreenTemplate[] template4 = t4.GenerateTemplate();
            //templates.Add(4, template4);
            template6 t5 = new template6();
            ScreenTemplate[] template5 = t5.GenerateTemplate();
            //templates.Add(5, template5);

            /***  get the input data from the front-end  ***/
            for (i = 0; i < choiceNum; i++)
            {
                /**********  real data from input  ********/
                // get the name of the pic from the journey
                vals[i] = Request.QueryString[(i).ToString()];
                /******************************************/
                choices[i] = Request.QueryString[(i).ToString()];
                // set the input array according to the input
                if (vals[i].StartsWith("A"))
                {
                    jrnInput[i * 2] = 1;
                }
                else
                {
                    jrnInput[i * 2] = 0;
                }

                jrnInput[i * 2 + 1] = 1 - jrnInput[i * 2];
            }
            string username = Request.QueryString["username"];
            string importantname = Request.QueryString["importantname"];

           //随机出来一个模板（现在设置为随机）
            int templateIndex = 2;//随机一个0到2之间的数，不包括2


            /* Compute the real weight using the weight computer */
            WeightComputer wc = new WeightComputer(jrnInput, input);
            input = Calculate_Input(input);
           
            //往模板里面放图
            ScreenTemplate currentTemplate = templates[templateIndex][0];
            GenerateTileInfo gen = new GenerateTileInfo();
            Dictionary<int,String[]> info =gen.generate(currentTemplate,  templateIndex, colorindex, input);
            GenerateTiles gg = new GenerateTiles();
            Tile[] tiles = gg.generateTile(info, username, importantname);
            Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            //for (int k = 0; k < tiles.Length; k++)
                //Response.Write(tiles[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate1 = templates[templateIndex][1];
            GenerateTileInfo gen1 = new GenerateTileInfo();
            Dictionary<int, String[]> info1 = gen.generate(currentTemplate1, templateIndex, colorindex, input);
            GenerateTiles gg1 = new GenerateTiles();
            Tile[] tiles1 = gg.generateTile(info1, username, importantname);
            //for (int k = 0; k < tiles1.Length; k++)
                //Response.Write(tiles1[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate2 = templates[templateIndex][2];
            GenerateTileInfo gen2 = new GenerateTileInfo();
            Dictionary<int, String[]> info2 = gen.generate(currentTemplate2, templateIndex, colorindex, input);
            GenerateTiles gg2 = new GenerateTiles();
            Tile[] tiles2 = gg2.generateTile(info2, username, importantname);
            //for (int k = 0; k < tiles2.Length; k++)
               // Response.Write(tiles2[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate3 = templates[templateIndex][3];
            GenerateTileInfo gen3 = new GenerateTileInfo();
            Dictionary<int, String[]> info3 = gen.generate(currentTemplate3, templateIndex, colorindex, input);
            GenerateTiles gg3 = new GenerateTiles();
            Tile[] tiles3 = gg3.generateTile(info3, username, importantname);
           // for (int k = 0; k < tiles3.Length; k++)
                //Response.Write(tiles3[k].GetHtml());

            Elements el0, el1, el2,el3;
            el0 = new Elements();
            el1 = new Elements();
            el2 = new Elements();
            el3 = new Elements();
            el0.tiles = tiles;
            el0.isTrue = true;
            el1.tiles = tiles1;
            el1.isTrue = false;
            el2.tiles = tiles2;
            el2.isTrue = false;
            el3.tiles = tiles3;
            el3.isTrue = false;
            Elements[] ele = new Elements[4];
            ele[0] = el0;
            ele[1] = el1;
            ele[2] = el2;
            ele[3] = el3;
            shuffle = RandomStringArrayTool.RandomizeStrings(ele);
            for (int j = 0; j < 4; j++)
            {
                for (int jj = 0; jj < shuffle[j].tiles.Count(); jj++ )
                    Response.Write(shuffle[j].tiles[jj].GetHtml());
            }
    }

    private static double[,] Calculate_Input(double[,] input)
    {
        double totalweight = 0;

        for (int i = 0; i < input.Length / 2; i++)
            totalweight += input[i, 1];
        for (int i = 0; i < input.Length / 2; i++)
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
        while (t < 16)
        {
            random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            input[t, 1] = random.Next(0,100000); 
            t++;
        }

        return input;
    }


    protected void Button1_Click(object sender, EventArgs e)//choose the 1th button
    {
        Button clickedButton = (Button)sender;
        //Response.Write("<font size=30 color= black>jyhjyhjyjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj");
        Response.Write(shuffle[0].isTrue + "hjyhjyhjyjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj");
        StoreData(choices, shuffle[0].isTrue);

    }

    protected void Button2_Click(object sender, EventArgs e)// choose 2
    {
        Button clickedButton = (Button)sender;
        Response.Write(shuffle[1].isTrue);
        StoreData(choices, shuffle[1].isTrue);
        Response.Redirect("Thankyou.html");


    }

    protected void Button3_Click(object sender, EventArgs e)//choose 3
    {
        Button clickedButton = (Button)sender;
        Response.Write(shuffle[2].isTrue);
        StoreData(choices, shuffle[2].isTrue);
    }

    protected void Button4_Click(object sender, EventArgs e)//choose 4
    {
        Button clickedButton = (Button)sender;
        Response.Write(shuffle[3].isTrue);
        StoreData(choices, shuffle[3].isTrue);
    }


    private void StoreData(string[] choice, bool bl)
    {
        /*
        string insertSQL = "INSERT INTO Test(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20, result) VALUES (@p1, @p2)";
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
        cmd.Parameters.AddWithValue("@p16", choice[17]);
        cmd.Parameters.AddWithValue("@p17", choice[18]);
        cmd.Parameters.AddWithValue("@p18", choice[19]);
        cmd.Parameters.AddWithValue("@p18", bl);
        int added = 0;
        con.Open();
        added = cmd.ExecuteNonQuery();
        con.Close();  
        */
    }

    public void GetChoices()
    {

        for (int j = 0; j < choiceNum; j++)
        {
            choices[j] = Request.QueryString[(j).ToString()];
        }
    }


}



