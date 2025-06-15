using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace PSO
{
    public partial class BarCounter : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Name
        {
            set
            {
                label.Text = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Value
        {
            set { hScrollBar.Value = value; }
            get { return hScrollBar.Value; }
        }


        public BarCounter()
        {
            InitializeComponent();
        }

        public void Set(int current, int min, int max)
        {
            textBox.Text = current.ToString(CultureInfo.InvariantCulture);

            hScrollBar.Minimum = min;
            hScrollBar.Maximum = max;
            hScrollBar.Value = current;
        }

        private void HScrollBarValueChanged(object sender, EventArgs e)
        {
            textBox.Text = ((HScrollBar) sender).Value.ToString(CultureInfo.InvariantCulture);
        }

        private void TextBoxTextChanged(object sender, EventArgs e)
        {
            if (((TextBox) sender).Text != "")
            {
                int nr;
                if (int.TryParse(((TextBox) sender).Text, out nr))
                    if (nr >= hScrollBar.Minimum && nr <= hScrollBar.Maximum)
                    {
                        hScrollBar.Value = nr;
                        return;
                    }
                ((TextBox) sender).Text = hScrollBar.Value.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void TextBoxLeave(object sender, EventArgs e)
        {
            ((TextBox) sender).Text = hScrollBar.Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
