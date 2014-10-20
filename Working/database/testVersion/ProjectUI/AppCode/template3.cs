using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template3
    {
        Startpoint[] small = new Startpoint[8];
        Startpoint[] medium = new Startpoint[2];
        Startpoint[] large = new Startpoint[1];
        ScreenTemplate s;
        int add = 250;
        public template3()
        {
            small[0] = new Startpoint(706, 100);
            small[1] = new Startpoint(760, 100);
            small[2] = new Startpoint(706, 153);
            small[3] = new Startpoint(760, 153);
            small[4] = new Startpoint(600, 206);
            small[5] = new Startpoint(653, 206);
            small[6] = new Startpoint(600, 259);
            small[7] = new Startpoint(653, 259);
            medium[0] = new Startpoint(600, 100);
            medium[1] = new Startpoint(706, 206);
            large[0] = new Startpoint(600, 312);

            s = new ScreenTemplate(small, medium, large);
        }

        //creating another 3 
        public ScreenTemplate[] GenerateTemplate()
        {
            //0
            for (int i = 0; i < 8; i++)
            {
                small[i].x = small[i].x - add;
            }
            for (int i = 0; i < 2; i++)
            {
                medium[i].x = medium[i].x - add;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x - add;
            }
            ScreenTemplate s1 = new ScreenTemplate(small, medium, large);
            //2
            for (int i = 0; i < 8; i++)
            {
                small[i].x = small[i].x + 2*add;
            }
            for (int i = 0; i < 2; i++)
            {
                medium[i].x = medium[i].x + 2 * add;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x + 2 * add;
            }
            ScreenTemplate s2 = new ScreenTemplate(small, medium, large);
            //3
            for (int i = 0; i < 8; i++)
            {
                small[i].x = small[i].x + add;
            }
            for (int i = 0; i < 2; i++)
            {
                medium[i].x = medium[i].x + add;
            }
            for (int i = 0; i < 1; i++)
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