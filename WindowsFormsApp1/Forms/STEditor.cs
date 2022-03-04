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
    public partial class STEditor : Form
    {
        private string first;
        public string First
        {
            get { return first; }
            set
            {
                first = value;
                richTextBox1.Text = "FUNCTION " + first + "\n" + "\n" + "END_FUNCTION;";

            }
        }
        public string FText
        {
            get { return string.Join("\n", richTextBox1.Lines); }
            set { richTextBox1.Text = value; }
        }

        public STEditor()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!richTextBox1.Lines[0].Contains("FUNCTION"))
            {
                MessageBox.Show("Function doesn't start with 'FUNCTION function_name'", "Editor Error", MessageBoxButtons.OK);
                return;
            }
            if (!richTextBox1.Lines.Last().EndsWith("END_FUNCTION;")) 
            {
                MessageBox.Show("Function doesn't end with 'END_FUNCTION;'", "Editor Error", MessageBoxButtons.OK);
                return;
            }
            
            DialogResult = DialogResult.OK;
        }
    }
}
