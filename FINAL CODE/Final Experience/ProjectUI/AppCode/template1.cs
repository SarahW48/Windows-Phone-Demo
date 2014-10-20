/*summary:
 * this class and other template classes define template.
 * The main information stored here is the start point of the tiles 
 * there are large, medium, small ones
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{
    public class template1
    {
        Startpoint[] small = new Startpoint[12];
        Startpoint[] medium = new Startpoint[2];
        Startpoint[] large = new Startpoint[1];
        Startpoint[] pre_small = new Startpoint[12]
        {
            new Startpoint(2,0),new Startpoint(3,0),new Startpoint(2,1),new Startpoint(3,1),new Startpoint(0,2),new Startpoint(1,2),
            new Startpoint(0,3),new Startpoint(1,3),new Startpoint(0,4),new Startpoint(1,4),new Startpoint(2,4),new Startpoint(3,4)
        };
        Startpoint[] pre_medium = new Startpoint[2]
        {
            new Startpoint(0,0),new Startpoint(2,2)
        };
        Startpoint[] pre_large = new Startpoint[1]
        {
            new Startpoint(0,5)
        };


        ScreenTemplate s;
        int add = 250;
        //define boundaries and tile lengths
        private int standard_length = Tile.standard_length, standard_boundary = Tile.standard_boundary, start_x = Tile.start_x, start_y = Tile.start_y;

        public template1()
        {

            for (int i = 0; i < 12; i++)//this template has 12 small tiles
            {
                small[i] = new Startpoint((start_x + pre_small[i].x * (standard_length + standard_boundary) + standard_boundary), (start_y + pre_small[i].y * (standard_length + standard_boundary) + standard_boundary));
            }
            for (int i = 0; i < 2; i++)//this template has 2 medium tiles
            {
                medium[i] = new Startpoint((start_x + pre_medium[i].x * (standard_length + standard_boundary) + standard_boundary), (start_y + pre_medium[i].y * (standard_length + standard_boundary) + standard_boundary));
            }
            for (int i = 0; i < 1; i++)//this template has one large tile
            {
                large[i] = new Startpoint((start_x + pre_large[i].x * (standard_length + standard_boundary) + standard_boundary), (start_y + pre_large[i].y * (standard_length + standard_boundary) + standard_boundary));
            }

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
            //put them into the template
            ScreenTemplate[] ss = new ScreenTemplate[4];
            ss[0] = s1;
            ss[1] = s;
            ss[2] = s2;
            ss[3] = s3;
            return ss;

        }

    }

}