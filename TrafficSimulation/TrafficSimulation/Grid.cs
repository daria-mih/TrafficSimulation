using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TrafficSimulation
{
    [Serializable()]
    class Grid : Control
    {
        //guys u get the Crossroads now from grid1.Controls
        public List<Rectangle> Placeholders { get; set; }

        public Grid()
        {
            Placeholders = new List<Rectangle>();

            Placeholders.Add(new Rectangle(0, 0, 200, 200));
            Placeholders.Add(new Rectangle(200, 0, 200, 200));
            Placeholders.Add(new Rectangle(400, 0, 200, 200));
            Placeholders.Add(new Rectangle(600, 0, 200, 200));

            Placeholders.Add(new Rectangle(0, 200, 200, 200));
            Placeholders.Add(new Rectangle(200, 200, 200, 200));
            Placeholders.Add(new Rectangle(400, 200, 200, 200));
            Placeholders.Add(new Rectangle(600, 200, 200, 200));

            Placeholders.Add(new Rectangle(0, 400, 200, 200));
            Placeholders.Add(new Rectangle(200, 400, 200, 200));
            Placeholders.Add(new Rectangle(400, 400, 200, 200));
            Placeholders.Add(new Rectangle(600, 400, 200, 200));

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
