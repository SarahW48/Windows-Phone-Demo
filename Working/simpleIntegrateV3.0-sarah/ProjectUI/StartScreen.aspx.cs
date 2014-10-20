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
            int choiceNum = 29;

            // the total result(personality) number
            //int resultNum = 16;

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
            template6 t5 = new template6();
            ScreenTemplate[] template5 = t5.GenerateTemplate();
            templates.Add(5, template5);

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
            string username = Request.QueryString["username"];
            string importantname = Request.QueryString["importantname"];
            string user = Request.QueryString["user"];
            string importantone = Request.QueryString["importantone"];

           //随机出来一个模板（现在设置为随机）
            int templateIndex = 2;//随机一个0到2之间的数，不包括2
            //Console.WriteLine(templateIndex);


            /* Compute the real weight using the weight computer */
            WeightComputer wc = new WeightComputer(jrnInput, input);
            input = Calculate_Input(input);

            Response.Write("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js\"></script> <script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.js\"></script> <link rel=\"stylesheet\" type=\"text/css\" href=\"http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.1/themes/base/jquery-ui.css\"/>");

            Response.Write("<script language=\"javascript\" type=\"text/javascript\"> $(document).ready(function(){ $(\"#frame\").click(function(){ $(\"#pichi\").animate({\"top\": \"-=320px\"}, \"slow\"); }); }); </script>");
            
            //Response.Write("<script language=\"javascript\" type=\"text/javascript\"> $(document).ready(function(){ $(\"#pic2\").click(function(){ $(\"#pichi\").animate({\"top\": \"-=320px\"}, \"slow\"); }); }); </script>");

           
            //往模板里面放图
            //Response.Write(templateIndex);
            ScreenTemplate currentTemplate = templates[templateIndex][0];
            GenerateTileInfo gen = new GenerateTileInfo();
            Dictionary<int,String[]> info =gen.generate(currentTemplate,  templateIndex, colorindex, input);
            GenerateTiles gg = new GenerateTiles();
            Tile[] tiles = gg.generateTile(info, username, importantname);
            for (int j = 0; j < tiles.Length; j++)
                //Response.Write(j);
            Response.Write("<body background=\"journey_images/white-wallpapers.jpg\"  >");
            Response.Write("<div style=\"position:absolute; left:350px; top:100px; clip:rect(0px,211px,317px,0px); z-index:1\"><div id= \"pichi\" style=\"position:absolute; left:0px; top:0px\"> <img id = \"pic2\" src='journey_images/" + user + ".png' style=\"width:211px; height:317px\"></div></div>");
            //Response.Write("<div id= \"pichi\" style=\"position:absolute; left:350px; top:100px;  z-index:1\"> <img id = \"pic2\" src='journey_images/" + user + ".png' style=\"width:211px; height:317px\"/></div>");
            //Response.Write("<img src=\"journey_images/white-wallpapers.jpg\" style=\"position:absolute; left:350px; top:0px; width:800px; height:100px; z-index:1\">");
            //Response.Write("<img id = \"frame\" src=\"journey_images/frame.png\" style=\"position:absolute; left:330px; top:23px; width:250px; height:500px; z-index:1\">");
            for (int k = 0; k < tiles.Length; k++)
                Response.Write(tiles[k].GetHtml());
            Response.Write("<img id = \"frame\" src=\"journey_images/frame.png\" style=\"position:absolute; left:330px; top:23px; width:250px; height:500px\">");
            //Response.Write("<div id= \"pichi\" style=\"position:absolute; left:350px; top:100px\"> <img id = \"pic2\" src='journey_images/" + user + ".png' style=\"width:211px; height:317px\"/></div>");
            //Response.Write("<img src=\"journey_images/white-wallpapers.jpg\" style=\"position:absolute; left:350px; top:0px; width:800px; height:100px\">");
            //Response.Write("<img id = \"frame\" src=\"journey_images/frame.png\" style=\"position:absolute; left:330px; top:23px; width:250px; height:500px\">");

   
           /*
            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            //Response.Write(templateIndex);
            ScreenTemplate currentTemplate1 = templates[templateIndex][1];
            GenerateTileInfo gen1 = new GenerateTileInfo();
            Dictionary<int, String[]> info1 = gen.generate(currentTemplate1, templateIndex, colorindex, input);
            GenerateTiles gg1 = new GenerateTiles();
            Tile[] tiles1 = gg.generateTile(info1, username, importantname);
            for (int j = 0; j < tiles1.Length; j++)
                //Response.Write(j);
  
            for (int k = 0; k < tiles1.Length; k++)
                Response.Write(tiles1[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            //Response.Write(templateIndex);
            ScreenTemplate currentTemplate2 = templates[templateIndex][2];
            GenerateTileInfo gen2 = new GenerateTileInfo();
            Dictionary<int, String[]> info2 = gen.generate(currentTemplate2, templateIndex, colorindex, input);
            GenerateTiles gg2 = new GenerateTiles();
            Tile[] tiles2 = gg2.generateTile(info2, username, importantname);
            for (int j = 0; j < tiles2.Length; j++)
                //Response.Write(j);

            for (int k = 0; k < tiles2.Length; k++)
                Response.Write(tiles2[k].GetHtml());

            input = Calculate_RandomInput(input);
            colorindex = random.Next(0, 8);
            templateIndex = random.Next(0, templates.Count());
            //Response.Write(templateIndex);
            ScreenTemplate currentTemplate3 = templates[templateIndex][3];
            GenerateTileInfo gen3 = new GenerateTileInfo();
            Dictionary<int, String[]> info3 = gen.generate(currentTemplate3, templateIndex, colorindex, input);
            GenerateTiles gg3 = new GenerateTiles();
            Tile[] tiles3 = gg3.generateTile(info3, username, importantname);
            for (int j = 0; j < tiles3.Length; j++)
                //Response.Write(j);
            //Response.Write("<body background=\"journey_images/black-wallpapers.jpg\"  >");
            for (int k = 0; k < tiles3.Length; k++)
                Response.Write(tiles3[k].GetHtml()); */

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



