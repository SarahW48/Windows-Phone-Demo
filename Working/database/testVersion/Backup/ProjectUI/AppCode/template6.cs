using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template6
    {
        Startpoint[] small = null;
        Startpoint[] medium = new Startpoint[4];
        Startpoint[] large = new Startpoint[1];
        ScreenTemplate s;
        
        public template6()
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
            for (int i = 0; i < 4; i++)
            {
                medium[i].x = medium[i].x - 250;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x - 250;
            }  
            ScreenTemplate s1 = new ScreenTemplate(small, medium, large);
            //2
            for (int i = 0; i < 4; i++)
            {
                medium[i].x = medium[i].x + 500;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x + 500;
            }
            ScreenTemplate s2 = new ScreenTemplate(small, medium, large);
            //3
            for (int i = 0; i < 4; i++)
            {
                medium[i].x = medium[i].x + 250;
            }
            for (int i = 0; i < 1; i++)
            {
                large[i].x = large[i].x + 250;
            }
            ScreenTemplate s3 = new ScreenTemplate(small, medium, large);

            ScreenTemplate[] ss= new ScreenTemplate[4];
            ss[0] = s;
            ss[1] = s1;
            ss[2] = s2;
            ss[3] = s3;
            return ss;

        }
    }
}