using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template4
    {
        Startpoint[] small = new Startpoint[4];
        Startpoint[] medium = new Startpoint[3];
        Startpoint[] large = new Startpoint[1];
        ScreenTemplate s;
        int add = 250;
        public template4()
        {
            small[0] = new Startpoint(600, 100);
            small[1] = new Startpoint(653, 100);
            small[2] = new Startpoint(600, 153);
            small[3] = new Startpoint(653, 153);
            medium[0] = new Startpoint(706, 100);
            medium[1] = new Startpoint(600, 311);
            medium[2] = new Startpoint(706, 311);
            large[0] = new Startpoint(600, 206);

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
            for (int i = 0; i < 3; i++)
            {
                medium[i].x = medium[i].x - add;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x - add;
            }
            ScreenTemplate s1 = new ScreenTemplate(small, medium, large);
            //2
            for (int i = 0; i < 4; i++)
            {
                small[i].x = small[i].x + 2*add;
            }
            for (int i = 0; i < 3; i++)
            {
                medium[i].x = medium[i].x + 2 * add;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x + 2 * add;
            }
            ScreenTemplate s2 = new ScreenTemplate(small, medium, large);
            //3
            for (int i = 0; i < 4; i++)
            {
                small[i].x = small[i].x + add;
            }
            for (int i = 0; i < 3; i++)
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