using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template6
    {
        Startpoint[] small = new Startpoint[20];
        Startpoint[] medium = new Startpoint[6];
        Startpoint[] large = new Startpoint[1];
        ScreenTemplate s;
        int add = 250;
        public template6()
        {
            small[0] = new Startpoint(706, 100);
            small[1] = new Startpoint(759, 100);
            small[2] = new Startpoint(706, 153);
            small[3] = new Startpoint(759, 153);

            small[4] = new Startpoint(600, 206);
            small[5] = new Startpoint(653, 206);

            small[6] = new Startpoint(706, 312);
            small[7] = new Startpoint(759, 312);

            small[8] = new Startpoint(706, 471);
            small[9] = new Startpoint(759, 471);
            small[10] = new Startpoint(706, 524);
            small[11] = new Startpoint(759, 524);

            small[12] = new Startpoint(706, 577);
            small[13] = new Startpoint(759, 577);
            small[14] = new Startpoint(600, 683);
            small[15] = new Startpoint(653, 683);

            small[16] = new Startpoint(600, 736);
            small[17] = new Startpoint(653, 736);
            small[18] = new Startpoint(706, 736);
            small[19] = new Startpoint(759, 736);

            medium[0] = new Startpoint(600, 100);
            medium[1] = new Startpoint(706, 206);
            medium[2] = new Startpoint(600, 259);
            medium[3] = new Startpoint(600, 471);
            medium[4] = new Startpoint(600, 577);
            medium[5] = new Startpoint(706, 630);

            large[0] = new Startpoint(600, 365);
            //large[1] = new Startpoint(600, 524);

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
                small[i].x = small[i].x + 2 * add;
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

            ScreenTemplate[] ss = new ScreenTemplate[4];
            ss[0] = s1;
            ss[1] = s;
            ss[2] = s2;
            ss[3] = s3;
            return ss;

        }
    }
}