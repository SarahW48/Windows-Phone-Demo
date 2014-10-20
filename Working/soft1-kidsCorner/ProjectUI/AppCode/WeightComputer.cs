using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class WeightComputer
{
    private int choiceNum;
    //private int resultNum;
    public WeightComputer(int[] input, double[,] output, int ctgrNum)
    {
        choiceNum = input.Length;
        double reduce = 0.85;
        //int len1 = output.GetLength(0);
        double[] weight = new double[ctgrNum];
        if(output.GetLength(0) != ctgrNum)
            throw new Exception("Unmatched array!");
        /* support matrix
         * given by the Apriori Algorithm according to the survey
         * used to compute the weight matrix by multiplying with the input matrix
         * will be revised when the data is done
         */
        double[,] SupportMatrix = new double[,]
               {{0,    46.95*reduce,45.69*reduce,45.27*reduce,42.45,34.36,33.8,35.46,27.69,28.54,28.19,29.63,25.86},
                {0,    36.73*reduce,35.72*reduce,35.47*reduce,33.73,27.46,27.37,28.4,22.56,23.11,22.86,23.95,20.98},
                {0,    46.86*reduce,45.59*reduce,45.19*reduce,42.35,34.28,33.69,35.36,27.58,28.37,28.07,29.53,25.76},
                {0,    40.59*reduce,39.48*reduce,39.18*reduce, 37.01,30.04,29.7,31,24.4,25.14,24.77,25.96,22.7},
                {0,    46.98*reduce,45.7*reduce, 45.29*reduce,42.52,34.34,33.89,35.34,27.79,28.67,28.28,29.7,25.94},
                {0,    44.88*reduce,43.64*reduce,43.27*reduce,40.41,32.61,31.84,33.76,25.94,26.7,26.41,27.82,24.2},
                {0,    46.81*reduce,45.49*reduce,45.18*reduce,42.27,34.23,33.61,35.21,27.52,28.29,28.01,29.46,25.7},
                {0,    41.54*reduce,40.48*reduce,40.04*reduce,37.82,30.53,30.27,31.65,24.84,25.63,25.24,26.48,23.13},
                {0,    47.04*reduce,45.78*reduce,45.37*reduce,42.58,34.38,33.96,35.53,27.85,28.73,28.35,29.76,25.99},
                {0,    43.27*reduce,42.05*reduce,41.74*reduce,39.04,31.64,30.87,32.49,25.19,25.9,25.63,26.99,23.51},
                {0,    46.79*reduce,45.48*reduce,45.12*reduce,42.34,34.28,33.73,35.37,27.63,28.41,28.11,29.54,25.79},
                {0,    40.41*reduce,39.35*reduce,39*reduce,36.81,29.95,29.47,30.76,24.17,24.91,24.55,25.77,22.54},
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0,    0},
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0,    0},
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0,    0},
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0,    0},
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0, 0,    0},
                {0,    47.66*reduce,46.33*reduce,45.96*reduce,43.04,34.77,34.18,35.86,27.97,28.79,28.49,29.92,26.11},
                {0,    41.25*reduce,40.07*reduce,39.75*reduce, 37.57,30.5,30,31.41,24.59,25.24,24.94,26.23,22.91},
                {0,    47.62*reduce,46.36*reduce,45.93*reduce,43.05,34.84,34.28,35.96,28.08,28.95,28.59,30.03,26.21},
                {0,    42.14*reduce,40.95*reduce,40.62*reduce, 38.3,31.01,30.51,31.95,25,25.77,25.39,26.67,23.29},
                {0,    47.62*reduce,46.36*reduce,45.92*reduce,43.09,34.91,34.34,36.02,28.13,28.92,28.62,30.08,26.26},
                {0,    43.06*reduce,41.87*reduce,41.48*reduce, 39,   31.7,31,32.57,25.36,26.06,25.79,27.22,23.77},
                {0,    47.47*reduce,46.17*reduce,45.82*reduce,42.91,34.63,34.18,35.78,28,28.89,28.49,29.86,26.04},
                {0,    34.31*reduce,33.5*reduce, 33.14*reduce,31.13,25.37,25.23,26.28,20.82,21.37,21.4,22.17,19.49},
                {0,    47.41*reduce,46.12*reduce,45.71*reduce,42.94,34.73,34.17,35.82,27.98,28.78,28.38,29.9,26.1},
                {0,    47.12*reduce,45.85*reduce,45.44*reduce, 42.64,34.4,33.9,35.57,27.77,28.65,28.27,29.69,25.85},
                {0,    35.66*reduce,34.7*reduce, 34.5*reduce,32.65,26.93,26.78,27.65,22.12,22.58,22.41,23.5,20.7},
                {0,    40.68*reduce,39.62*reduce,39.25*reduce,36.84,29.93,29.41,30.8,24.08,24.75,24.62,25.77,22.57},
                {0,    46.96*reduce,45.64*reduce,45.29*reduce,42.64,34.55,34.04,35.63,27.92,28.75,28.29,29.78,25.97},
                {0,    45.98*reduce,44.64*reduce,44.32*reduce,41.67,33.67,33.09,34.69,27.12,28.01,27.48,29.04,25.27},
                {0,    46.61*reduce,45.42*reduce,44.95*reduce,41.94,33.83,33.22,34.96,27.11,27.88,27.73,29,25.33},
                {0,    43.5*reduce,42.25*reduce,41.91*reduce,39.42,31.87,31.14,32.69,25.44,26.28,25.86,27.22,23.72},
                {0,    47.09*reduce,45.85*reduce,45.42*reduce,42.56,34.39,33.94,35.61,27.8, 28.58,28.3,29.72,25.95}};

        
            if (input.Length != SupportMatrix.GetLength(0))
            {
                Console.WriteLine("Support Matrix Error. Program Exit.");
                return;
            }

            /* matrix multiplication
             * calculate the result matrix by multiply the input 
             * matrix with the support matrix
             * get the weight of each personality
             */
            /*for (int i = 0; i < len1; i++){
                output[i, 0] = i;
                output[i, 1] = 0;
            }*/
            for (int j = 0; j < choiceNum; j++)
            {
                for (int i = 0; i < ctgrNum; i++)
                    weight[i] += input[j] * SupportMatrix[j, i];
            }

            /* choose the strongest 2 personalities 
             * max is the index of the strongest personality
             * secMax is the second strongest personality index
             */
            int max = 0, secMax = 0;
            try
            {
                getFirst2MaxIndex(weight, ref max, ref secMax);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
            
            /* get the most significant categories according to the weight */
           /* output[0, 0] = max;
            output[0, 1] = weight[max];
            output[1, 0] = secMax;
            output[1, 1] = weight[secMax];*/
            for (int i = 0; i < ctgrNum; i++)
            {
                output[i, 0] = i;
                if ((i != max) && (i != secMax))
                {
                    output[i, 1] = 0;
                }
                else 
                {
                    output[i, 1] = weight[i];
                }
            }
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
