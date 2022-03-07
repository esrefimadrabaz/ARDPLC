using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public delegate void SimulationUpdate(NewButton newButton);
        public SimulationUpdate mySimulationUpdate;
        private SimulationA sim;
        public static bool SimMode;

        private bool buton_checked = false;
        private bool MadeChange;
        private bool ISR;

        private string MainText = "PLC_.1";
        public static string path;
        string buton;
        
        private List<NewButton> network_1;
        private NewButton yaratilan;
        private NewButton previous;
        private NewButton secili;
        private NewButton prl_to;

        public static int network_count = 1;
        int x = 10;
        int y = 150;
        int x_loc = 0;

        public static SortedDictionary<int, List<NewButton>> all_list;
        public static List<string> Pre_Used_Pins;
        public static List<string> Used_Pins;
        

        public Form1()
        {
            InitializeComponent();
            Used_Pins = new List<string>();
            Pre_Used_Pins = new List<string>();

            network_1 = new List<NewButton> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            all_list = new SortedDictionary<int, List<NewButton>>();
            all_list.Add(network_count, new List<NewButton>());
            foreach (NewButton btn in network_1)
            {
                btn.Network = "Network_" + network_count;
                all_list[network_count].Add(btn);
            }
            mySimulationUpdate = new SimulationUpdate(delgtSimulationUpdate);
        }



        private void NetworkButton_Click(object sender, EventArgs e) // network button
        {
            y = all_list[all_list.Keys.Last()][0].Location.Y + 150;
            //y = network_1[0].Location.Y + 150;
            network_count += 1;
            network_1.Clear();
            x_loc = 0;

            for (int i = 0; i <= 8; i++)
            {
                if (i == 0) { Buton_yarat(0 + x_loc, y, Properties.Resources.net, 132, 44, false); yaratilan.AccessibleDescription = "11"; }
                else { Buton_yarat(0 + x_loc, y, Properties.Resources.link, 132, 44, false); yaratilan.AccessibleDescription = "10"; }
                network_1.Add(yaratilan);
                x_loc += 132;
            }

            //button_names = button_names.Substring(1);
            all_list.Add(network_count, new List<NewButton>());
            foreach (NewButton btn in network_1)
            {
                all_list[network_count].Add(btn);
            }
        }
        private void LinkButton_Click(object sender, EventArgs e) // link button
        {
            if (!buton_checked) { return; }

            if (secili.AccessibleDescription == "11") { DeleteNetwork(secili); }
            deletefromUsed(secili.AccessibleName);
            if (secili.AccessibleName == "down")
            {
                DeleteParallel(secili);
            }
            else if (secili.AccessibleDescription == "10")
            {
                if(secili.Parallels != null) { DeleteParallel(secili.Parallels[0]); }
            }
            else
            {
                secili.Text = null;
                secili.BackgroundImage = toolStripButton3.BackgroundImage;
                secili.AccessibleDescription = "10";
                secili.AccessibleName = null;
            }

        }
        private void NOButton_Click(object sender, EventArgs e) // no button
        {
            if (!buton_checked) { return; }

            deletefromUsed(secili.AccessibleName);
            using (noMenu menuu = new noMenu())
                if (menuu.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin); // I-M-O-CNTR + PİN
                    secili.Text = secili.AccessibleName;
                    addtoUsed(secili.AccessibleName);
                    secili.BackgroundImage = toolStripButton1.BackgroundImage;
                    secili.AccessibleDescription = "0";
                }


        }
        private void NCButton_Click(object sender, EventArgs e) // nc button
        {
            if (!buton_checked) { return; }

            deletefromUsed(secili.AccessibleName);
            using (ncMenu menuu = new ncMenu())
                if (menuu.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin); // I-M-O-CNTR + PİN
                    secili.Text = secili.AccessibleName;
                    addtoUsed(secili.AccessibleName);
                    secili.BackgroundImage = toolStripButton2.BackgroundImage;
                    secili.AccessibleDescription = "1";
                }

        }
        private void DownButton_Click(object sender, EventArgs e) //down button
        {
            if (!buton_checked) { return; }
            if (secili.AccessibleDescription == "18") { return; } 
            if (buton_checked && (secili.AccessibleName != "down") && (!secili.HasPrl))
            {
                //creating down button
                int new_x = secili.Location.X - 2;
                int new_y = secili.Location.Y + 23;
                Buton_yarat(new_x, new_y, Properties.Resources.down_final, 4, 43, true);
                yaratilan.AccessibleDescription = "99";
                NewButton dispButton = yaratilan;
                yaratilan.PrlTo = secili;
                prl_to = secili;

                //creating link to down
                new_x = yaratilan.Location.X + 3;
                new_y = yaratilan.Location.Y + 20;
                Buton_yarat(new_x, new_y, Properties.Resources.link, 132, 44, true);
                yaratilan.AccessibleDescription = "10";

                yaratilan.Parallels = new NewButton[2];
                yaratilan.Parallels[0] = dispButton;

                prl_to.Network = secili.Network;
                prl_to.HasPrl = true;
                prl_to.PrlTo = yaratilan;
                //end

                //creating up to link
                new_x = yaratilan.Location.X + 132;
                new_y = yaratilan.Location.Y - 20;
                Buton_yarat(new_x, new_y, Properties.Resources.down_final, 4, 43, true);
                yaratilan.AccessibleDescription = "98";
                yaratilan.PrlTo = secili;

                secili.PrlTo.Parallels[1] = yaratilan;
                //end
            }

        }
        private void ClockButton_Click(object sender, EventArgs e) // clock button
        {
            if (!buton_checked) { return; }

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
                        else { secili.Text = "TON=" + clock.Interval_Def + clock.Interval; }

                        secili.AccessibleDescription = "2";
                    }
                    else if (clock.Type == "TRO") //timer retentive
                    {
                        secili.AccessibleName = "TRO" + clock.Timer;
                        addtoUsed(secili.AccessibleName);
                        if (clock.Interval_Def == "K") { secili.Text = "TRO=" + clock.Interval; }
                        else { secili.Text = "TRO=" + clock.Interval_Def + clock.Interval; }
                        secili.AccessibleDescription = "13";
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
        private void CoilButton_Click(object sender, EventArgs e)  // coil button
        {
            if (!buton_checked) { return; }

            NewButton Coil_btn = all_list[Convert.ToInt32(secili.Network.Split('_')[1])][secili.Network.Length - 1];

            if (Coil_btn == secili)
            {
                using (coilMenu menuu = new coilMenu())
                    if (menuu.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = menuu.Type + Convert.ToString(menuu.Pin);
                        secili.Text = secili.AccessibleName;
                        addtoUsed(secili.AccessibleName); // O-M + PİN
                        secili.BackgroundImage = toolStripButton8.BackgroundImage;
                        secili.AccessibleDescription = "4";
                    }
            }

        }
        private void MOVButton_Click(object sender, EventArgs e) // MOV button
        {
            if (!buton_checked) { return; }
            secili.BackgroundImage = Properties.Resources.clock_n;
            deletefromUsed(secili.AccessibleName);
            using (MovMenu Mov = new MovMenu())
            {
                if (Mov.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = Mov.Type_From + Mov.Val_From + "=" + Mov.Type_To + Mov.Val_To;
                    secili.AccessibleDescription = "5";
                    secili.Text = "MOV," + Mov.Type_From + Mov.Val_From + "," + Mov.Type_To + Mov.Type_From + Mov.Val_To;
                    if (Mov.Type_From == Mov.Type_To) // if moving from Data to Data
                    {
                        foreach (string pin in Pre_Used_Pins.ToList())
                        {
                            string dispString = Mov.Type_From[0] + Convert.ToString(Mov.Val_From);
                            if (dispString == pin[0] + pin.Substring(2))
                            {
                                addtoUsed(Mov.Type_To + pin[1] + Mov.Val_To); // D + TYPE + NMBR
                            }
                        }
                    }
                    else { addtoUsed(Mov.Type_To + Mov.Type_From[0] + Mov.Val_To); } // D + TYPE + NMBR

                }
                else { secili.BackgroundImage = Properties.Resources.link; }
            }

        }
        private void CNTRButton_Click(object sender, EventArgs e) // CNTR button
        {
            if (!buton_checked) { return; }

            secili.BackgroundImage = Properties.Resources.clock_n;
            deletefromUsed(secili.AccessibleName);
            using (CounterMenu counter = new CounterMenu())
            {
                if (counter.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = "CNTR" + counter.Counter;
                    addtoUsed(secili.AccessibleName);
                    if (counter.Type == "CounterUp")
                    {
                        secili.AccessibleDescription = "6";
                        if (counter.Preset_Def == "K") { secili.Text = "CNTR" + counter.Counter + "_UP=" + counter.Preset; }
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
        private void SETButton_Click(object sender, EventArgs e) // SET BUTTON
        {
            if (!buton_checked) { return; }

            deletefromUsed(secili.AccessibleName);
            NewButton Coil_btn = all_list[Convert.ToInt32(secili.Network.Split('_')[1])][secili.Network.Length - 1];
            if (Coil_btn == secili)
            {
                using (SetMenu set = new SetMenu())
                    if (set.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = set.Type + Convert.ToString(set.Pin);
                        addtoUsed(secili.AccessibleName); // O-M + PİN
                        secili.Text = "SET= " + secili.AccessibleName;
                        secili.BackgroundImage = Properties.Resources.clock_n;
                        secili.AccessibleDescription = "8";
                    }
                    else { secili.BackgroundImage = Properties.Resources.link; }

            }

        }
        private void RESETButton_Click(object sender, EventArgs e) // RESET button
        {
            if (!buton_checked) { return; }

            deletefromUsed(secili.AccessibleName);
            NewButton Coil_btn = all_list[Convert.ToInt32(secili.Network.Split('_')[1])][secili.Network.Length - 1];
            if (Coil_btn == secili)
            {
                using (ResetMenu reset = new ResetMenu())
                    if (reset.ShowDialog() == DialogResult.OK)
                    {
                        secili.AccessibleName = reset.Type + Convert.ToString(reset.Pin);
                        addtoUsed(secili.AccessibleName); // O - M + PİN 
                        secili.Text = "RESET= " + secili.AccessibleName;
                        secili.BackgroundImage = Properties.Resources.clock_n;
                        secili.AccessibleDescription = "9";
                    }
                    else { secili.BackgroundImage = Properties.Resources.link; }
            }
        }
        private void ARITHButton_Click(object sender, EventArgs e) //ARITHMETIC button
        {
            if (!buton_checked) { return; }

            deletefromUsed(secili.AccessibleName);
            secili.BackgroundImage = Properties.Resources.clock_n;
            using (ArithmeticMenu Arithmetic = new ArithmeticMenu())
            {
                if (Arithmetic.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = Arithmetic.PreDef + Convert.ToString(Arithmetic.PreValue)
                        + Arithmetic.Operation + Arithmetic.PostDef + Convert.ToString(Arithmetic.PostValue)
                        + "=D" + Arithmetic.ResultValue;

                    if (Arithmetic.Operation == "|")
                    {
                        secili.Text = Arithmetic.PreDef + Convert.ToString(Arithmetic.PreValue)
                        + "-" + Arithmetic.PostDef + Convert.ToString(Arithmetic.PostValue)
                        + "=D" + Arithmetic.ResultValue;
                    }
                    else { secili.Text = secili.AccessibleName; }
                    secili.AccessibleDescription = "12";

                    if (Arithmetic.PostDef == "D")
                    {
                        string dispName = "D" + Convert.ToString(Arithmetic.PostValue);
                        foreach (string pin in Pre_Used_Pins.ToList())
                        {
                            if (pin[0] + pin.Substring(2) == dispName)
                            {
                                addtoUsed("D" + pin[1] + Convert.ToString(Arithmetic.ResultValue));
                            }
                        }
                    }
                    if (Arithmetic.PreDef == "D")
                    {
                        string dispName = "D" + Convert.ToString(Arithmetic.PreValue);
                        foreach (string pin in Pre_Used_Pins.ToList())
                        {
                            if (pin[0] + pin.Substring(2) == dispName) { addtoUsed("D" + pin[1] + Convert.ToString(Arithmetic.ResultValue)); }
                        }
                    }
                    else { addtoUsed("D" + Arithmetic.PostDef + Convert.ToString(Arithmetic.ResultValue)); }


                }
                else { secili.BackgroundImage = Properties.Resources.link; }
            }
        }
        private void CMPButton_Click(object sender, EventArgs e) // CMP button
        {
            if (!buton_checked) { return; }

            secili.BackgroundImage = Properties.Resources.clock_n;
            deletefromUsed(secili.AccessibleName);
            using (CMPMenu CMP = new CMPMenu())
            {
                if (CMP.ShowDialog() == DialogResult.OK)
                {
                    if (CMP.Type == "CMP")
                    {
                        secili.AccessibleName = (CMP.Type + "|" + CMP.First + Convert.ToString(CMP.FirstValue)
                            + "|" + CMP.Last + Convert.ToString(CMP.LastValue) + "|" + "M" + Convert.ToString(CMP.ResultValue));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue + 1));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue + 2));
                        secili.Text = CMP.Type + "|M" + Convert.ToString(CMP.ResultValue);
                        secili.AccessibleDescription = "14";

                    }
                    else
                    {
                        secili.AccessibleName = (CMP.Type + "|" + CMP.First + Convert.ToString(CMP.FirstValue)
                         + "|" + CMP.Middle + Convert.ToString(CMP.MiddleValue) + CMP.Last + Convert.ToString(CMP.LastValue)
                         + "|" + "M" + Convert.ToString(CMP.ResultValue));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue + 1));
                        addtoUsed("M" + Convert.ToString(CMP.ResultValue + 2));
                        secili.Text = CMP.Type + "|M" + Convert.ToString(CMP.ResultValue);
                        secili.AccessibleDescription = "15";
                    }

                }
                else { secili.BackgroundImage = Properties.Resources.link; }

            }

        }
        private void ADCButton_Click(object sender, EventArgs e) // ADC Button
        {
            if (!buton_checked) { return; }

            secili.BackgroundImage = Properties.Resources.clock_n;
            deletefromUsed(secili.AccessibleName);

            using (ADCMenu ADC = new ADCMenu())
            {
                if (ADC.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleName = "ADC-A" + ADC.Pin + "-D" + ADC.Destination;
                    secili.Text = secili.AccessibleName;
                    secili.AccessibleDescription = "16";
                    addtoUsed("DK" + ADC.Destination);
                    addtoUsed("A" + ADC.Pin);
                }
                else { secili.BackgroundImage = Properties.Resources.link; }
            }

        }
        private void PWMButton_Click(object sender, EventArgs e) // PWM Button
        {
            if (!buton_checked) { return; }
            secili.BackgroundImage = Properties.Resources.clock_n;
            deletefromUsed(secili.AccessibleName);

            using (PWMMenu PWM = new PWMMenu())
            {
                if (PWM.ShowDialog() == DialogResult.OK)
                {
                    secili.AccessibleDescription = "17";
                    secili.AccessibleName = "PWM-" + PWM.ValueType + PWM.Value + "-O" + PWM.Pin;
                    secili.Text = secili.AccessibleName;
                    addtoUsed(("O" + PWM.Pin));
                }
                else
                {
                    secili.BackgroundImage = Properties.Resources.link;
                }
            }
        }
        private void ISRButton_Click(object sender, EventArgs e)// ISR Button
        {
            if (!buton_checked) { return; }
            int tempNet = Convert.ToInt32(secili.Network.Split('_')[1]);
            if ((all_list[tempNet][1] == secili) && ISR == false)
            {
                using (EXTIMenu EXTI = new EXTIMenu())
                {
                    if(EXTI.ShowDialog() == DialogResult.OK)
                    {
                        secili.BackgroundImage = Properties.Resources.clock_n;
                        secili.AccessibleDescription = "18";
                        deletefromUsed(secili.AccessibleName);
                        ISR = true;
                        secili.Text = "EXTI-" + EXTI.Pin + "-" + EXTI.Mode;
                        secili.AccessibleName = "EXTI" + EXTI.Pin;
                        addtoUsed("I" + EXTI.Pin);
                        addtoUsed("EXTI" + EXTI.Pin + EXTI.Mode[0]);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if ((all_list[tempNet].Last() == secili) && ISR == true)
            {
                secili.BackgroundImage = Properties.Resources.clock_n;
                secili.AccessibleDescription = "18";
                deletefromUsed(secili.AccessibleName);
                ISR = false;
                secili.Text = "EXTI END";
            }
        } 
        private void STFEditClick(object sender, EventArgs e) // Editor Edit Click
        {
            if (!buton_checked) { return; }
            using (STEditor Editor = new STEditor())
            {
                string fName = secili.Text.Substring(4, secili.Text.Length - 4);
                Editor.First = fName;
                string localName = this.Text.Substring(9, this.Text.Length - 9);
                string LocalPath = MadeChange ?
                    path.Substring(0, path.Length - localName.Length + 1)
                    : path.Substring(0, path.Length - localName.Length);

                if(File.Exists(LocalPath + "STF_" + fName + ".st"))
                {
                    using (StreamReader STFReader = new StreamReader(LocalPath + "STF_" + fName + ".st"))
                    {
                        string Lines = STFReader.ReadToEnd();
                        Editor.FText = Lines;
                    }
                }
                if (Editor.ShowDialog() == DialogResult.OK)
                {
                    File.Create(LocalPath + "STF_" + fName + ".st").Dispose();

                    using (StreamWriter STFWriter = new StreamWriter(LocalPath + "STF_" + fName + ".st"))
                    {
                        STFWriter.WriteLine(Editor.FText);
                        STFWriter.Close();
                    }
                }
            }
        }
        private void STFButton_Click(object sender, EventArgs e) // Editor Button 
        {
            if (!buton_checked) { return; }
            if (path == null) { MessageBox.Show("Need to initialize a working directory before STF use.", "Path Error", MessageBoxButtons.OK); return; }
            using (STEditorInit EditorInit = new STEditorInit())
            {
                if (EditorInit.ShowDialog() == DialogResult.OK)
                {
                    deletefromUsed(secili.AccessibleName);
                    secili.BackgroundImage = Properties.Resources.clock_n;
                    secili.AccessibleDescription = "19";
                    secili.Text = "STF_" + EditorInit.FName;
                    secili.AccessibleName = secili.Text;
                    addtoUsed(secili.AccessibleName);
                    secili.ContextMenuStrip = STEditStrip;
                }
            }
        }

        // -------------------- toolstrip buttons ----------------------------
        private void NewToolStripMenuItem_Click(object sender, EventArgs e) // new button-toolstrip
        {
            NewFile();
            this.Text = MainText;
            MadeChange = false;
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) // save button-toolstrip
        {
            path = SaveLoad.path;
            SaveLoad.Save();
            Form Form_1 = Application.OpenForms["Form1"];
            Form_1.Text = MainText + " - " + path.Split('\\').Last();
            MadeChange = false;
            leftPanel1.PopulateTreeViewDirectories();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) // open button-toolstrip
        {
            if (MadeChange)
            {
                DialogResult result = MessageBox.Show("Save changes before closing?", "Save Changes", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    path = SaveLoad.path;
                    SaveLoad.Save();
                    this.Text = MainText + " - " + path.Split('\\').Last();
                    MadeChange = false;
                }
            }

            while (all_list.Keys.Count > 1) // deleting the drawing before load
            {
                int lastKey = all_list.Keys.Last();
                DeleteNetwork(all_list[lastKey][0]);
                foreach (NewButton x in all_list[1])
                {
                    if (x.Name != "button1")
                    {
                        if (x.HasPrl)
                        {
                            string Button_Name = x.PrlTo.Name;
                            Button_Name = Button_Name.Substring(0, 6) + Convert.ToString((Convert.ToInt32(Button_Name.Substring(6)) - 1));
                            Control prl_bt = panel1.Controls[Button_Name] as NewButton;
                            DeleteParallel(prl_bt as NewButton);
                            x.HasPrl = false;
                            x.PrlTo = null;
                        }
                        x.BackgroundImage = toolStripButton3.BackgroundImage;
                        x.AccessibleDescription = "10";
                        x.AccessibleName = null;
                    }
                }
            }
            Load_Main(sender, e);
            Form Form_1 = Application.OpenForms["Form1"];
            Form_1.Text = MainText + " - " + path.Split('\\').Last();
            leftPanel1.PopulateTreeViewDirectories();

        }
        private void CompileButton_Click(object sender, EventArgs e)  //compile button-toolstrip
        {

            if (path == null || MadeChange == true)
            {
                DialogResult result = MessageBox.Show("Saving is mandatory before compiling.", "Warning!", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                path = SaveLoad.path;
                SaveLoad.Save();
                Form Form_1 = Application.OpenForms["Form1"];
                Form_1.Text = MainText + " - " + path.Split('\\').Last();
            }

            Used_Pins = Pre_Used_Pins.Distinct().ToList();
            Listings listings = new Listings();
            listings.Compile();
        }
        private void SimButton_Click(object sender, EventArgs e)
        {
            if (buton_checked) { return; }
            DialogResult result = MessageBox.Show("Simulation mode only works with integers.", "Warning", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else if (result == DialogResult.OK)
            {
                SimMode = true;
                Debug.WriteLine("=====Enter simulation mode.=====");
                foreach (int key in all_list.Keys)
                {
                    foreach (NewButton tempButton in all_list[key])
                    {
                        try
                        {
                            if (tempButton.AccessibleName is null) { continue; }
                            if (tempButton.AccessibleName[0] == 'I')
                            {
                                tempButton.ContextMenuStrip = contextMenuStrip1;
                            }
                            
                        }
                        catch { continue; }
                    }
                } //add right click menu to Input buttons

                sim = new SimulationA();
                sim.SimulationStart(this);
            }
        } //simulation button


        private void Buton_yarat(int pos_x, int pos_y, Image img, int size_x, int size_y, bool down)
        {
            NewButton name = new NewButton();
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
            name.BackgroundImageChanged += ChangesMadeEvent;
            name.ImageAlign = ContentAlignment.MiddleCenter;
            name.BackColor = Color.White;
            name.Margin = new Padding(all: 0);
            //name.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            name.MaximumSize = new Size(size_x * 2, size_y * 2);
            if (down) { name.AccessibleName = "down"; }
            name.BringToFront();
            name.Network = "Network_" + network_count;
            name.Name = "button" + x.ToString();
            yaratilan = name;

            x++;
        }
        private void addtoUsed(string foo)
        {

            if (foo[0] == 'D')
            {
                foreach (string temp in Pre_Used_Pins)
                {
                    if ((temp[0] + temp.Substring(2) == foo[0] + foo.Substring(2)) && (temp[1] != foo[1]))
                    {
                        MessageBox.Show("This adress is already declared.", "Error", MessageBoxButtons.OK);

                        secili.AccessibleName = null;
                        LinkButton_Click(new object(), new EventArgs());
                        return;
                    }
                }
            }
            Pre_Used_Pins.Add(foo);
        }
        private void deletefromUsed(string foo)
        {
            if (foo == null) return;
            if (foo.StartsWith("STF"))
            {
                secili.ContextMenuStrip = null;
            }
            foreach (string tmp in Pre_Used_Pins)
            {
                if (tmp[0] == 'D')
                {
                    if (foo.Contains(tmp[0] + tmp.Substring(2)))
                    {
                        Pre_Used_Pins.Remove(tmp);
                        return;
                    }
                }
                else if (foo.Contains(tmp))
                {
                    if(foo[0] == 'E')
                    {
                        Pre_Used_Pins.Remove(foo);
                    }
                    Pre_Used_Pins.Remove(tmp);
                    return;
                }

            }


        }
        private void DeleteParallel(NewButton foo)
        {
            if (foo.AccessibleName == "down" && (foo.AccessibleDescription == "99" || foo.AccessibleDescription == "98"))
            {
                NewButton foo1;
                NewButton foo2;
                NewButton foo3;
                NewButton fooToFix;
                int next;
                string foo_name;
                if (foo.AccessibleDescription == "99") // if clicked on down
                {

                    foo1 = foo.PrlTo.PrlTo.Parallels[0];
                    foo2 = foo.PrlTo.PrlTo.Parallels[1];
                    foo3 = foo.PrlTo.PrlTo;

                    foo1.Dispose();
                    this.Controls.Remove(foo1);
                    foo2.Dispose();
                    this.Controls.Remove(foo2);
                    foo3.Dispose();
                    this.Controls.Remove(foo3);
                }
                else if (foo.AccessibleDescription == "98") // if clicked on up
                {
                    foo1 = foo.PrlTo.PrlTo.Parallels[0];
                    foo2 = foo.PrlTo.PrlTo.Parallels[1];
                    foo3 = foo.PrlTo.PrlTo;

                    foo1.Dispose();
                    this.Controls.Remove(foo1);
                    foo2.Dispose();
                    this.Controls.Remove(foo2);
                    foo3.Dispose();
                    this.Controls.Remove(foo3);
                }

                fooToFix = secili.PrlTo;
                if (fooToFix != null)
                {
                    fooToFix.HasPrl = false;
                    fooToFix.PrlTo = null;
                }
            }
        }
        private void DeleteNetwork(NewButton foo)
        {
            bool checking;
            int newKey = Convert.ToInt32(foo.Network.Split('_')[1]);
            List<NewButton> Net_Buttons = all_list[newKey];
            foreach (NewButton x in Net_Buttons)
            {
                if (x.HasPrl)
                {
                    DeleteParallel(x.PrlTo.Parallels[0]);
                }
            }
            foreach (Control x in Net_Buttons)
            {
                Button x_bt = x as Button;
                deletefromUsed(x_bt.AccessibleName);

                x.Dispose();
                this.Controls.Remove(x);
            }
            if (newKey != all_list.Keys.Last()) { checking = true; }
            else { checking = false; }
            all_list.Remove(newKey);

            if (checking)
            {
                for (int x = newKey + 1; x <= all_list.Keys.Last(); x++)
                {
                    List<NewButton> disposable = all_list[x];
                    foreach (NewButton dispBtn in disposable)
                    {
                        dispBtn.Network = "Network_" + Convert.ToString(x - 1);
                        dispBtn.Location = new Point(dispBtn.Location.X, dispBtn.Location.Y - 150);
                        if (dispBtn.HasPrl)
                        {
                            dispBtn.PrlTo.Location = new Point(dispBtn.PrlTo.Location.X, dispBtn.PrlTo.Location.Y - 150);

                            dispBtn.PrlTo.Parallels[0].Location = new Point(dispBtn.PrlTo.Parallels[0].Location.X, dispBtn.PrlTo.Parallels[0].Location.Y - 150);

                            dispBtn.PrlTo.Parallels[1].Location = new Point(dispBtn.PrlTo.Parallels[1].Location.X, dispBtn.PrlTo.Parallels[1].Location.Y - 150);
                        }

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
            for (int i = 1; i < cnt; i++)
            {
                NetworkButton_Click(sender, e);
            }
            Load(sender, e);
        }
        private void Load(object sender, EventArgs e)
        {
            path = SaveLoad.Init_Load();
            if (path == "x") { return; }
            StreamReader reader;
            reader = new StreamReader(path);

            int foo = Convert.ToInt32(reader.ReadLine());
            reader.ReadLine();
            for (int i = 1; i <= foo; i++)
            {
                foreach (NewButton btn in all_list[i])
                {
                    btn.AccessibleDescription = reader.ReadLine();
                    btn.AccessibleName = reader.ReadLine();
                    if (btn.AccessibleName.StartsWith("STF")){ btn.ContextMenuStrip = STEditStrip; }
                    btn.Text = reader.ReadLine();
                    string PrlCheck = reader.ReadLine();

                    if (PrlCheck == "True")
                    {
                        secili = btn;
                        buton_checked = true;
                        DownButton_Click(sender, e);

                        NewButton prl = yaratilan.PrlTo.PrlTo;
                        prl.AccessibleDescription = reader.ReadLine();
                        prl.AccessibleName = reader.ReadLine();
                        prl.Text = reader.ReadLine();

                        ImageLoad(prl);
                    }
                    else if (PrlCheck == "False") { btn.HasPrl = false; }

                    ImageLoad(btn);
                }
            }
            buton_checked = false;
            reader.Close();
            reader.Dispose();
            MadeChange = false;
        }
        private void ImageLoad(NewButton foo)
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
                case "12":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "13":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "14":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "15":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "16":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "17":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "18":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                case "19":
                    foo.BackgroundImage = Properties.Resources.clock_n;
                    break;
                default:
                    break;
            }

        }
        private void NewFile()
        {
            if (MadeChange)
            {
                DialogResult result = MessageBox.Show("Save changes before new file?", "Save Changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    path = SaveLoad.path;
                    SaveLoad.Save();
                    Form Form_1 = Application.OpenForms["Form1"];
                    Form_1.Text = MainText + " - " + path.Split('\\').Last();
                    MadeChange = false;
                }
            }
            while (all_list.Keys.Count > 1)
            {
                int lastKey = all_list.Keys.Last();
                DeleteNetwork(all_list[lastKey][0]);
            }
            foreach (NewButton x in all_list[1])
            {
                if (x.Name != "button1")
                {
                    if (x.HasPrl)
                    {
                        string Button_Name = x.PrlTo.Name;
                        Button_Name = Button_Name.Substring(0, 6) + Convert.ToString((Convert.ToInt32(Button_Name.Substring(6)) - 1));
                        Control prl_bt = panel1.Controls[Button_Name] as NewButton;
                        DeleteParallel(prl_bt as NewButton);
                        x.HasPrl = false;
                        x.PrlTo = null;
                    }
                    x.BackgroundImage = toolStripButton3.BackgroundImage;
                    x.AccessibleDescription = "10";
                    x.AccessibleName = null;
                    x.Text = null;
                }
            }

        }



        private void Button2_Click(object sender, EventArgs e)
        {
            Checker(sender);
            leftPanel1.CurrentPinPopulate(secili);
        }
        private void Checker(object sender)
        {
            NewButton btn = sender as NewButton;
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
                textBox3.Text = btn.AccessibleName;
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
            NewButton name = sender as NewButton;
            name.BringToFront();
        }
        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            NewButton name = sender as NewButton;
            if (name.AccessibleName != "down")
            { name.SendToBack(); }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MadeChange == true)
            {
                DialogResult result = MessageBox.Show("Save changes before closing?", "Warning!", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    path = SaveLoad.path;
                    SaveLoad.Save();
                    Form Form_1 = Application.OpenForms["Form1"];
                    Form_1.Text = MainText + " - " + path.Split('\\').Last();
                }
                else if (result == DialogResult.Cancel) { return; }
            }
        }
        private void ChangesMade(object sender, ControlEventArgs e)
        {
            if (MadeChange == false)
            {
                MadeChange = true;
                this.Text = this.Text + "*";
            }
            leftPanel1.PopulateTreeviewPins();
        }
        private void ChangesMadeEvent(object sender, EventArgs e)
        {
            if (MadeChange == false)
            {
                MadeChange = true;
                this.Text = this.Text + "*";
            }
            leftPanel1.PopulateTreeviewPins();
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e) //shortcuts
        {
            if (e.KeyCode == Keys.O) { NOButton_Click(sender, e); } // normally open
            else if (e.KeyCode == Keys.K) { NCButton_Click(sender, e); } // normally close
            else if (e.KeyCode == Keys.T) { ClockButton_Click(sender, e); } // clock on
            else if (e.KeyCode == Keys.N) { NetworkButton_Click(sender, e); } // network
            else if (e.KeyCode == Keys.Y) { CoilButton_Click(sender, e); } // coil
            else if (e.KeyCode == Keys.Delete) { LinkButton_Click(sender, e); } // link
            else if (e.KeyCode == Keys.D) { DownButton_Click(sender, e); } // down
            else if (e.KeyCode == Keys.M) { MOVButton_Click(sender, e); } // mov
            else if (e.KeyCode == Keys.C) { CNTRButton_Click(sender, e); } // COUNTER
            else if (e.KeyCode == Keys.Escape) { SimulationClose(); }
        }


        private void IActivate_Click(object sender, EventArgs e)
        {
            var foo = sender as ToolStripItem;
            var bar = foo.Owner as ContextMenuStrip;
            NewButton tempButton = bar.SourceControl as NewButton;
            tempButton.Status = true;
            sim.change(tempButton);
        }
        private void IDeactivate_Click1(object sender, EventArgs e)
        {
            var foo = sender as ToolStripItem;
            var bar = foo.Owner as ContextMenuStrip;
            NewButton tempButton = bar.SourceControl as NewButton;
            tempButton.Status = false;
            sim.change(tempButton);
        }
        public void delgtSimulationUpdate(NewButton contact)
        {
            if (contact.Status) { contact.BackColor = Color.Green; }
            else { contact.BackColor = Color.White; }
        }
        private void SimulationClose()
        {
            if (!SimMode) { return; }
            sim.Cancel();
            foreach (int key in all_list.Keys)
            {
                foreach (NewButton tempButton in all_list[key])
                {
                    if (tempButton.AccessibleName is null) { continue; }
                    try
                    {
                        if (tempButton.AccessibleName[0] == 'I')
                        {
                            tempButton.ContextMenuStrip = null;
                        }
                    }
                    catch { continue; }
                }
            }
        }

    }
}