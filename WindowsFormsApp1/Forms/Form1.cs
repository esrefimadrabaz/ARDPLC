using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;
using System.Reflection;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string sec = null;
        string buton;
        private bool buton_checked = false;
        private List<Button> network_1;
        private string button_names;
        private Button yaratilan;
        private Button previous;
        private Button secili;
        private Button prl_to;
        int network_count = 1;
        int x = 10;
        int y = 150;
        int x_loc = 0;
        public static Dictionary<string, List<Button>> all_list;
        public static List<string> Pre_Used_Pins;
        public static List<string> Used_Pins;


        public Form1()
        {
            InitializeComponent();
            Used_Pins = new List<string>();
            Pre_Used_Pins = new List<string>();
            network_1 = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            all_list = new Dictionary<string, List<Button>>();
            all_list.Add("Network_1", new List<Button>());
            foreach (Button btn in network_1)
            {
                btn.Tag = new ButtonInfo() { Network = "Network_" + network_count.ToString()};

                all_list["Network_1"].Add(btn);
            }


        }


        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void ToolStripButton1_Click_1(object sender, EventArgs e) // no button
        {
            sec = "NO";
            textBox1.Text = sec;
            if (buton_checked)
            {
                using (noMenu menuu = new noMenu())
                if (menuu.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin);
                        addtoUsed(secili.AccessibleName);
                        secili.BackgroundImage = toolStripButton1.BackgroundImage;
                        secili.AccessibleDescription = "0";
                    }

            }
        }

        private void ToolStripButton2_Click_1(object sender, EventArgs e) // nc button
        {
            sec = "NC";
            textBox1.Text = sec;
            if (buton_checked)
            {
                using (ncMenu menuu = new ncMenu())
                    if (menuu.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin);
                        addtoUsed(secili.AccessibleName);
                        secili.BackgroundImage = toolStripButton2.BackgroundImage;
                        secili.AccessibleDescription = "1";
                    }
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Checker(sender);
        }

        private void Checker(object sender)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.White)
                {
                secili = btn;
                if (previous != null & previous != secili)
                { previous.BackColor = Color.White; previous.Image = null;}
                btn.BackColor = Color.Transparent;
                btn.Image = Properties.Resources.checks2;
                buton = btn.Name;
                textBox2.Text = buton;
                buton_checked = true;
                previous = secili;
                                
                }
            else if (buton_checked == true & btn.BackColor == Color.Transparent)
                {
                secili = null;
                btn.BackColor = Color.White;
                btn.Image = null;
                buton_checked = false;
                buton = null;
                textBox2.Text = null;
                }
        }

        private void ToolStripButton4_Click(object sender, EventArgs e) // network button
        {
            y = network_1[0].Location.Y + 150;
            network_count += 1;
            network_1.Clear();
            x_loc = 0;
            
            for (int i = 0; i<=8; i++)
            {
                if (i == 0) { Buton_yarat(0 + x_loc, y, Properties.Resources.net, 132, 44, false); yaratilan.AccessibleDescription = "11"; }
                else { Buton_yarat(0 + x_loc, y, Properties.Resources.link, 132, 44, false); yaratilan.AccessibleDescription = "10"; }
                network_1.Add(yaratilan);
                x_loc += 132;
            }
            
            //button_names = button_names.Substring(1);
            all_list.Add("Network_" + network_count.ToString(), new List<Button>());
            foreach (Button btn in network_1)
                all_list["Network_" + network_count.ToString()].Add(btn);



        }


        private void ToolStripButton3_Click(object sender, EventArgs e) // link button
        {
            if (buton_checked)
            {
                sec = "LINK";
                textBox1.Text = sec;

                deletefromUsed(secili.AccessibleName);
                if (secili.AccessibleName == "down")
                {
                    DeleteParallel(secili);
                }
                else
                {
                    secili.BackgroundImage = toolStripButton3.BackgroundImage;
                    secili.AccessibleDescription = "10";
                    secili.AccessibleName = null;
                }
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {

        }

        private void Button11_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton6_Click(object sender, EventArgs e) //down button
        {
            if (buton_checked)
            {
                var Data = (ButtonInfo)secili.Tag;
                
                if (buton_checked && (secili.AccessibleName != "down") && (!Data.Has_prl))
                {
                    //creating down button
                    int new_x = secili.Location.X - (132 / 7 * 2);
                    int new_y = secili.Location.Y + 23;
                    Buton_yarat(new_x, new_y, Properties.Resources.down_n, 56, 43, true);
                    yaratilan.AccessibleDescription = "99";
                    yaratilan.Tag = new ButtonInfo() { prl_to = secili };
                    prl_to = secili;

                    //creating link to down
                    new_x = yaratilan.Location.X + 39;
                    new_y = yaratilan.Location.Y + 20;
                    Buton_yarat(new_x, new_y, Properties.Resources.link, 132, 44, true);
                    yaratilan.AccessibleDescription = "10";

                    var data = (ButtonInfo)secili.Tag;
                    string network = data.Network;
                    prl_to.Tag = new ButtonInfo() { Network = network, Has_prl = true, prl_to = yaratilan };
                    //end

                    //creating up to link
                    new_x = yaratilan.Location.X + 114;
                    new_y = yaratilan.Location.Y - 20;
                    Buton_yarat(new_x, new_y, Properties.Resources.up, 56, 43, true);
                    yaratilan.AccessibleDescription = "98";
                    yaratilan.Tag = new ButtonInfo() { prl_to = secili };

                    //end

                }
            }
        }

        private void Button2_MouseEnter(object sender, EventArgs e) 
        {
            Button name = sender as Button;
            name.BringToFront();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e) // up button, can delete later
        {
            if (buton_checked & (secili.AccessibleName == "down"))
            {

                int new_x = secili.Location.X + 114;
                int new_y = secili.Location.Y - 20;
                Buton_yarat(new_x, new_y, Properties.Resources.up, 56, 43, true);

            }
        }

        private void Buton_yarat(int pos_x, int pos_y, Image img, int size_x, int size_y, bool down) 
        {
            Button name = new Button();
            panel1.Controls.Add(name);
            name.Location = new Point(pos_x, pos_y);
            name.BackgroundImage = img;
            name.Size = new Size(size_x, size_y);


            name.FlatStyle = FlatStyle.Flat;
            name.BackgroundImageLayout = ImageLayout.Zoom;
            name.TextImageRelation = TextImageRelation.Overlay;
            name.ForeColor = Color.Black;
            name.FlatAppearance.BorderSize = 0;
            name.MouseClick += Button2_Click;
            name.MouseEnter += Button2_MouseEnter;
            name.MouseLeave += Button2_MouseLeave;
            name.ImageAlign = ContentAlignment.MiddleCenter;
            name.BackColor = Color.White;
            //name.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            name.MaximumSize = new Size(size_x * 2, size_y * 2);
            if (down) { name.AccessibleName = "down"; }            
            name.BringToFront();
            name.Tag = new ButtonInfo() { Network = "Network_" + network_count.ToString() };
            name.Name = "button" + x.ToString();
            yaratilan = name;

            x++;
        }

        private void Button2_MouseLeave(object sender, EventArgs e) 
        {
            Button name = sender as Button;
            if (name.AccessibleName != "down")
            { name.SendToBack(); }
        }

        private void ToolStripButton7_Click(object sender, EventArgs e) // clock button
        {
            if (buton_checked)
            {
                secili.BackgroundImage = Properties.Resources.clock_n;

                using (Clock clock = new Clock())
                {
                    if (clock.ShowDialog() == DialogResult.OK)
                    {
                        if (clock.Type.Substring(0, 3) == "TON") //timeron
                        {
                            secili.AccessibleName = "TON" + clock.Timer;
                            addtoUsed(secili.AccessibleName);
                            secili.Text = "TON=" + clock.Interval;
                            secili.AccessibleDescription = "2";
                        }
                        else if (clock.Type.Substring(0, 4) == "TOFF") //timeroff
                        {
                            secili.AccessibleName = "TOFF" + clock.Timer;
                            addtoUsed(secili.AccessibleName);
                            secili.Text = "TOFF=" + clock.Interval;
                            secili.AccessibleDescription = "3";
                        }
                    }
                    else { secili.BackgroundImage = Properties.Resources.link; }
                }
            }
        }

        private void Button13_Click(object sender, EventArgs e)  //compile button
        {
            Used_Pins = Pre_Used_Pins.Distinct().ToList();
            if (secili != null)
            {
                Listings.Compile();
            }
            Debug.WriteLine("---------------------");
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)  // coil button
        {
            sec = "COIL";
            textBox1.Text = sec;
            if (buton_checked )
            {
                var Data = (ButtonInfo)secili.Tag;
                Button coil_btn = all_list[Data.Network][Data.Network.Length - 1];
                if (coil_btn == secili)
                {
                    using (coilMenu menuu = new coilMenu())
                        if (menuu.ShowDialog() == DialogResult.OK)
                        {
                            secili.AccessibleName = "O" + Convert.ToString(menuu.Pin);
                            addtoUsed(secili.AccessibleName);
                            secili.BackgroundImage = toolStripButton8.BackgroundImage;
                            secili.AccessibleDescription = "4";
                        }
                }
            }
        }

        private void addtoUsed(string foo)
        {
            Pre_Used_Pins.Add(foo);
            
        }
        private void deletefromUsed(string foo)
        {
            Pre_Used_Pins.Remove(foo);

        }
        private void DeleteParallel(Button foo)
        {
            if (foo.AccessibleName == "down" && (foo.AccessibleDescription =="99" || foo.AccessibleDescription =="98"))
            {
                Control foo1;
                Control foo2;
                Control foo3;
                Control fooToFix;
                int next;
                string foo_name;
                if (foo.AccessibleDescription == "99") // if clicked on down
                {
                    foo1 = this.Controls.Find(foo.Name, true).First() as Button; // down button foo1

                    next = Convert.ToInt32(foo1.Name.Substring(6));
                    next += 1;
                    foo_name = "button" + Convert.ToString(next);
                    foo2 = this.Controls.Find(foo_name, true).First() as Button;  // link button foo2

                    next += 1;
                    foo_name = "button" + Convert.ToString(next);
                    foo3 = this.Controls.Find(foo_name, true).First() as Button;  //up button foo3

                    foo1.Dispose();
                    this.Controls.Remove(foo1);
                    foo2.Dispose();
                    this.Controls.Remove(foo2);
                    foo3.Dispose();
                    this.Controls.Remove(foo3);
                }
                else if (foo.AccessibleDescription == "98") // if clicked on up
                {
                    foo1 = this.Controls.Find(foo.Name, true).First() as Button;  // up button foo1

                    next = Convert.ToInt32(foo1.Name.Substring(6));
                    next -= 1;
                    foo_name = "button" + Convert.ToString(next);
                    foo2 = this.Controls.Find(foo_name, true).First() as Button;  // link button foo2

                    next -= 1;
                    foo_name = "button" + Convert.ToString(next);
                    foo3 = this.Controls.Find(foo_name, true).First() as Button;  //down button foo3

                    foo1.Dispose();
                    this.Controls.Remove(foo1);
                    foo2.Dispose();
                    this.Controls.Remove(foo2);
                    foo3.Dispose();
                    this.Controls.Remove(foo3);
                }
                
                var which = (ButtonInfo)secili.Tag;
                fooToFix = which.prl_to;

                var Data = (ButtonInfo)fooToFix.Tag;
                Data.Has_prl = false;
                Data.prl_to = null;
                fooToFix.Tag = Data;

            }
        }

        private void Form1_KeyDown (object sender, KeyEventArgs e) //shortcuts
        {
                if (e.KeyCode == Keys.O) { ToolStripButton1_Click_1(sender, e); } // normally open
                else if (e.KeyCode == Keys.C) { ToolStripButton2_Click_1(sender, e); } // normally close
                else if (e.KeyCode == Keys.T) { ToolStripButton7_Click(sender, e); } // clock on
                else if (e.KeyCode == Keys.N) { ToolStripButton4_Click(sender, e); } // network
                else if (e.KeyCode == Keys.Y) { ToolStripButton8_Click(sender, e); } // coil
                else if (e.KeyCode == Keys.Delete) { ToolStripButton3_Click(sender, e); } // link
                else if (e.KeyCode == Keys.D) { ToolStripButton6_Click(sender, e); } // down
        }
    }
}
