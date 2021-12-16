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
    public partial class CMPMenu : Form
    {
        public string Type { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public dynamic FirstValue { get; set; }
        public dynamic MiddleValue { get; set; }
        public dynamic LastValue { get; set; }
        public int ResultValue { get; set; }

        public CMPMenu()
        {
            InitializeComponent();
            Type = "CMP";
            First = "K";
            Middle = "K";
            Last = "K";
            FirstValue = 10;
            MiddleValue = 10;
            LastValue = 10;
            ResultValue = 0;
            TypeDef.SelectedIndex = 0;
            FirstDef.SelectedIndex = 0;
            MiddleDef.SelectedIndex = 0;
            LastDef.SelectedIndex = 0;

            MiddleDef.Visible = false;
            MiddleVal.Visible = false;
        }

        private void TypeDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type = Convert.ToString(TypeDef.SelectedItem);
            if (Type == "ZONECMP")
            {
                MiddleDef.Visible = true;
                MiddleVal.Visible = true;
                Type = "ZCMP";
            }
            else
            {
                MiddleDef.Visible = false;
                MiddleVal.Visible = false;
            }
        }
        private void FirstDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort(FirstDef, FirstVal);
            First = Convert.ToString(FirstDef.SelectedItem);
        }
        private void MiddleDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort(MiddleDef, MiddleVal);
            Middle = Convert.ToString(MiddleDef.SelectedItem);
        }
        private void LastDef_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort(LastDef, LastVal);
            Last = Convert.ToString(LastDef.SelectedItem);
        }


        private void FirstVal_ValueChanged(object sender, EventArgs e)
        {
            if (First == "K")
            {
                FirstValue = Convert.ToInt16(FirstVal.Value);
            }
            else if (First == "F")
            {
                FirstValue = Convert.ToDouble(FirstVal.Value);
            }
            else if (First == "L")
            {
                FirstValue = Convert.ToInt32(FirstVal.Value);
            }
            else { FirstValue = Convert.ToInt32(FirstVal.Value); }
        }
        private void MiddleVal_ValueChanged(object sender, EventArgs e)
        {
            if (Middle == "K")
            {
                MiddleValue = Convert.ToInt16(MiddleVal.Value);
            }
            else if (Middle == "F")
            {
                MiddleValue = Convert.ToDouble(MiddleVal.Value);
            }
            else if (Middle == "L")
            {
                MiddleValue = Convert.ToInt32(MiddleVal.Value);
            }
            else { MiddleValue = Convert.ToInt32(MiddleVal.Value); }
        }
        private void LastVal_ValueChanged(object sender, EventArgs e)
        {
            if (Last == "K")
            {
                LastValue = Convert.ToInt16(LastVal.Value);
            }
            else if (Last == "F")
            {
                LastValue = Convert.ToDouble(LastVal.Value);
            }
            else if (Last == "L")
            {
                LastValue = Convert.ToInt32(LastVal.Value);
            }
            else { LastValue = Convert.ToInt32(LastVal.Value); }
        }
        private void ResultVal_ValueChanged(object sender, EventArgs e)
        {
            ResultValue = Convert.ToInt32(ResultVal.Value);
        }


        private void Sort(ComboBox Selecter, NumericUpDown Value)
        {
            switch (Selecter.SelectedIndex)
            {
                case 0: // K 
                    Value.Maximum = 32767;
                    Value.Minimum = -32768;
                    Value.DecimalPlaces = 0;
                    break;
                case 1: //f
                    Value.Maximum = Convert.ToDecimal(7.902822E+28);
                    Value.Minimum = Convert.ToDecimal(-7.902822E+28);
                    Value.DecimalPlaces = 6;
                    break;
                case 2: //l
                    Value.Maximum = 2000000000;
                    Value.Minimum = -2000000000;
                    Value.DecimalPlaces = 0;
                    break;
                default:
                    Value.Maximum = 100;
                    Value.Minimum = 0;
                    Value.DecimalPlaces = 0;
                    break;
            }
        }

        
    }
}
