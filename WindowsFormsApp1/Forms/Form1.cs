using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
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
        private string MainText = "PLC_.1";
        public static string path;
        string buton;
        private bool buton_checked = false;
        private List<Button> network_1;
        private Button yaratilan;
        private Button previous;
        private Button secili;
        private Button prl_to;
        public static int network_count = 1;
        int x = 10;
        int y = 150;
        int x_loc = 0;
        public static SortedDictionary<int, List<Button>> all_list;
        public static List<string> Pre_Used_Pins;
        public static List<string> Used_Pins;
        private StreamReader reader;

        public Form1()
        {
            InitializeComponent();
            Used_Pins = new List<string>();
            Pre_Used_Pins = new List<string>();
            Pre_Used_Pins.Add("I0");
            network_1 = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            all_list = new SortedDictionary<int, List<Button>>();
            all_list.Add(network_count, new List<Button>());
            foreach (Button btn in network_1)
            {
                btn.Tag = new ButtonInfo() { Network = "Network_" + network_count.ToString()};

                all_list[network_count].Add(btn);
            }
        }


        private void ToolStripButton4_Click(object sender, EventArgs e) // network button
                {
                    y = all_list[all_list.Keys.Last()][0].Location.Y + 150;
                    //y = network_1[0].Location.Y + 150;
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
                    all_list.Add(network_count, new List<Button>());
                    foreach (Button btn in network_1)
                        all_list[network_count].Add(btn);



                }
        private void ToolStripButton3_Click(object sender, EventArgs e) // link button
                {
                    if (buton_checked)
                    {
                        if(secili.AccessibleDescription == "11") { DeleteNetwork(secili); }
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
        private void ToolStripButton1_Click_1(object sender, EventArgs e) // no button
        {
            if (buton_checked)
            {
                deletefromUsed(secili.AccessibleName);
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
            if (buton_checked)
            {
                deletefromUsed(secili.AccessibleName);
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
        private void ToolStripButton7_Click(object sender, EventArgs e) // clock button
                {
                    if (buton_checked)
                    {
                        secili.BackgroundImage = Properties.Resources.clock_n;
                        deletefromUsed(secili.AccessibleName);
                        using (Clock clock = new Clock())
                        {
                            if (clock.ShowDialog() == DialogResult.OK)
                            {
                                if (clock.Type.Substring(0, 3) == "TON") //timeron
                                {
                                    secili.AccessibleName = "TON" + clock.Timer;
                                    addtoUsed(secili.AccessibleName);
                                    if (clock.Interval_Def == "K") { secili.Text = "TON=" + clock.Interval; }
                                    else {secili.Text = "TON=" + clock.Interval_Def + clock.Interval; }

                                    secili.AccessibleDescription = "2";
                                }
                                else if (clock.Type.Substring(0, 4) == "TOFF") //timeroff
                                {
                                    secili.AccessibleName = "TOFF" + clock.Timer;
                                    addtoUsed(secili.AccessibleName);
                                    if (clock.Interval_Def == "K") { secili.Text = "TOFF=" + clock.Interval; }
                                    else { secili.Text = "TOFF=" + clock.Interval_Def + clock.Interval; }
                                    secili.AccessibleDescription = "3";
                                }
                            }
                            else { secili.BackgroundImage = Properties.Resources.link; }
                        }
                    }
                }
        private void ToolStripButton8_Click(object sender, EventArgs e)  // coil button
                {
                    if (buton_checked )
                    {
                        var Data = (ButtonInfo)secili.Tag;
                        Button coil_btn = all_list[Convert.ToInt32(Data.Network.Split('_')[1])][Data.Network.Length - 1];
                        if (coil_btn == secili)
                        {
                            using (coilMenu menuu = new coilMenu())
                                if (menuu.ShowDialog() == DialogResult.OK)
                                {
                                    secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin);
                                    addtoUsed(secili.AccessibleName);
                                    secili.BackgroundImage = toolStripButton8.BackgroundImage;
                                    secili.AccessibleDescription = "4";
                                }
                        }
                    }
                }
        private void ToolStripButton9_Click(object sender, EventArgs e) // MOV button
                {
                    if (buton_checked)
                    {
                        secili.BackgroundImage = Properties.Resources.clock_n;
                        deletefromUsed(secili.AccessibleName);
                        using (MovMenu Mov = new MovMenu())
                        {
                            if (Mov.ShowDialog() == DialogResult.OK)
                            {
                                secili.AccessibleName = Mov.Type_From + Mov.Val_From + "=" + Mov.Type_To + Mov.Val_To;
                                addtoUsed(Mov.Type_To + Mov.Val_To);
                                secili.AccessibleDescription = "5";
                                secili.Text = "MOV," + Mov.Type_From + Mov.Val_From + "," + Mov.Type_To + Mov.Val_To;
                            }
                            else { secili.BackgroundImage = Properties.Resources.link; }
                        }
                    }
                }
        private void ToolStripButton10_Click(object sender, EventArgs e) // CNTR button
        {
            if (buton_checked)
            {
                secili.BackgroundImage = Properties.Resources.clock_n;
                deletefromUsed(secili.AccessibleName);
                using (CounterMenu counter = new CounterMenu())
                {
                    if (counter.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = "CNTR" + counter.Counter;
                        addtoUsed(secili.AccessibleName);
                        if(counter.Type == "CounterUp")
                        {
                            secili.AccessibleDescription = "6";
                            if(counter.Preset_Def == "K") { secili.Text = "CNTR" + counter.Counter + "_UP=" + counter.Preset; }
                            else if (counter.Preset_Def == "D") { secili.Text = "CNTR" + counter.Counter + "_UP=" + counter.Preset_Def + counter.Preset; }
                        }
                        else if (counter.Type == "CounterDown")
                        {
                            secili.AccessibleDescription = "7";
                            if (counter.Preset_Def == "K") { secili.Text = "CNTR" + counter.Counter + "_D=" + counter.Preset; }
                            else if (counter.Preset_Def == "D") { secili.Text = "CNTR" + counter.Counter + "_D=" + counter.Preset_Def + counter.Preset; }
                        }
                    }
                    else { secili.BackgroundImage = Properties.Resources.link; }
                }
            }
        }
        private void ToolStripButton11_Click(object sender, EventArgs e) // SET BUTTON
        {
            if (buton_checked)
            {
                deletefromUsed(secili.AccessibleName);
                var Data = (ButtonInfo)secili.Tag;
                Button coil_btn = all_list[Convert.ToInt32(Data.Network.Split('_')[1])][Data.Network.Length - 1];
                if (coil_btn == secili)
                {
                    using (SetMenu set = new SetMenu())
                        if (set.ShowDialog() == DialogResult.OK)
                        {
                            secili.AccessibleName = set.Type + Convert.ToString(set.Pin);
                            addtoUsed(secili.AccessibleName);
                            secili.Text = "SET= " + secili.AccessibleName;
                            secili.BackgroundImage = Properties.Resources.clock_n;
                            secili.AccessibleDescription = "8";
                        }
                        else { secili.BackgroundImage = Properties.Resources.link; }
                    
                }
            }
        } 
        private void ToolStripButton12_Click(object sender, EventArgs e) // RESET button
        {
            if (buton_checked)
            {
                deletefromUsed(secili.AccessibleName);
                var Data = (ButtonInfo)secili.Tag;
                Button coil_btn = all_list[Convert.ToInt32(Data.Network.Split('_')[1])][Data.Network.Length - 1];
                if (coil_btn == secili)
                {
                    using (ResetMenu reset = new ResetMenu())
                        if (reset.ShowDialog() == DialogResult.OK)
                        {
                            secili.AccessibleName = reset.Type + Convert.ToString(reset.Pin);
                            addtoUsed(secili.AccessibleName);
                            secili.Text = "RESET= " + secili.AccessibleName;
                            secili.BackgroundImage = Properties.Resources.clock_n;
                            secili.AccessibleDescription = "9";
                        }
                        else { secili.BackgroundImage = Properties.Resources.link; }

                }
            }
        }

        // -------------------- toolstrip buttons ----------------------------
        private void NewToolStripMenuItem_Click(object sender, EventArgs e) // new button-toolstrip
        {
            NewFile();
            Form Form_1 = Application.OpenForms["Form1"];
            Form_1.Text = MainText;
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // save button-toolstrip
        {
            SaveLoad.Save();
            Form Form_1 = Application.OpenForms["Form1"];
            Form_1.Text = MainText + " - " + path.Split('\\').Last();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) // open button-toolstrip
        {
            while (all_list.Keys.Count > 1) // deleting the drawing before load
            {
                int lastKey = all_list.Keys.Last();
                DeleteNetwork(all_list[lastKey][0]);
                foreach (Button x in all_list[1])
                {
                    if (x.Name != "button1")
                    {
                        var Data_1 = (ButtonInfo)x.Tag;
                        if (Data_1.Has_prl)
                        {
                            string Button_Name = Data_1.prl_to.Name;
                            Button_Name = Button_Name.Substring(0, 6) + Convert.ToString((Convert.ToInt32(Button_Name.Substring(6)) - 1));
                            Control prl_bt = panel1.Controls[Button_Name] as Button;
                            DeleteParallel(prl_bt as Button);
                            Data_1.Has_prl = false;
                            Data_1.prl_to = null;
                            x.Tag = Data_1;
                        }
                        x.BackgroundImage = toolStripButton3.BackgroundImage;
                        x.AccessibleDescription = "10";
                        x.AccessibleName = null;
                    }
                }
            }
            Load_Main(sender , e);
            Form Form_1 = Application.OpenForms["Form1"];
            Form_1.Text = MainText + " - " + path.Split('\\').Last();
            PopulateTreeView();
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
                { previous.BackColor = Color.White; previous.Image = null; }
                btn.BackColor = Color.Transparent;
                btn.Image = Properties.Resources.checks2;
                buton = btn.Name;
                textBox2.Text = buton;
                buton_checked = true;
                previous = secili;
                var foo = (ButtonInfo)secili.Tag;
                textBox3.Text = secili.AccessibleDescription;
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

        private void Button2_MouseEnter(object sender, EventArgs e) 
        {
            Button name = sender as Button;
            name.BringToFront();
        }

        private void Button2_MouseLeave(object sender, EventArgs e) 
        {
            Button name = sender as Button;
            if (name.AccessibleName != "down")
            { name.SendToBack(); }
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


        private void Button13_Click(object sender, EventArgs e)  //compile button
        {
            Pre_Used_Pins.RemoveAt(0);
            Used_Pins = Pre_Used_Pins.Distinct().ToList();
            if (secili != null)
            {
                
                Listings.Compile();               
                foreach(int x in all_list.Keys)
                {
                    Debug.WriteLine(x);
                }
                Debug.WriteLine(network_count);
            }
            Debug.WriteLine("---------------------");
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
                if (fooToFix != null)
                {
                    var Data = (ButtonInfo)fooToFix.Tag;
                    Data.Has_prl = false;
                    Data.prl_to = null;
                    fooToFix.Tag = Data;
                }
            }
        }

        private void DeleteNetwork(Button foo)
        {
            Debug.WriteLine(all_list.Count);
            bool checking;
            var FirstData = (ButtonInfo)foo.Tag;
            int newKey = Convert.ToInt32(FirstData.Network.Split('_')[1]);
            List<Button> Net_Buttons = all_list[newKey];
            foreach (Button x in Net_Buttons)
            {
                var Data_1 = (ButtonInfo)x.Tag;
                if (Data_1.Has_prl)
                {
                    string Button_Name = Data_1.prl_to.Name;                   
                    Button_Name = Button_Name.Substring(0, 6) + Convert.ToString((Convert.ToInt32(Button_Name.Substring(6)) - 1));
                    Control prl_bt = this.Controls.Find(Button_Name, true).First() as Button;
                    DeleteParallel(prl_bt as Button);
                }
            }
            foreach (Control x in Net_Buttons)
            {
                Button x_bt = x as Button;
                deletefromUsed(x_bt.AccessibleName);

                x.Dispose();
                this.Controls.Remove(x);
            }
            if (newKey != all_list.Keys.Last()) {checking = true; }
            else {checking = false; }
            all_list.Remove(newKey);

            if (checking)
            {
                for (int x = newKey + 1; x<= all_list.Keys.Last(); x++)
                {
                    List<Button> disposable = all_list[x];
                    foreach(Button dispBtn in disposable)
                    {
                        var disData = (ButtonInfo)dispBtn.Tag;
                        disData.Network = "Network_" + Convert.ToString(x - 1);
                        dispBtn.Tag = disData;
                        dispBtn.Location = new Point(dispBtn.Location.X, dispBtn.Location.Y - 150);
                    }
                    all_list.Remove(x);
                    all_list.Add(x - 1, disposable);

                }
            }
            network_count -= 1;
        }
        
        private void Load_Main(object sender, EventArgs e)
        {
            
            SaveLoad.Pre_Load();
            int cnt = network_count;
            network_count = 1;
            for (int i = 1; i< cnt ; i++)
            {
                ToolStripButton4_Click(sender, e);
            }
            Load(sender, e);
            foreach(int x in all_list.Keys)
            {
                Debug.WriteLine("");
                foreach(Button btn in all_list[x])
                {
                    Debug.Write(btn.Name);
                }
            }
        }

        private void Load(object sender, EventArgs e)
        {
            path = SaveLoad.Init_Load();
            if (path == "x") { return; }
            reader = new StreamReader(path);

            int number = Convert.ToInt32(yaratilan.Name.Substring(6)) + 2;
            int foo = Convert.ToInt32(reader.ReadLine());
            reader.ReadLine();
            for (int i = 1; i <= foo; i++)
            {
                foreach (Button btn in all_list[i])
                {
                    ButtonInfo Data = (ButtonInfo)btn.Tag;
                    btn.AccessibleDescription = reader.ReadLine();
                    btn.AccessibleName = reader.ReadLine();
                    btn.Text = reader.ReadLine();
                    string bar = reader.ReadLine();

                    if (bar == "True")
                    {
                        string new_name = "button" + number;
                        secili = btn;
                        buton_checked = true;
                        ToolStripButton6_Click(sender, e);
                        
                        Button prl = this.Controls.Find(new_name, true).First() as Button;
                        prl.AccessibleDescription = reader.ReadLine();
                        prl.AccessibleName = reader.ReadLine();
                        prl.Text = reader.ReadLine();
                        
                        ImageLoad(prl);
                        number += 3;
                    }
                    else if (bar == "False") { Data.Has_prl = false; btn.Tag = Data; }
                    
                    ImageLoad(btn);
                }
            }
            buton_checked = false;
            reader.Close();

        }

        private void ImageLoad(Button foo)
        {
            switch (foo.AccessibleDescription)
            {
                case "0":
                    foo.BackgroundImage = Properties.Resources.NO;
                    break;
                case "1":
                    foo.BackgroundImage = Properties.Resources.NC;
                    break;
                case "2":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "3":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "4":
                    foo.BackgroundImage = Properties.Resources.coil;
                    break;
                case "5":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "6":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "7":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "8":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "9":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                default:
                    break;
            }

        }

        private void NewFile()
        {
            DialogResult result = MessageBox.Show("Are you SURE?!!!", "Title", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                while (all_list.Keys.Count > 1)
                {
                    int lastKey = all_list.Keys.Last();
                    DeleteNetwork(all_list[lastKey][0]);
                }
                foreach (Button x in all_list[1])
                {
                    if (x.Name != "button1")
                    {
                        var Data_1 = (ButtonInfo)x.Tag;
                        if (Data_1.Has_prl)
                        {
                            string Button_Name = Data_1.prl_to.Name;
                            Button_Name = Button_Name.Substring(0, 6) + Convert.ToString((Convert.ToInt32(Button_Name.Substring(6)) - 1));
                            Control prl_bt = panel1.Controls[Button_Name] as Button;
                            DeleteParallel(prl_bt as Button);
                            Data_1.Has_prl = false;
                            Data_1.prl_to = null;
                            x.Tag = Data_1;
                        }
                        x.BackgroundImage = toolStripButton3.BackgroundImage;
                        x.AccessibleDescription = "10";
                        x.AccessibleName = null;
                    }
                }
            }
            else { return; }
        }

        private void PopulateTreeView()
        {
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


        private void Form1_KeyDown (object sender, KeyEventArgs e) //shortcuts
                {
                        if (e.KeyCode == Keys.O) { ToolStripButton1_Click_1(sender, e); } // normally open
                        else if (e.KeyCode == Keys.K) { ToolStripButton2_Click_1(sender, e); } // normally close
                        else if (e.KeyCode == Keys.T) { ToolStripButton7_Click(sender, e); } // clock on
                        else if (e.KeyCode == Keys.N) { ToolStripButton4_Click(sender, e); } // network
                        else if (e.KeyCode == Keys.Y) { ToolStripButton8_Click(sender, e); } // coil
                        else if (e.KeyCode == Keys.Delete) { ToolStripButton3_Click(sender, e); } // link
                        else if (e.KeyCode == Keys.D) { ToolStripButton6_Click(sender, e); } // down
                        else if (e.KeyCode == Keys.M) { ToolStripButton9_Click(sender, e); } // mov
                        else if (e.KeyCode == Keys.C) { ToolStripButton10_Click(sender, e); } // COUNTER     
        }
    }
}
