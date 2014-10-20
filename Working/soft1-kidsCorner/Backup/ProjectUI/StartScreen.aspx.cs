using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ProjectUI.AppCode;//.ScreenTemplate;

public partial class StartScreen : System.Web.UI.Page
{

    public static double[,] input = new double[16, 2]; //the weight value

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

            // the total choices number
            int choiceNum = 10;

            // the total result(personality) number
            int resultNum = 16;

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
            templates.Add(4, template4);
            /*

            Small = "600,100 653,100 600,153 653,153";//2,2 2,2";
            int[,] small = new int[4,2];
            small[0, 0] = 600;
            small[0, 1] = 100;
            Medium = "706,100 600,322 706,322";
            Large = "600,206";//5,7 8,3";
            ScreenTemplate template1 = new ScreenTemplate(Small, Medium, Large);
            templates.Add(1, template1);


            Small = "706,100 760,100 706,154 760,154 600,206 653,206 600,259 653,259";//2,2 2,2";
            Medium = "600,100 706,206";
            Large = "600,312";//5,7 8,3";
            ScreenTemplate template3 = new ScreenTemplate(Small, Medium, Large);
            templates.Add(2, template3);
            */
            //Small = "600,100 653,100 600,153 653,153";//2,2 2,2";
            //Medium = "706,100 600,322 706,322 600,428 706,428";
            //Large = "600,206";//5,7 8,3";
            //ScreenTemplate template4 = new ScreenTemplate(Small, Medium, Large);

            /***  get the input data from the front-end  ***/
            for (i = 0; i < choiceNum; i++)
            {
                /**********  real data from input  ********/
                // get the name of the pic from the journey
                vals[i] = Request.QueryString[(i).ToString()];
                /******************************************/

                /**********  fake data for test  ********/
                //vals[j] = "A1";
                /******************************************/

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

            //这儿是input 值设置为薇薇传过来的数
           


            //double[,] input= new double[16,2];// = { { 0, 30 }, { 1, 20 }};
            //double[][] inp = new double[5][1];
            //WeightComputer wc = new WeightComputer(jrnInput, input);
            
            //计算百分比
       /*     double totalweight = 0;

            List<int> order = new List<int>(16); // re-arrange the 16 index
            int t = 0;
            while (order.Count < 16)
            {
                t = random.Next(0, 16);
                if (!order.Contains(t))
                    order.Add(t);
            }

            input[order[0], 1] = random.Next(60, 100); // the max category
            input[order[1], 1] = random.Next(20, 60);  // the secmax category
            for (int j = 2; j < input.Length / 4; j++)  // 3-8
            {
                input[order[j], 1] = random.Next(5, 20);
            }
            for (int j = input.Length / 4 + 1; j < input.Length / 2; j++)
            {
                input[order[j], 1] = random.Next(0, 5); // 9-16
            } 

            for (i = 0; i < input.Length / 2;i++ )
               totalweight += input[i,1];
            for (i = 0; i < input.Length / 2; i++)
            {
               input[i, 1] = input[i, 1] * 100 / totalweight;//normalized 
            }  */
            //input = Calculate_RandomInput(input);

           //随机出来一个模板（现在设置为随机）
            int templateIndex = random.Next(0, templates.Count());//随机一个0到2之间的数，不包括2
            Console.WriteLine(templateIndex);

            input = Calculate_RandomInput(input);
            //往模板里面放图
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate = templates[templateIndex][0];
            GenerateTileInfo gen = new GenerateTileInfo();
            Dictionary<int,String[]> info =gen.generate(currentTemplate,  templateIndex, colorindex, input);
            GenerateTiles gg = new GenerateTiles();
            Tile[] tiles = gg.generateTile(info);
            for (int j = 0; j < tiles.Length; j++)
                Response.Write(j);
            Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            for (int k = 0; k < tiles.Length; k++)
                Response.Write(tiles[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate1 = templates[templateIndex][1];
            GenerateTileInfo gen1 = new GenerateTileInfo();
            Dictionary<int, String[]> info1 = gen.generate(currentTemplate1, templateIndex, colorindex, input);
            GenerateTiles gg1 = new GenerateTiles();
            Tile[] tiles1 = gg1.generateTile(info1);
            for (int j = 0; j < tiles1.Length; j++)
                Response.Write(j);
            //Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            for (int k = 0; k < tiles1.Length; k++)
                Response.Write(tiles1[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate2 = templates[templateIndex][2];
            GenerateTileInfo gen2 = new GenerateTileInfo();
            Dictionary<int, String[]> info2 = gen.generate(currentTemplate2, templateIndex, colorindex, input);
            GenerateTiles gg2 = new GenerateTiles();
            Tile[] tiles2 = gg2.generateTile(info2);
            for (int j = 0; j < tiles2.Length; j++)
                Response.Write(j);
            // Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            for (int k = 0; k < tiles2.Length; k++)
                Response.Write(tiles2[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            Response.Write(templateIndex);
            ScreenTemplate currentTemplate3 = templates[templateIndex][3];
            GenerateTileInfo gen3 = new GenerateTileInfo();
            Dictionary<int, String[]> info3 = gen.generate(currentTemplate3, templateIndex, colorindex, input);
            GenerateTiles gg3 = new GenerateTiles();
            Tile[] tiles3 = gg3.generateTile(info3);
            for (int j = 0; j < tiles3.Length; j++)
                Response.Write(j);
            //Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            for (int k = 0; k < tiles3.Length; k++)
                Response.Write(tiles3[k].GetHtml());

       // Response.Write("<img src='images/tiles/music+video/1.png' style=' background-color:blue;position:absolute; left:403; top:153; width:47px; length:47px;'/>");

            //Response.Write(tiles[0].GetHtml());
            //Response.Write(tiles[3].GetHtml());
            //.Write(tiles[4].GetHtml()); 
            //int iii = 0;
            //Response.Write("<img src='images/tiles/build-in/call_M.png' style=' background-color:green;position:absolute; left:600; top:100; width:100px; length:100px;'/>");

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


    

}



