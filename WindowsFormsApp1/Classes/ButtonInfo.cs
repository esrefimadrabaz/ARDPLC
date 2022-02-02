using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class NewButton : Button
    {
        public string Network { get; set; }
        public bool HasPrl { get; set; }
        public NewButton PrlTo { get; set; }
        public NewButton[] Parallels { get; set; }
        public bool Status { get; set; }
        public int? Value { get; set; }
        public bool Last { get; set; }
        public System.Timers.Timer timer { get; set; }
    }
}
