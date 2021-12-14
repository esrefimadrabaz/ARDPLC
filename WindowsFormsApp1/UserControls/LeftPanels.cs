using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class LeftPanels : UserControl
    {
        public LeftPanels()
        {
            InitializeComponent();            
        }


        public void PopulateTreeViewDirectories()
        {
            string path = Form1.path;
            treeView1.Nodes.Clear();
            TreeNode rootNode;
            string tempPath = path.Substring(0, (path.Length - path.Split('\\').Last().Length - 1));
            DirectoryInfo info = new DirectoryInfo(tempPath);
            FileInfo fileInfo = new FileInfo(tempPath);
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                treeView1.Nodes.Add(rootNode);
                foreach (var file in info.GetFiles())
                {
                    rootNode.Nodes.Add(new TreeNode(file.Name));
                }
            }
            treeView1.TopNode.Expand();
        }
        private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);

                foreach (var file in subDir.GetFiles())
                {
                    aNode.Nodes.Add(new TreeNode(file.Name));
                }
            }
        }
        public void PopulateTreeviewPins()
        {
            treeView2.Nodes.Clear();
            TreeNode rootNode;
            if (Form1.Pre_Used_Pins.Count > 0)
            {
                foreach (string Pin in Form1.Pre_Used_Pins)
                {
                    if (Pin[0] == 'D') { rootNode = new TreeNode(Pin[0] + Pin.Substring(2)); rootNode.Tag = Pin[0] + Pin.Substring(2); }
                    else { rootNode = new TreeNode(Pin); rootNode.Tag = Pin; }
                    treeView2.Nodes.Add(rootNode);
                }
                treeView2.TopNode.Expand();
            }
        }

        public void CurrentPinPopulate(NewButton button)
        {
            if (button == null)
            {
                textBox9.Text = null;
                textBox5.Text = null;
                textBox8.Text = null;
            }
            else
            {
                switch (button.AccessibleDescription)
                {
                    case "0":
                        textBox8.Text = "Normally Open";
                        break;
                    case "1":
                        textBox8.Text = "Normally Closed";
                        break;
                    case "2":
                        textBox8.Text = "TimerON";
                        break;
                    case "3":
                        textBox8.Text = "TimerOFF";
                        break;
                    case "4":
                        textBox8.Text = "Coil";
                        break;
                    case "5":
                        textBox8.Text = "MOV";
                        break;
                    case "6":
                        textBox8.Text = "CounterUP";
                        break;
                    case "7":
                        textBox8.Text = "CounterDWN";
                        break;
                    case "8":
                        textBox8.Text = "Set";
                        break;
                    case "9":
                        textBox8.Text = "Reset";
                        break;
                    case "10":
                        textBox8.Text = "Empty";
                        break;
                    case "11":
                        textBox8.Text = "Network Start";
                        break;
                    case "12":
                        textBox8.Text = "Arithmetic";
                        break;
                    case "13":
                        textBox8.Text = "TimerRO";
                        break;
                    default:
                        textBox8.Text = "Parallel";
                        break;
                }
                textBox5.Text = button.Network;
                textBox9.Text = button.AccessibleName;
            }
        }
    }
}
