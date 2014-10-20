using System;
using System.Web;
/// <summary>
/// Summary description for Class1
/// </summary>
public class WeightComputer
{
    private int choiceNum;
    //private int resultNum;
    //two matrix
    public WeightComputer(int[] input, double[,] output, double[,] output2, int ctgrNum) //the input is 
    {
        choiceNum = input.Length;//all choices 56 in total
        int famousNum = 5;
        int noFamousNum = 7;
        double[] weight = new double[famousNum];
        double[] weight2 = new double[noFamousNum];

        //the first five most popular categories
        double[,] SupportMatrix = new double[,]
            {
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,   0.19,      0,      0,      0},
                {      0,   0.19,      0,      0,      0},
                {      0,      0,      0,      0,   0.13},
                {      0,      0,      0,   0.12,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {    0.3,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,   0.19,      0,      0,      0},
                {      0,      0,      0,   0.12,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {    0.3,      0,      0,      0,      0},
                {      0,      0,      0,   0.12,      0},
                {      0,      0,      0,   0.12,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,  -0.12,      0},
                {      0,   0.19,      0,      0,      0},
                {    0.3,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,   0.19,      0,      0,      0},
                {      0,      0,      0,   0.12,      0},
                {  -0.12,   0.19,   0.18,  -0.12,   0.13},
                {      0,   0.19,      0,  -0.12,      0},
                {    0.3,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {  -0.12,   0.19,      0,   0.12,      0},
                {      0,      0,   0.18,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,   0.13},
                {      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0},
                {    0.3,      0,      0,      0,      0},
                {      0,      0,   0.18,      0,      0}         
            
            };
        //the seven not popular categories
        double[,] SupportMatrix2 = new double[,]
            {
                {      0,      0,      0,      0,      0,      0,      0},
                {  -0.05,      0,      0,  -0.05,      0,   0.05,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,   0.11,  -0.05,      0,      0,   0.05,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,   0.11,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,   0.05},
                {   0.41,      0,      0,      0,  -0.05,  -0.05,  -0.05},
                {      0,      0,      0,   0.07,      0,      0,      0},
                {      0,   0.11,      0,      0,   0.11,   0.05,  -0.05},
                {   0.41,      0,      0,  -0.05,  -0.05,  -0.05,      0},
                {      0,  -0.05,      0,   0.07,      0,   0.05,      0},
                {      0,  -0.05,      0,      0,   0.11,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,   0.11,      0,      0,      0,  -0.05,      0},
                {      0,      0,      0,   0.07,      0,      0,   0.05},
                {      0,   0.11,   0.11,   0.07,  -0.05,      0,      0},
                {      0,  -0.05,      0,   0.07,      0,   0.05,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,   0.11,      0,      0,      0,  -0.05,      0},
                {      0,   0.11,   0.11,   0.07,      0,   0.05,  -0.05},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,  -0.05,   0.11,      0,   0.11,   0.05,      0},
                {      0,  -0.05,      0,      0,   0.11,   0.05,      0},
                {      0,  -0.05,      0,   0.07,      0,      0,   0.05},
                {      0,   0.11,  -0.05,      0,  -0.05,  -0.05,  -0.05},
                {      0,   0.11,      0,      0,  -0.05,  -0.05,      0},
                {      0,   0.11,      0,      0,  -0.05,      0,   0.05},
                {      0,      0,      0,   0.07,      0,      0,   0.05},
                {      0,      0,      0,      0,   0.11,   0.05,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,   0.11,   0.05,      0},
                {      0,      0,      0,      0,  -0.05,      0,      0},
                {      0,      0,      0,   0.07,      0,      0,      0},
                {      0,   0.11,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,   0.11,   0.05,      0},
                {      0,      0,      0,   0.07,      0,      0,      0},
                {      0,      0,      0,      0,  -0.05,      0,   0.05},
                {      0,      0,      0,   0.07,   0.11,      0,  -0.05},
                {      0,   0.11,      0,   0.07,  -0.05,      0,      0},
                {      0,      0,      0,  -0.05,      0,   0.05,      0},
                {      0,   0.11,      0,  -0.05,  -0.05,  -0.05,  -0.05},
                {      0,  -0.05,   0.11,   0.07,   0.11,      0,   0.05},
                {      0,   0.11,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,      0,  -0.05,   0.07,      0,   0.05,   0.05},
                {      0,      0,      0,      0,      0,   0.05,      0},
                {      0,      0,      0,      0,      0,      0,      0},
                {      0,   0.11,      0,      0,      0,   0.05,      0},
                {  -0.05,      0,      0,      0,      0,      0,      0},
                {      0,      0,      0,   0.07,   0.11,      0,   0.05},      
            
            };

        //caculating the weight of the first popular 5 categories
        for (int j = 0; j < choiceNum; j++)
        {
            for (int i = 0; i < famousNum; i++)
                weight[i] += input[j] * SupportMatrix[j, i];
        }

        //caculating the weight of the  the not famouse categories
        for (int j = 0; j < choiceNum; j++)
        {
            for (int i = 0; i < noFamousNum; i++)
                weight2[i] += input[j] * SupportMatrix2[j, i];
        }

        /*get the max one for the 5 famous category*/
        int max = 0;
        try
        {
            getFirstMaxIndex(weight, ref max);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        /*set weight to 0 if it is not th emost popular one*/
        for (int i = 0; i < famousNum; i++)
        {
            //output[i, 0] = i;
            if ((i != max))
            {
                output[i, 1] = 0;
            }
            else
            {
                output[i, 1] = weight[i];
            }
        }

        max = 0;
        /*get the max one for the 7 not famous category*/
        try
        {
            getFirstMaxIndex(weight2, ref max);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        /*set weight to 0 if it is not th emost popular one*/
        for (int i = 0; i < noFamousNum; i++)
        {
            //output2[i, 0] = i;
            if ((i != max))
            {
                output2[i, 1] = 0;
            }
            else
            {
                output2[i, 1] = weight2[i];
            }

        }


    }

    /* choose the biggest value in array arr
     * max is the index of the biggest value
     */
    private static void getFirstMaxIndex(double[] arr, ref int max)
    {
        if (arr.Length < 2)
            throw new Exception("invalid array!");
        max = (arr[0] > arr[1]) ? 0 : 1;
        for (int j = 2; j < arr.Length; j++)
        {
            if (arr[j] > arr[max])
            {
                max = j;
            }
        }
    }
}
