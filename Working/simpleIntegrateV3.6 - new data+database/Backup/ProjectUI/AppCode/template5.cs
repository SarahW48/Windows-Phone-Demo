using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template5
    {
        Startpoint[] small = new Startpoint[16];
        Startpoint[] medium = new Startpoint[2];
        Startpoint[] large = new Startpoint[2];
        ScreenTemplate s;
        int add = 250;
        public template5()
        {
            small[0] = new Startpoint(600, 206);
            small[1] = new Startpoint(653, 206);
            small[2] = new Startpoint(706, 206);
            small[3] = new Startpoint(759, 206);
            small[4] = new Startpoint(600, 259);
            small[5] = new Startpoint(759, 259);
            small[6] = new Startpoint(600, 312);
            small[7] = new Startpoint(759, 312);
            small[8] = new Startpoint(600, 365);
            small[9] = new Startpoint(653, 365);
            small[10] = new Startpoint(706, 365);
            small[11] = new Startpoint(759,365);
            small[12] = new Startpoint(706,418);
            small[13] = new Startpoint(759,418);
            small[14] = new Startpoint(706,471);
            small[15] = new Startpoint(759,471);

            medium[0] = new Startpoint(653, 259);
            medium[1] = new Startpoint(600, 418);

            large[0]  =  new Startpoint(600, 100);
            large[1] = new Startpoint(600, 524);

            s = new ScreenTemplate(small, medium, large);
        }

        //creating another 3 
        public ScreenTemplate[] GenerateTemplate()
        { 
            //0
            for (int i = 0; i < small.Length; i++)
            {
                small[i].x = small[i].x - add;
            }
            for (int i = 0; i < medium.Length; i++)
            {
                medium[i].x = medium[i].x - add;
            }
            for (int i = 0; i < large.Length; i++)
            {
                large[i].x = large[i].x - add;
            }  
            ScreenTemplate s1 = new ScreenTemplate(small, medium, large);
            //2
            for (int i = 0; i < small.Length; i++)
            {
                small[i].x = small[i].x + 2*add;
            }
            for (int i = 0; i < medium.Length; i++)
            {
                medium[i].x = medium[i].x + 2 * add;
            }
            for (int i = 0; i < large.Length; i++)
            {
                large[i].x = large[i].x + 2 * add;
            }  
            ScreenTemplate s2 = new ScreenTemplate(small, medium, large);
            //3
            for (int i = 0; i < small.Length; i++)
            {
                small[i].x = small[i].x + add;
            }
            for (int i = 0; i < medium.Length; i++)
            {
                medium[i].x = medium[i].x + add;
            }
            for (int i = 0; i < large.Length; i++)
            {
                large[i].x = large[i].x + add;
            }  
            ScreenTemplate s3 = new ScreenTemplate(small, medium, large);

            ScreenTemplate[] ss= new ScreenTemplate[4];
            ss[0] = s1;
            ss[1] = s;
            ss[2] = s2;
            ss[3] = s3;
            return ss;

        }
    }
}