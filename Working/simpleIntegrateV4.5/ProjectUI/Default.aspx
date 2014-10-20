﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<script runat="server">
    public class WeightComputer
    {
        double[,] input = new double[2, 2];
        enum Colors
        {
            red, yellow, orange, pink, purple, brown, blue, green
        }
        private void Page_Load(object sender, EventArgs e)
        {
            // the index of the main color
            //int colorIndex=0;

            // the total choices number
            int choiceNum = 10;

            // the total result(personality) number
            int resultNum = 10;

            // the color set
            //string color = "white";
            string[] colors = new string[8] { "red", "yellow", "orange", "magenta", "purple", "brown", "blue", "green" };

            // the tile array of the final startscreen
            Tile[] tiles = new Tile[10];

            // the name of each choice
            string[] vals = new string[choiceNum];

            /* input array from the journey
             * get from the js 
             * used to compute the weight of the personality 
             */
            int[] jrnInput = new int[choiceNum * 2];

            /* output array from the journey
             * used to store the weights of the personalities 
             */
            double[] output = new double[resultNum];

            /* support matrix
             * given by the Apriori Algorithm according to the survey
             * used to compute the weight matrix by multiplying with the input matrix
             * will be revised when the data is done
             */
            double[,] SupportMatrix = new double[choiceNum * 2, resultNum];

            /* initialize the support matrix with faked data
             * should be updated when the survey went through Apriori
             */
            Random rand0 = new Random();
            for (int i = 0; i < choiceNum * 2; i++)
            {
                for (int j = 0; j < resultNum; j++)
                {
                    int a = rand0.Next(0, 10);
                    SupportMatrix[i, j] = (double)a / (choiceNum * 2);
                }
            }

            if (jrnInput.GetLength(0) != SupportMatrix.GetLength(0))
            {
                Console.WriteLine("Support Matrix Error. Program Exit.");
                return;
            }

            /* matrix multiplication
             * calculate the result matrix by multiply the input 
             * matrix with the support matrix
             * get the weight of each personality
             */
            for (int j = 0; j < choiceNum * 2; j++)
            {
                for (int i = 0; i < resultNum; i++)
                    output[i] += jrnInput[j] * SupportMatrix[j, i];
            }

            /* choose the strongest 2 personalities 
             * max is the index of the strongest personality
             * secMax is the second strongest personality index
             */
            int max = 0, secMax = 0;
            try
            {
                getFirst2MaxIndex(output, ref max, ref secMax);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

            //StartScreen startScreen = new StartScreen();
            double[] input = new double[2];
            input[0] = output[max];
            input[1] = output[secMax];
            //startScreen.Set_Input(input, input.Length);
            //startScreen.Load_External();
            /* Choose a random color index according to the first choice 
             * should be changed later 
             * when we can got data from the journey
             */
            /*
            if (vals[0] == "A1")
            {
                Random rand = new Random();
                colorIndex = rand.Next(0, 3);
            }
            else
            {
                Random rand = new Random();
                colorIndex = rand.Next(4,7);
            }
        
            color = colors[colorIndex];
             */

            /* emulate two startscreens with fake data
             * the output of the algorithm should have the data in this form
             * will be changed later
             */
            /*
            Tile[] tiles1 = new Tile[10];
            tiles1[0] = new Tile("messaging_samll.png", color, 300, 100, 2);
            tiles1[1] = new Tile("/images/tiles/books+reference/Bible.png", color, 406, 100, 1);
            tiles1[2] = new Tile("/images/tiles/books+reference/Wikipedia.png", color, 459, 100, 1);
            tiles1[3] = new Tile("/images/tiles/business/Box.png", color, 406, 153, 1);
            tiles1[4] = new Tile("/images/tiles/news+weather/CNN.png", color, 459, 153, 1);
            tiles1[5] = new Tile("/images/tiles/personal finance/LevelUp.png", color, 300, 206, 2);
            tiles1[6] = new Tile("/images/tiles/personal finance/PayPal.png", color, 406, 206, 1);
            tiles1[7] = new Tile("/images/tiles/travel+navigation/Yelp.png", color, 459, 206, 1);
            tiles1[8] = new Tile("/images/tiles/travel+navigation/Skyscanner.png", color, 406, 259, 1);
            tiles1[9] = new Tile("/images/tiles/travel+navigation/WinGPS.png", color, 459, 259, 1);
            for (int i = 0; i < tiles1.Length; i++)
                Response.Write(tiles1[i].GetHtml());


            Tile[] tiles2 = new Tile[11];
            tiles2[0] = new Tile("messaging_samll.png", color, 600, 100, 2);
            tiles2[1] = new Tile("messaging_samll.png", color, 706, 100, 1);
            tiles2[2] = new Tile("messaging_samll.png", color, 759, 100, 1);
            tiles2[3] = new Tile("messaging_samll.png", color, 706, 153, 1);
            tiles2[4] = new Tile("messaging_samll.png", color, 759, 153, 1);
            tiles2[5] = new Tile("messaging_samll.png", color, 600, 206, 1);
            tiles2[6] = new Tile("messaging_samll.png", color, 653, 206, 1);
            tiles2[7] = new Tile("messaging_samll.png", color, 706, 206, 2);
            tiles2[8] = new Tile("messaging_samll.png", color, 600, 259, 2);
            tiles2[9] = new Tile("messaging_samll.png", color, 706, 312, 1);
            tiles2[10] = new Tile("messaging_samll.png",color, 759, 312, 1);
            for (int i = 0; i < tiles2.Length; i++)
                Response.Write(tiles2[i].GetHtml());
                */
        }

        /***   1D matrix and 2D matrix multiplication   ***/
        private double[] CalWeights(int[] input, double[,] SupportMatrix, int choiceNum, int resultNum)
        {
            int inputSize = input.Length;
            int mLength = SupportMatrix.Length;
            double[] output = new double[resultNum];
            for (int j = 0; j < choiceNum * 2; j++)
            {
                for (int i = 0; i < resultNum; i++)
                    output[i] += input[j] * SupportMatrix[j, i];
            }
            return output;
        }

        /* choose the biggest 2 values in array arr
         * use ref to return the index of the 2 values
         * 
         * max is the index of the biggest value
         * secMax is the index of the 2nd biggest value
         */
        private static void getFirst2MaxIndex(double[] arr, ref int max, ref int secMax)
        {
            if (arr.Length < 2)
                throw new Exception("invalid array!");
            max = (arr[0] > arr[1]) ? 0 : 1;
            secMax = 1 - max;
            for (int i = 2; i < arr.Length; i++)
            {
                if (arr[i] > arr[secMax])
                {
                    secMax = i;
                    if (arr[secMax] > arr[max])
                    {
                        int tmp = max;
                        max = secMax;
                        secMax = tmp;
                    }
                }
            }
        }

        int smallt, midt;
        int maxsmallt, maxmidt, secsmallt, secmidt;

        private static void AppNumber(int max, int secMax, int smallt, int midt, ref int maxsmallt, ref int maxmidt, ref int secsmallt, ref int secmidt)
        {
            float maxpercent = max / (max + secMax);
            float secpercent = 1 - max;
            maxsmallt = (int)(Math.Round(maxpercent) * (smallt - 1));
            maxmidt = (int)(Math.Round(maxpercent) * (midt - 1));
            secsmallt = smallt - maxsmallt;
            secmidt = midt - secmidt;
        }

    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Product Test</title>
</head>
<body></body>
</html>