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
    public partial class SetMenu : Form
    {
        public string Type { get; set; }
        public int Pin { get; set; }
        public SetMenu()
        {
            InitializeComponent();
            Type = "O";
            Pin = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 0) { numericUpDown1.Maximum = 9; numericUpDown1.Minimum = 0; }
            else if (comboBox2.SelectedIndex == 1) { numericUpDown1.Maximum = 100; numericUpDown1.Minimum = 0; }
            Type = Convert.ToString(comboBox2.SelectedItem);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
