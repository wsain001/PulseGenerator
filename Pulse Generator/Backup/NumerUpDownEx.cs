using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Digital_Pulse_Generator
{
    public class NumerUpDownEx : NumericUpDown
    {
        private bool m_ShowUpDownButtons = true;

        public bool ShowUpDownButtons
        {
            get { return m_ShowUpDownButtons; }
            set 
            { 
                m_ShowUpDownButtons = value;
                Controls[0].Visible = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Window);
            base.OnPaint(e);
        }
    }
}
