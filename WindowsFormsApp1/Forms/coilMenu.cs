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
    public partial class coilMenu : Form
    {
        public int Pin { get; set; }
        public string Type { get; set; }
        public coilMenu()
        {
            InitializeComponent();
            Pin = 0;
            Type = "O";
            comboBox2.SelectedIndex = 0;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown1.Value);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox2.SelectedItem) == "Pin")
            {
                numericUpDown1.Maximum = 4;
                numericUpDown1.Minimum = 0;
                Type = "O";
            }
            else if (Convert.ToString(comboBox2.SelectedItem) == "M")
            {
                numericUpDown1.Maximum = 100;
                numericUpDown1.Minimum = 0;
                Type = "M";
            }
        }
    }
}
