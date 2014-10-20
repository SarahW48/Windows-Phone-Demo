using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template1
    {
        Startpoint[] small = null;
        Startpoint[] medium = new Startpoint[4];
        Startpoint[] large = new Startpoint[1];
        ScreenTemplate s;
        int add = 250;
        public template1()
        {
            medium[0] = new Startpoint(600, 100);
            medium[1] = new Startpoint(706, 100);
            medium[2] = new Startpoint(600, 206);
            medium[3] = new Startpoint(706, 206);
            large[0]  =  new Startpoint(600, 312);

            s = new ScreenTemplate(small, medium, large);
        }

        //creating another 3 
        public ScreenTemplate[] GenerateTemplate()
        { 
            //0
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
            for (int i = 0; i < medium.Length; i++)
            {
                medium[i].x = medium[i].x + 2*add;
            }
            for (int i = 0; i < large.Length; i++)
            {
                large[i].x = large[i].x + 2 * add;
            }
            ScreenTemplate s2 = new ScreenTemplate(small, medium, large);
            //3
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