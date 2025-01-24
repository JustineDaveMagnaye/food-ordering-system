using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Food_Ordering_System.src.main.appl.model
{
    class GradientPanel : System.Windows.Forms.Panel
    {
        public Color ColorTop { get; set; }
        public Color ColorBottom { get; set; }

        public GradientPanel()
        {
            ColorTop = Color.White;
            ColorBottom = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, ColorTop, ColorBottom, 90F))
            {
                e.Graphics.FillRectangle(lgb, ClientRectangle);
            }
        }
    }
}
