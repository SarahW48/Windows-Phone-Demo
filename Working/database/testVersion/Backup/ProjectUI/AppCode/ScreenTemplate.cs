using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace ProjectUI.AppCode
{

    public class ScreenTemplate
    {
        private Dictionary<Startpoint, string> Small = new Dictionary<Startpoint, string>();
        private Dictionary<Startpoint, string> Medium = new Dictionary<Startpoint, string>();
        private Dictionary<Startpoint, string> Large = new Dictionary<Startpoint, string>();
        public ScreenTemplate(Startpoint[] Small, Startpoint[] Medium, Startpoint[] Large)
        {
            if (Small != null)
            {
                for (int i = 0; i < Small.Length; i++ )
                {
                    this.Small.Add(new Startpoint(Small[i].x, Small[i].y), "");
                    //Console.WriteLine("S " + x + " " + y);
                }
            }
            else
            {
                Small = null;
            }

            for (int i = 0; i < Medium.Length; i++)
            {
                this.Medium.Add(new Startpoint(Medium[i].x, Medium[i].y), "");

            }

            for (int i = 0; i < Large.Length; i++)
            {
                this.Large.Add(new Startpoint(Large[i].x, Large[i].y), "");

            }
        }

        public  Dictionary<Startpoint, string> getSmall(){return Small;}
        public  Dictionary<Startpoint, string> getLarge(){return Large;}
        public  Dictionary<Startpoint, string> getMedium(){return Medium;}
    }
}