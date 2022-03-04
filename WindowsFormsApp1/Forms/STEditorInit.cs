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
    public partial class STEditorInit : Form
    {
        public string FName { get; set; }
        public STEditorInit()
        {
            InitializeComponent();
            FName = "function1";
            textBox1.Text = FName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FName = textBox1.Text;
        }
    }
}
