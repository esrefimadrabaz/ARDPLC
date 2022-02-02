using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Diagnostics;

namespace WindowsFormsApp1
{
    class SimulationA
    {
        private Dictionary<string, int?> IntegerList = new Dictionary<string, int?>();
        private List<NewButton> InputList = new List<NewButton>();
        private Dictionary<string, bool> BoolList = new Dictionary<string, bool>();
        private System.Timers.Timer millisTimer;
        private BackgroundWorker MainWorker;
        private int scaler;
        private MSimulation MSimulation;

        private Form1 Main;
        private bool prl;

        #region INIT
        private void ListsInit()
        { // for defining variables
            IntegerList.Clear();
            BoolList.Clear();
            InputList.Clear();
            foreach (int key in Form1.all_list.Keys){
                foreach (NewButton Contact in Form1.all_list[key])
                {
                    Sort(Contact);
                }
            }
        }
        private void Sort(NewButton Contact)
        {
            switch (Contact.AccessibleDescription)
            {
                case "0": // ->NO
                    if (!(Contact.AccessibleName[0] == 'C'))
                    {
                        if (!BoolList.ContainsKey(Contact.AccessibleName))
                        {
                            BoolList.Add(Contact.AccessibleName, false);
                            break;
                        }
                    }
                    else if (!(BoolList.ContainsKey(Contact.AccessibleName + "D")))
                    {
                        BoolList.Add(Contact.AccessibleName + "D", false);
                    }
                    break;
                case "1": // ->NC
                    if (!(Contact.AccessibleName[0] == 'C'))
                    {
                        if (!BoolList.ContainsKey(Contact.AccessibleName))
                        {
                            BoolList.Add(Contact.AccessibleName, false);
                            break;
                        }
                    }
                    else if (!(BoolList.ContainsKey(Contact.AccessibleName + "D")))
                    {
                        BoolList.Add(Contact.AccessibleName + "D", false);
                    }
                    break;
                case "2": // ->TON
                    if (Contact.Text.Split('=')[1].StartsWith("D")) // TON=Dx
                    {
                    }
                    else
                    {
                        IntegerList.Add(Contact.AccessibleName, Convert.ToInt32(Contact.Text.Split('=')[1]));
                    }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName + "V")) { IntegerList.Add(Contact.AccessibleName + "V", null); }
                    break;
                case "3": // ->TOFF
                    if (Contact.Text.Split('=')[1].StartsWith("D")) // TOFF=Dx
                    {
                    }
                    else
                    {
                        IntegerList.Add(Contact.AccessibleName, Convert.ToInt32(Contact.Text.Split('=')[1]));
                    }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName + "V")) { IntegerList.Add(Contact.AccessibleName + "V", null); }
                    break;
                case "4": // -> Coil
                    if (!BoolList.ContainsKey(Contact.AccessibleName))
                    {
                        BoolList.Add(Contact.AccessibleName, false);
                    }
                    break;
                case "5": // -> MOV
                    string[] vals = Contact.AccessibleName.Split('='); // Mov.Type_From + Mov.Val_From + "=" + Mov.Type_To + Mov.Val_To;
                    if (vals[0][0] == 'D')
                    {
                        if (IntegerList.ContainsKey(vals[1]))
                        {
                            IntegerList[vals[1]] = IntegerList[vals[0]];
                        }
                        else
                        {
                            IntegerList.Add(vals[1], null);
                        }
                    }
                    else
                    {
                        if (!IntegerList.ContainsKey(vals[1]))
                        {
                            IntegerList.Add(vals[1], null);
                        }
                    }
                    break;
                case "6": // -> CNTRUP
                    string[] cntr = Contact.Text.Split('='); // "CNTR" + counter.Counter + "_UP=" + counter.Preset_Def + counter.Preset;
                    if (cntr[1][0] == 'D')
                    {}
                    else
                    {
                        IntegerList.Add(Contact.AccessibleName, Convert.ToInt32(cntr[1]));
                    }
                    if (!BoolList.ContainsKey(Contact.AccessibleName)) { BoolList.Add(Contact.AccessibleName, false); }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName + "V")) { IntegerList.Add(Contact.AccessibleName + "V", 0); }
                    break;
                case "7": // -> CNTRDWN
                    string[] cntrd = Contact.Text.Split('='); // "CNTR" + counter.Counter + "_UP=" + counter.Preset_Def + counter.Preset;
                    if (cntrd[1][0] == 'D')
                    {

                    }
                    else
                    {
                        IntegerList.Add(Contact.AccessibleName, Convert.ToInt32(cntrd[1]));
                    }
                    if (!BoolList.ContainsKey(Contact.AccessibleName))
                    {
                        BoolList.Add(Contact.AccessibleName, false);
                    }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName + "V")) { IntegerList.Add(Contact.AccessibleName + "V", 0); }
                    break;
                case "8": // ->SET
                    if (!BoolList.ContainsKey(Contact.AccessibleName))
                    {
                        BoolList.Add(Contact.AccessibleName, false);
                    }
                    break;
                case "9": // -> RESET
                    if (Contact.AccessibleName[0] == 'O' || Contact.AccessibleName[0] == 'M')
                    {
                        if (!BoolList.ContainsKey(Contact.AccessibleName))
                        {
                            BoolList.Add(Contact.AccessibleName, false);
                        }
                    }
                    break;
                case "12": // -> Arith
                    string ArithData = Contact.AccessibleName.Split('=')[1];
                    if (!IntegerList.ContainsKey(ArithData))
                    {
                        IntegerList.Add(ArithData, null);
                    }
                    break;
                case "13": // -> TRTO
                    if (Contact.Text.Split('=')[1].StartsWith("D")) // TON=Dx
                    {
                    }
                    else
                    {
                        IntegerList.Add(Contact.AccessibleName, Convert.ToInt32(Contact.Text.Split('=')[1]));
                    }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName + "V")) { IntegerList.Add(Contact.AccessibleName + "V", null); }
                    if (!BoolList.ContainsKey(Contact.AccessibleName + "L")) { BoolList.Add(Contact.AccessibleName + "L", false); }
                    break;
                case "14":
                    int Nmbr = Convert.ToInt32(Contact.AccessibleName.Split('|')[3].Substring(1));
                    if (!BoolList.ContainsKey("M" + Nmbr)) { BoolList.Add(("M"+ Nmbr), false); }
                    Nmbr += 1;
                    if (!BoolList.ContainsKey("M" + Nmbr)) { BoolList.Add(("M" + Nmbr), false); }
                    Nmbr += 1;
                    if (!BoolList.ContainsKey("M" + Nmbr)) { BoolList.Add(("M" + Nmbr), false); }
                    break;
                case "15":
                    int ZNmbr = Convert.ToInt32(Contact.AccessibleName.Split('|')[4].Substring(1));
                    if(!BoolList.ContainsKey("M" + ZNmbr)) { BoolList.Add(("M" + ZNmbr), false); }
                    ZNmbr += 1;
                    if (!BoolList.ContainsKey("M" + ZNmbr)) { BoolList.Add(("M" + ZNmbr), false); }
                    ZNmbr += 1;
                    if (!BoolList.ContainsKey("M" + ZNmbr)) { BoolList.Add(("M" + ZNmbr), false); }
                    break;
                case "16": // -> ADC
                    if (!IntegerList.ContainsKey(Contact.AccessibleName.Split('-')[2]))
                    {
                        IntegerList.Add(Contact.AccessibleName.Split('-')[2], null);
                    }
                    if (!IntegerList.ContainsKey(Contact.AccessibleName.Split('-')[1]))
                    {
                        IntegerList.Add(Contact.AccessibleName.Split('-')[1], null);
                    }
                    break;
                case "17": // -> PWM
                    if (!IntegerList.ContainsKey(Contact.AccessibleName.Split('-')[2] + "V"))
                    {
                        IntegerList.Add(Contact.AccessibleName.Split('-')[2] + "V", null);
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        public void SimulationStart(Form1 x)
        {
            Main = x;
            MSimulation = new MSimulation();
            ListsInit();
            MainWorker = new BackgroundWorker();
            MainWorker.WorkerSupportsCancellation = true;
            MainWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(SimulationWork);
            MainWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(SimulationComplete);
            millisTimer = new System.Timers.Timer(25);
            millisTimer.AutoReset = true;
            millisTimer.Elapsed += millisElapsed;
            millisTimer.Enabled = true;
            millisTimer.Start();

            MainWorker.RunWorkerAsync();
        }
        private void SimulationWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker mainWorker = sender as BackgroundWorker;
            while (!mainWorker.CancellationPending)
            {
                foreach(int key in Form1.all_list.Keys)
                {
                    MSimulation.dugum = true;
                    foreach (NewButton Contact in Form1.all_list[key])
                    {
                        if (Contact.AccessibleDescription == "10") // -> Link
                        {
                            if (MSimulation.dugum) { Contact.Status = true; }
                            else { Contact.Status = false; }
                            Contact.Invoke(Main.mySimulationUpdate, Contact);
                            continue;
                        }
                        else if (Contact.AccessibleDescription == "11") // -> NetStart
                        {
                            Contact.Status = true;
                            Contact.Invoke(Main.mySimulationUpdate, Contact);
                            continue;
                        }
                        //main prog sort should come here
                        MainSort(Contact);
                    }
                }
            }
        }
        private void SimulationComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            foreach(int key in Form1.all_list.Keys)
            {
                foreach (NewButton btn in Form1.all_list[key])
                {
                    btn.Status = false;
                    btn.Last = false;
                    btn.Invoke(Main.mySimulationUpdate, btn);
                }
            }
            worker.Dispose();
        }

        private void MainSort(NewButton Contact)
        {
            switch (Contact.AccessibleDescription)
            {
                case "0": // -> NO
                    if (Contact.HasPrl)
                    {
                        if (MSimulation.dugum) { prl = true; }
                        MSimulation.NO_SimMain(Contact, ref BoolList);
                        if (prl) { MSimulation.dugum = true; }
                        MainSort(Contact.PrlTo);
                        if (MSimulation.next) { MSimulation.dugum = true; }
                        prl = false;
                        MSimulation.next = false;
                    }
                    else
                    {
                        MSimulation.NO_SimMain(Contact, ref BoolList);
                    }
                    break;
                case "1": // -> NC
                    if (Contact.HasPrl)
                    {
                        if (MSimulation.dugum) { prl = true; }
                        MSimulation.NC_SimMain(Contact, ref BoolList);
                        if (prl) { MSimulation.dugum = true; }
                        MainSort(Contact.PrlTo);
                        if (MSimulation.next) { MSimulation.dugum = true; }
                        prl = false;
                        MSimulation.next = false;
                    }
                    else
                    {
                        MSimulation.NC_SimMain(Contact, ref BoolList);
                    }
                    break;
                case "2": // -> clockON
                    MSimulation.tON_SimMain(Contact, ref IntegerList, millis());
                    break;
                case "3": // -> clockOFF
                    MSimulation.tOFF_SimMain(Contact, ref IntegerList,millis());
                    break;
                case "4": // -> coil
                    MSimulation.Coil_SimMain(Contact, ref BoolList);
                    break;
                case "5": // -> MOV
                    MSimulation.Mov_SimMain(Contact, ref IntegerList);
                    break;
                case "6": // -> CNTRUP
                    MSimulation.CntrUP_SimMain(Contact, ref IntegerList, ref BoolList);
                    break;
                case "7": // -> CNTRDWN
                    MSimulation.CntrDwn_SimMain(Contact, ref IntegerList, ref BoolList);
                    break;
                case "8": // -> SET
                    MSimulation.Set_SimMain(Contact, ref BoolList);
                    break;
                case "9": // -> RESET
                    MSimulation.Reset_SimMain(Contact, ref IntegerList, ref BoolList, millis());
                    break;
                case "12": // -> Arith
                    MSimulation.Arith_SimMain(Contact, ref IntegerList);
                    break;
                case "13": // -> TRTO
                    MSimulation.tRTO_SimMain(Contact, ref IntegerList, ref BoolList, millis());
                    break;
                case "14": // -> CMP
                    MSimulation.CMP_SimMain(Contact, ref IntegerList, ref BoolList);
                    break;
                case "15": // -> ZCMP
                    MSimulation.ZCMP_SimMain(Contact, ref IntegerList, ref BoolList);
                    break;
                case "16": // -> ADC
                    MSimulation.ADC_SimMain(Contact, ref IntegerList);
                    break;
                case "17": // -> PWM
                    MSimulation.PWM_SimMain(Contact, ref IntegerList, ref BoolList);
                    break;
                default:
                    break;
            }
            Contact.Invoke(Main.mySimulationUpdate, Contact);
        }

        public void change(NewButton In)
        {
            if (In.Status) { this.BoolList[In.AccessibleName] = true; }
            else if (!In.Status) { this.BoolList[In.AccessibleName] = false; }
        }
        private void millisElapsed(Object source, System.Timers.ElapsedEventArgs e)
        {
            scaler += 1;
        }
        private int millis()
        {
            return scaler * 25;
        }
        public void Cancel()
        {
            MainWorker.CancelAsync();
        }
    }
}
