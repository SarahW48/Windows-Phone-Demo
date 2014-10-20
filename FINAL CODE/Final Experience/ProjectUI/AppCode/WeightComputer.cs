/*this class use the matrix caculated by the algorith to caculate the 
 * weight of every categories finally choose the biggest one from the 5 popular category
 * choose the biggest one from the nonpupular 7 categories
 * set the weight of other categories to 0
 */

using System;
using System.Web;
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

        //the first popular 5 categories
        for (int j = 0; j < choiceNum; j++)
        {
            for (int i = 0; i < famousNum; i++)
                weight[i] += input[j] * SupportMatrix[j, i];
        }

        //the not famouse categories
        for (int j = 0; j < choiceNum; j++)
        {
            for (int i = 0; i < noFamousNum; i++)
                weight2[i] += input[j] * SupportMatrix2[j, i];
        }

        //get the max one for the 5 famous category
        int max = 0;
        try
        {
            getFirstMaxIndex(weight, ref max);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        //get the max one for the 7 not famous category          
        for (int i = 0; i < famousNum; i++)
        {

            if ((i != max) )
            {
                output[i, 1] = 0;
            }
            else 
            {
                output[i, 1] = weight[i];
            }
        }
            
        max = 0;
        try
        {
            getFirstMaxIndex(weight2, ref max);
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }

        for (int i = 0; i < noFamousNum; i++)
        {
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

    /* choose the biggest 2 values in array arr
     * use ref to return the index of the 2 values
     * 
     * max is the index of the biggest value
     * secMax is the index of the 2nd biggest value
    */
    private static void getFirstMaxIndex(double[] arr, ref int max)
    {
        if (arr.Length < 2)
            throw new Exception("invalid array!");
        max = (arr[0] > arr[1]) ? 0 : 1;
        for (int j = 2;j < arr.Length; j++)
        {
            if (arr[j] > arr[max])
            {
                max = j;
            }
        }
    }

}
