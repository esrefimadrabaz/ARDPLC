using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    interface ISimulation
    {
        void NO_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList);
        void NC_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList);
        void tON_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, int millis);
        void tOFF_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, int millis);
        void tRTO_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList, int millis);
        void Coil_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList);
        void Mov_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList);
        void CntrUP_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList);
        void CntrDwn_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList);
        void Set_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList);
        void Reset_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList, int millis);
        void Arith_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList);
        void ADC_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList);
        void PWM_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList);
        void CMP_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList);
    }
    public class MSimulation : ISimulation
    {
        public bool dugum { get; set; }
        public bool next { get; set; }
        public void NO_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {
                if (BoolList[Contact.AccessibleName]) { dugum = true; next = true; Contact.Status = true; }
                else { dugum = false; Contact.Status = false; }
            }
        }
        public void NC_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {
                if (!BoolList[Contact.AccessibleName]) { dugum = true; next = true; Contact.Status = true; }
                else { dugum = false; Contact.Status = false; }
            }
        }
        public void tON_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, int millis)
        {
            int? intervalON = null;
            if (Contact.Text.Split('=')[1].StartsWith("D"))
            {
                intervalON = IntegerList[Contact.Text.Split('=')[1]];
            }
            else
            {
                intervalON = IntegerList[Contact.AccessibleName];
            }
            if (!dugum)
            {
                IntegerList[Contact.AccessibleName + "V"] = millis;
                Contact.Status = false;
            }
            if (dugum)
            {
                if (millis - IntegerList[Contact.AccessibleName + "V"] >= intervalON)
                {
                    dugum = true;
                    Contact.Status = true;
                }
                else
                {
                    dugum = false;
                    Contact.Status = false;
                }
            }            
        }
        public void tOFF_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, int millis)
        {
            int? intervalOFF = null;
            if (Contact.Text.Split('=')[1].StartsWith("D"))
            {
                intervalOFF = IntegerList[Contact.Text.Split('=')[1]];
            }
            else
            {
                intervalOFF = IntegerList[Contact.AccessibleName];
            }
            if (dugum)
            {
                IntegerList[Contact.AccessibleName + "V"] = millis;
                dugum = true;
                Contact.Status = true;
            }
            if ((!dugum) && (IntegerList[Contact.AccessibleName + "V"] != 0))
            {
                if (millis - IntegerList[Contact.AccessibleName + "V"] >= intervalOFF)
                {
                    dugum = false;
                    Contact.Status = false;
                }
                else { dugum = true; Contact.Status = true; }
            }
        }
        public void tRTO_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList, int millis)
        {
            int? intervalRTO = null;
            if (Contact.Text.Split('=')[1].StartsWith("D"))
            {
                intervalRTO = IntegerList[Contact.Text.Split('=')[1]];
            }
            else
            {
                intervalRTO = IntegerList[Contact.AccessibleName];
            }
            if (dugum)
            {
                if (!BoolList[Contact.AccessibleName + "L"])
                {
                    IntegerList[Contact.AccessibleName + "V"] = millis;
                    BoolList[Contact.AccessibleName + "L"] = true;
                }
                if (millis - IntegerList[Contact.AccessibleName + "V"] >= intervalRTO)
                {
                    dugum = true;
                    Contact.Status = true;
                }
                else { dugum = false; Contact.Status = false; }
            }
            else
            {
                Contact.Status = false;
                dugum = false;
            }
            
        }
        public void Coil_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList)
        {
            if (dugum) { Contact.Status = true; BoolList[Contact.AccessibleName] = true; }
            else { Contact.Status = false; BoolList[Contact.AccessibleName] = false; }
        }
        public void Mov_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList)
        {
            if (dugum)
            {
                string[] vals = Contact.AccessibleName.Split('='); // Mov.Type_From + Mov.Val_From + "=" + Mov.Type_To + Mov.Val_To;
                if (vals[0][0] == 'D')
                {
                    IntegerList[vals[1]] = IntegerList[vals[0]];
                }
                else if (vals[0][0] == 'C')
                {
                    IntegerList[vals[1]] = IntegerList[vals[0] + "V"];
                }
                else
                {
                    IntegerList[vals[1]] = Convert.ToInt32(vals[0].Substring(1));
                }
                Contact.Status = true;
            }
            else { Contact.Status = false; }
        }
        public void CntrUP_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList)
        {
            string[] cntr = Contact.Text.Split('='); // "CNTR" + counter.Counter + "_UP=" + counter.Preset_Def + counter.Preset;
            int? preset = null;
            if (cntr[1][0] == 'D')
            {
                preset = IntegerList[cntr[1]];
            }
            else
            {
                preset = IntegerList[Contact.AccessibleName];
            }
            if (dugum)
            {
                if (!Contact.Last)
                {
                    IntegerList[Contact.AccessibleName + "V"] += 1;
                    Contact.Last = true;
                }
            }
            else { Contact.Last = false; }
            if ((IntegerList[Contact.AccessibleName + "V"] >= preset))
            {
                dugum = true;
                Contact.Status = true;
                BoolList[Contact.AccessibleName] = true;
            }
            else { dugum = false; Contact.Status = false; BoolList[Contact.AccessibleName] = false; }
            
        }
        public void CntrDwn_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList)
        {
            string[] cntrd = Contact.Text.Split('='); // "CNTR" + counter.Counter + "_UP=" + counter.Preset_Def + counter.Preset;
            int? presetd = null;
            if (cntrd[1][0] == 'D')
            {
                presetd = IntegerList[cntrd[1]];
            }
            else
            {
                presetd = IntegerList[Contact.AccessibleName];
            }
            if (dugum)
            {
                if (!Contact.Last)
                {
                    IntegerList[Contact.AccessibleName + "V"] -= 1;
                    Contact.Last = true;
                }
            }
            else { Contact.Last = false; }
            if ((IntegerList[Contact.AccessibleName + "V"] >= presetd))
            {
                dugum = true;
                Contact.Status = true;
                BoolList[Contact.AccessibleName] = true;
            }
            else { dugum = false; Contact.Status = false; BoolList[Contact.AccessibleName] = false; }
            
        }
        public void Set_SimMain(NewButton Contact, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {
                Contact.Status = true;
                BoolList[Contact.AccessibleName] = true;
            }
            else
            {
                Contact.Status = false;
            }
        }
        public void Reset_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList, int millis)
        {
            if (dugum)
            {
                if (Contact.AccessibleName[0] == 'O' || Contact.AccessibleName[0] == 'M')
                {
                    BoolList[Contact.AccessibleName] = false;

                }
                else if (Contact.AccessibleName[0] == 'C')
                {
                    IntegerList[Contact.AccessibleName + "V"] = 0;
                }
                else
                {
                    IntegerList[Contact.AccessibleName + "V"] = millis;
                    if (BoolList.ContainsKey(Contact.AccessibleName + "L"))
                    {
                        BoolList[Contact.AccessibleName + "L"] = false;
                    }
                }
                Contact.Status = true;
            }
            else { Contact.Status = false; }
        }
        public void Arith_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList)
        {
            if (dugum)
            {
                string ArithData = Contact.AccessibleName.Split('=')[1];
                string[] ArithReg = Contact.AccessibleName.Split('=')[0].Split('+', '|', '/', '*');
                int?[] ArithValues = new int?[2];
                if(ArithReg[0][0] == 'D')
                {
                    ArithValues[0] = IntegerList[ArithReg[0]];
                }
                else { ArithValues[0] = Convert.ToInt32(ArithReg[0].Substring(1)); }

                if(ArithReg[1][0] == 'D')
                {
                    ArithValues[1] = IntegerList[ArithReg[1]];
                }
                else { ArithValues[1] = Convert.ToInt32(ArithReg[1].Substring(1)); }

                if (Contact.AccessibleName.Contains("+")) { IntegerList[ArithData] = ArithValues[0] + ArithValues[1];}
                else if (Contact.AccessibleName.Contains("|")) { IntegerList[ArithData] = ArithValues[0] - ArithValues[1]; }
                else if (Contact.AccessibleName.Contains("/")) { IntegerList[ArithData] = ArithValues[0] / ArithValues[1]; }
                else if (Contact.AccessibleName.Contains("*")) { IntegerList[ArithData] = ArithValues[0] * ArithValues[1]; }
                Contact.Status = true;
            }
            else
            {
                Contact.Status = false;
            }
        }
        public void ADC_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList)
        {
            if (dugum)
            {
                Contact.Status = true;
                IntegerList[Contact.AccessibleName.Split('-')[2]] = IntegerList[Contact.AccessibleName.Split('-')[1]];
            }
            else
            {
                Contact.Status = false;
                dugum = false;
            }
        }
        public void PWM_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {
                int? PWMVal;
                if (Contact.AccessibleName.Split('-')[1][0] == 'D')
                {
                    PWMVal = IntegerList[Contact.AccessibleName.Split('-')[1]];
                }
                else
                {
                    PWMVal = Convert.ToInt32(Contact.AccessibleName.Split('-')[1].Substring(1));
                }

                IntegerList[Contact.AccessibleName.Split('-')[2] + "V"] = PWMVal;
                BoolList[Contact.AccessibleName.Split('-')[2]] = true;
                Contact.Status = true;
            }
            else
            {
                Contact.Status = false;
                dugum = false;
                BoolList[Contact.AccessibleName.Split('-')[2]] = false;
            }

        }
        public void CMP_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {
                string[] CmpString = Contact.AccessibleName.Split('|');
                int MNmbr = Convert.ToInt32(CmpString[3].Substring(1));
                int?[] vals = new int?[2];
                switch (CmpString[1][0])
                {
                    case 'D':
                        vals[0] = IntegerList[CmpString[1]];
                        break;
                    case 'C':
                        vals[0] = IntegerList[CmpString[1] + "V"];
                        break;
                    default:
                        vals[0] = Convert.ToInt32(CmpString[1].Substring(1));
                        break;
                }
                switch (CmpString[2][0])
                {

                    case 'D':
                        vals[1] = IntegerList[CmpString[2]];
                        break;
                    case 'C':
                        vals[1] = IntegerList[CmpString[2] + "V"];
                        break;
                    default:
                        vals[1] = Convert.ToInt32(CmpString[2].Substring(1));
                        break;
                }
                BoolList[("M" + MNmbr)] = false;
                BoolList[("M" + MNmbr + 1)] = false;
                BoolList[("M" + MNmbr + 2)] = false;
                if (vals[0] > vals[1])
                {
                    BoolList[("M" + MNmbr)] = true;
                }
                else if (vals[0] == vals[1])
                {
                    BoolList["M" + (MNmbr + 1)] = true;
                }
                else if (vals[0] < vals[1])
                {
                    BoolList["M" + (MNmbr + 2)] = true;
                }
                Contact.Status = true;
            }
            else
            {
                Contact.Status = false;
            }
        }
        public void ZCMP_SimMain(NewButton Contact, ref Dictionary<string, int?> IntegerList, ref Dictionary<string, bool> BoolList)
        {
            if (dugum)
            {

                string[] ZCmpString = Contact.AccessibleName.Split('|');
                int ZMNumber = Convert.ToInt32(ZCmpString[4].Substring(1));
                int?[] zvals = new int?[3];
                switch (ZCmpString[1][0])
                {
                    case 'D':
                        zvals[0] = IntegerList[ZCmpString[1]];
                        break;
                    case 'C':
                        zvals[0] = IntegerList[ZCmpString[1] + "V"];
                        break;
                    default:
                        zvals[0] = Convert.ToInt32(ZCmpString[1].Substring(1));
                        break;
                }
                switch (ZCmpString[2][0])
                {
                    case 'D':
                        zvals[1] = IntegerList[ZCmpString[2]];
                        break;
                    case 'C':
                        zvals[1] = IntegerList[ZCmpString[2] + "V"];
                        break;
                    default:
                        zvals[1] = Convert.ToInt32(ZCmpString[2].Substring(1));
                        break;
                }
                switch (ZCmpString[3][0])
                {
                    case 'D':
                        zvals[2] = IntegerList[ZCmpString[3]];
                        break;
                    case 'C':
                        zvals[2] = IntegerList[ZCmpString[3] + "V"];
                        break;
                    default:
                        zvals[2] = Convert.ToInt32(ZCmpString[3].Substring(1));
                        break;
                }
                BoolList[("M" + ZMNumber)] = false;
                BoolList[("M" + ZMNumber + 1)] = false;
                BoolList[("M" + ZMNumber + 2)] = false;
                if (zvals[0] > zvals[2])
                {
                    BoolList[("M" + ZMNumber)] = true;
                }
                else if ((zvals[0] <= zvals[2]) && (zvals[2] <= zvals[1]))
                {
                    BoolList[("M" + ZMNumber + 1)] = true;
                }
                else if (zvals[2] > zvals[1])
                {
                    BoolList[("M" + ZMNumber + 2)] = true;
                }
                Contact.Status = true;
            }
            else
            {
                Contact.Status = false;
            }
        }
    }
}
