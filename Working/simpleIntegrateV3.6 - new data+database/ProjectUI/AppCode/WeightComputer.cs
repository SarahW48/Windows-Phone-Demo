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
               {{0,    0.68, 0.66, 0.66, 0.58, 0.46, 0.47, 0.5,  0.4,  0.39, 0.39, 0.42, 0.38}, 
                {0,    0.68, 0.67, 0.64, 0.61, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.68, 0.65, 0.66, 0.61, 0.49, 0.47, 0.52, 0.4,  0.45, 0.43, 0.43, 0.37}, 
                {0,    0.69, 0.69, 0.64, 0.56, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.67, 0.64, 0.65, 0.62, 0.47, 0.5,  0.48, 0.39, 0.45, 0.42, 0.41, 0.38}, 
                {0,    0.69, 0.69, 0.65, 0.56, 0.47, 0,    0.51, 0,    0,    0,    0,    0},    
                {0,    0.7,  0.65, 0.67, 0.57, 0.49, 0.49, 0.48, 0.4,  0.44, 0.41, 0.43, 0.36}, 
                {0,    0.65, 0.7,  0.62, 0.61, 0,    0,    0.51, 0,    0,    0,    0,    0},    
                {0,    0.66, 0.66, 0.65, 0.61, 0.46, 0.49, 0.51, 0.42, 0.42, 0.41, 0.39, 0.39}, 
                {0,    0.71, 0.68, 0.65, 0.56, 0.49, 0,    0.48, 0,    0,    0,    0,    0},    
                {0,    0.7,  0.69, 0.66, 0.59, 0.47, 0.47, 0.52, 0.4,  0.44, 0.42, 0.42, 0.38}, 
                {0,    0.65, 0.63, 0.64, 0.58, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.7,  0.67, 0.65, 0.61, 0.47, 0.46, 0.49, 0.4,  0.41, 0.41, 0.38, 0.36}, 
                {0,    0.71, 0.67, 0.63, 0.59, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.66, 0.67, 0.67, 0.58, 0.49, 0.45, 0.49, 0.39, 0.42, 0.41, 0.41, 0.35}, 
                {0,    0.74, 0.66, 0.67, 0.58, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.66, 0.69, 0.65, 0.59, 0.51, 0.47, 0.49, 0.4,  0.39, 0.42, 0.42, 0.39}, 
                {0,    0.71, 0.7,  0.69, 0.57, 0.49, 0,    0.51, 0,    0,    0,    0,    0},    
                {0,    0.67, 0.65, 0.63, 0.62, 0.46, 0.49, 0.49, 0.39, 0.42, 0.42, 0.42, 0},    
                {0,    0.67, 0.67, 0.65, 0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.69, 0.67, 0.65, 0.59, 0.48, 0.48, 0.52, 0.4,  0.4,  0.42, 0.42, 0.37}, 
                {0,    0.69, 0.68, 0.66, 0.6,  0.48, 0.46, 0.51, 0.39, 0.42, 0.41, 0.4,  0.39}, 
                {0,    0.68, 0.65, 0.64, 0,    0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.67, 0.64, 0.63, 0.55, 0,    0,    0,    0,    0,    0,    0,    0},    
                {0,    0.7,  0.69, 0.67, 0.62, 0.49, 0.46, 0.48, 0.37, 0.4,  0.42, 0.4,  0.36}, 
                {0,    0.7,  0.66, 0.65, 0.63, 0.49, 0.47, 0.49, 0,    0.45, 0,    0.42, 0},    
                {0,    0.67, 0.69, 0.66, 0.54, 0.45, 0.47, 0.5,  0,    0,    0.42, 0,    0},    
                {0,    0.71, 0.67, 0.65, 0.59, 0.5,  0,    0,    0,    0,    0,    0,    0},    
                {0,    0.66, 0.67, 0.65, 0.58, 0.45, 0.48, 0.52, 0.4,  0.38, 0.39, 0.39, 0.35}}; 

        
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
