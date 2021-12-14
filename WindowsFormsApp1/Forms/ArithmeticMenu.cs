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
    public partial class ArithmeticMenu : Form
    {
        public string PreDef { get; set; }
        public dynamic PreValue { get; set; }
        public string PostDef { get; set; }
        public dynamic PostValue { get; set; }
        public string Operation { get; set; }
        public int ResultValue { get; set; }

        public ArithmeticMenu()
        {
            InitializeComponent();
            PreDef = "K";
            PostDef = "K";
            Operation = "+";
            ResultValue = 0;
            PreValue = 0;
            PostValue = 0;

            Pre.SelectedIndex = 0;
            Post.SelectedIndex = 0;
            Ops.SelectedIndex = 0;

        }

        private void Pre_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(Pre.SelectedItem))
            {
                case "K":
                    PreVal.Maximum = 32767;
                    PreVal.Minimum = -32768;
                    PreVal.DecimalPlaces = 0;
                    PreDef = "K";
                    break;
                case "F":
                    PreVal.Maximum = Convert.ToDecimal(7.902822E+28);
                    PreVal.Minimum = Convert.ToDecimal(-7.902822E+28);
                    PreVal.DecimalPlaces = 6;
                    PreDef = "F";
                    break;
                case "L":
                    PreVal.Maximum = 2000000000;
                    PreVal.Minimum = -2000000000;
                    PreVal.DecimalPlaces = 0;
                    PreDef = "L";
                    break;
                case "D":
                    PreVal.Maximum = 100;
                    PreVal.Minimum = 0;
                    PreVal.DecimalPlaces = 0;
                    PreDef = "D";
                    break;
                default:
                    break;
            }
        }

        private void Post_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Convert.ToString(Post.SelectedItem))
            {
                case "K":
                    PostVal.Maximum = 32767;
                    PostVal.Minimum = -32768;
                    PostVal.DecimalPlaces = 0;
                    PostDef = "K";
                    break;
                case "F":
                    PostVal.Maximum = Convert.ToDecimal(7.902822E+28);
                    PostVal.Minimum = Convert.ToDecimal(-7.902822E+28);
                    PostVal.DecimalPlaces = 6;
                    PostDef = "F";
                    break;
                case "L":
                    PostVal.Maximum = 2000000000;
                    PostVal.Minimum = -2000000000;
                    PostVal.DecimalPlaces = 0;
                    PostDef = "L";
                    break;
                case "D":
                    PostVal.Maximum = 100;
                    PostVal.Minimum = 0;
                    PostVal.DecimalPlaces = 0;
                    PostDef = "D";
                    break;
                default:
                    break;
            }
        }

        private void Ops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(Ops.SelectedItem) == "-")
            {
                Operation = "|";
            }
            else { Operation = Convert.ToString(Ops.SelectedItem); }
            
        }

        private void ResultVal_ValueChanged(object sender, EventArgs e)
        {
            ResultValue = Convert.ToInt32(ResultVal.Value);
        }

        private void PreVal_ValueChanged(object sender, EventArgs e)
        {
            if (PreDef == "K")
            {
                PreValue = Convert.ToInt16(PreVal.Value);
            }
            else if (PreDef == "F")
            {
                PreValue = Convert.ToDouble(PreVal.Value);
            }
            else if (PreDef == "L")
            {
                PreValue = Convert.ToInt32(PreVal.Value);
            }
            else if (PreDef == "D")
            {
                PreValue = Convert.ToInt32(PreVal.Value);
            }
        }

        private void PostVal_ValueChanged(object sender, EventArgs e)
        {
            if (PostDef == "K")
            {
                PostValue = Convert.ToInt16(PostVal.Value);
            }
            else if (PostDef == "F")
            {
                PostValue = Convert.ToDouble(PostVal.Value);
            }
            else if (PostDef == "L")
            {
                PostValue = Convert.ToInt32(PostVal.Value);
            }
            else if (PostDef == "D")
            {
                PostValue = Convert.ToInt32(PostVal.Value);
            }
        }
    }
}
