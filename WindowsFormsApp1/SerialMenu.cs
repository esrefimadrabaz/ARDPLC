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
    public partial class SerialMenu : Form
    {
        public string Function { get; set; }
        public int Value { get; set; }
        public string Format { get; set; }

        public SerialMenu()
        {
            InitializeComponent();
            FunctionBox.SelectedIndex = 0;
            FormatBox.SelectedIndex = 0;
            Value = 0;
            Format = "DEC";
            Function = "begin";
            hideMenu();
        }
        
        private void hideMenu()
        {
            ValueLabel.Visible = false;
            FormatLabel.Visible = false;
            dLabel.Visible = false;
            dIndex.Visible = false;
            FormatBox.Visible = false;
        }
        private void showMenu()
        {
            ValueLabel.Visible = true;
            FormatLabel.Visible = true;
            dLabel.Visible = true;
            dIndex.Visible = true;
            FormatBox.Visible = true;
        }

        private void FunctionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function = FunctionBox.SelectedItem.ToString();
            if(FunctionBox.SelectedIndex == 2)
            {
                showMenu();
            }
            else
            {
                hideMenu();
            }
        }


        private void FormatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Format = FormatBox.SelectedItem.ToString();
        }

        private void dIndex_ValueChanged(object sender, EventArgs e)
        {
            Value = Convert.ToInt32(dIndex.Value);
        }
    }
}
