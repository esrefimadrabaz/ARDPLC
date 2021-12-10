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
    public partial class MovMenu : Form
    {
        
        public string Type_From { get; set; }
        public string Type_To { get; set; }
        public int Val_From { get; set; }
        public int Val_To { get; set; }

        public MovMenu()
        {
            InitializeComponent();            
            Type_To = "D";
            Val_From = 1000;
            Val_To = 0;
            comboBox1.SelectedItem = "K";
            comboBox2.SelectedIndex = 0;
            numericUpDown2.Value = 1000;
            Type_From = "K";
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "K") { numericUpDown2.Maximum = 2000000000; numericUpDown2.Minimum = -2000000000; }
            else if (Convert.ToString(comboBox1.SelectedItem) == "D") { numericUpDown2.Maximum = 100; numericUpDown2.Minimum = 0; }
            else if (Convert.ToString(comboBox1.SelectedItem) == "CNTR") { numericUpDown2.Maximum = 100; numericUpDown2.Minimum = 0; }
            Type_From = Convert.ToString(comboBox1.SelectedItem);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox2.SelectedItem) == "D") { numericUpDown1.Maximum = 100; numericUpDown2.Minimum = 0; }
            Type_To = Convert.ToString(comboBox2.SelectedItem);
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Val_From = Convert.ToInt32(numericUpDown2.Value);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Val_To = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
