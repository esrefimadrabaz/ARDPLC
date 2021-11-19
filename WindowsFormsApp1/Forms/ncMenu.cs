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
    public partial class ncMenu : Form
    {
        public int Pin { get; set; }
        public string Mode { get; set; }
        public string Type { get; set; }
        public ncMenu()
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
            }
            else if (Convert.ToString(comboBox2.SelectedItem) == "Output")
            {
                Type = "O";
            }
        }
    }
}
