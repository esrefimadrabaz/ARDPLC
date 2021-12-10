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
    public partial class CounterMenu : Form
    {
        public string Type { get; set; }
        public int Preset { get; set; }
        public string Preset_Def { get; set; }
        public int Counter { get; set; }
        public CounterMenu()
        {
            InitializeComponent();
            Type = "CounterUp";
            Preset = 1;
            Preset_Def = "K";
            Counter = 0;
            comboBox3.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Counter = Convert.ToInt32(numericUpDown1.Value);
        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type = Convert.ToString(comboBox3.SelectedItem);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preset_Def = Convert.ToString(comboBox2.SelectedItem);
            if (comboBox2.SelectedIndex == 0) { numericUpDown2.Maximum = 2000000000; numericUpDown2.Minimum = 1; }
            else if (comboBox2.SelectedIndex == 1) { numericUpDown2.Maximum = 100; numericUpDown2.Minimum = 0; }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Preset = Convert.ToInt32(numericUpDown2.Value);
        }
    }
}
