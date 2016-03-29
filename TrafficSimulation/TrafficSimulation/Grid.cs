using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulation
{
    class Grid : Control
    {
      //  public List<Crossroad> Crossroads { get; set; }
      //  public List<Rectangle> Placeholders { get; set; }

        public Grid()
        {
           // Crossroads = new List<Crossroad>();

            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));

            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));

            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));
            //Placeholders.Add(new Rectangle(200, 200, 200, 200));

        }

        public void Draw()
        {
                
        }

        public void AddCrossroad(Crossroad crossroad)
        {
            //Crossroads.Add(crossroad);
        }

        public void RemoveCrossroad(Crossroad crossroad)
        {
           // Crossroads.Remove(crossroad);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
