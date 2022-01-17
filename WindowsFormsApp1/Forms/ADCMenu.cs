using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ADCMenu : Form
    {
        public int Pin { get; set; }
        public int Destination { get; set; }

        public ADCMenu()
        {
            InitializeComponent();
            Pin = 0;
            Destination = 0;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown1.Value);
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Destination = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}
