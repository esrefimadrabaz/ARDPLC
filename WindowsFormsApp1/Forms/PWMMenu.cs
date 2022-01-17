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


    public partial class PWMMenu : Form
    {
        public int Value { get; set; }
        public string ValueType { get; set; }
        public int Pin { get; set; }
        public PWMMenu()
        {
            InitializeComponent();
            Value = 0;
            ValueType = "K";
            Pin = 0;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                numericUpDown1.Maximum = 255;
                numericUpDown1.Minimum = 0;
            }
            else
            {
                numericUpDown1.Maximum = 100;
                numericUpDown1.Minimum = 0;
            }
            ValueType = comboBox1.SelectedItem.ToString();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Value = Convert.ToInt32(numericUpDown1.Value);
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}
