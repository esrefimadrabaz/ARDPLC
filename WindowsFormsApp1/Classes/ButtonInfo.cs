using System;
using System.Collections.Generic;
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
        

    }
}
