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
    public partial class noMenu : Form
    {
        public int Pin { get; set; }
        public string Mode { get; set; }

        public string Type { get; set; }
        public noMenu()
        {
            InitializeComponent();
            Pin = 0;
            Mode = "pull_down";
            Type = "I";
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown1.Value);
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = Convert.ToString(comboBox1.SelectedItem);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox2.SelectedItem) == "Input")
            {
                Type = "I";
                numericUpDown1.Maximum = 4;
                numericUpDown1.Minimum = 0;
            }
            else if (Convert.ToString(comboBox2.SelectedItem) == "Output")
            {
                Type = "O";
                numericUpDown1.Maximum = 4;
                numericUpDown1.Minimum = 0;
            }
            else if (Convert.ToString(comboBox2.SelectedItem) == "M")
            {
                Type = "M";
                numericUpDown1.Maximum = 100;
                numericUpDown1.Minimum = 0;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                Type = "CNTR";
                numericUpDown1.Maximum = 100;
                numericUpDown1.Minimum = 0;
            }
        }
    }
}
