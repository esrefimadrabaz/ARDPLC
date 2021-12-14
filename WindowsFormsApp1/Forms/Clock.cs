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
    public partial class Clock : Form
    {
        public int Interval { get; set; }
        public string Timer { get; set; }
        public string Type { get; set; }
        public string Interval_Def { get; set; }
        public Clock()
        {
            InitializeComponent();
            Interval = 1000;
            Interval_Def = "K";
            Timer = "0";
            Type = "TON";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Timer = Convert.ToString(numericUpDown1.Value);
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Interval = Convert.ToInt32(numericUpDown2.Value);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type = Convert.ToString(comboBox1.SelectedItem);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0) { numericUpDown2.Maximum = 32767; numericUpDown2.Minimum = 1; } 
            else { numericUpDown2.Maximum = 100; numericUpDown2.Minimum = 0; }
            Interval_Def = Convert.ToString(comboBox2.SelectedItem);
        }
    }
}
