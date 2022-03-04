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
    public partial class EXTIMenu : Form
    {
        public int Pin { get; set; }
        public string Mode { get; set; }

        public EXTIMenu()
        {
            InitializeComponent();
            Pin = 0;
            Mode = "Rising";
            comboBox2.SelectedIndex = 0;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Pin = Convert.ToInt32(numericUpDown1.Value);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = comboBox2.SelectedItem.ToString();
        }
    }
}
