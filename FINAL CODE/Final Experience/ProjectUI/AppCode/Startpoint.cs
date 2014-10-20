/* Summary: The position of the upper left point
 *          Used to define the position of every tile
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectUI.AppCode
{

    public class Startpoint
    {
        public int x;
        public int y;
        public Startpoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}