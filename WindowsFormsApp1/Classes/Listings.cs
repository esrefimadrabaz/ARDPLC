using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WindowsFormsApp1
{
    /* Contact & Coil Codes 
     0 = NO     1 = NC      2 = CLOCK_ON       3 = CLOCK_OFF        4 = COIL    5 = MOV     6 = COUNTER_UP      7 = COUNTER_DOWN        8 = SET     9 = RESET    
     10 = LINK       11 = NETWORK_START    12 = ARITHMETICS  99 = down       98 = up
    */

    class Listings
    {
        public static void Compile()
        {
            Streams.Ard_Init();
            foreach (int nets in Form1.all_list.Keys)
            {
                Streams.Ard_NetStart();
                Debug.WriteLine(nets);
                foreach (NewButton x in Form1.all_list[nets])
                {
                    Sort(x);
                    


                    /*var Data = (ButtonInfo)x.Tag;
                    Debug.WriteLine(x.Name);
                    Debug.WriteLine(Data.Network);
                    if (Data.Has_prl)
                    {
                        Debug.WriteLine(Data.Has_prl);
                        Debug.WriteLine(Data.prl_to.Name);
                    }
                    Debug.WriteLine("----------------");*/
                }
            }
            Streams.Ard_End();
        }

        public static void Sort(NewButton btn)
        {            
            switch(btn.AccessibleDescription)
            {
                case "0": //NO
                    if (btn.HasPrl)
                    {

                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') {Streams.Ard_NO_M(btn.AccessibleName);}
                        else if (btn.AccessibleName[0] == 'C') { Streams.Ard_NO_M(btn.AccessibleName + "D"); }
                        else {Streams.Ard_NO(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");

                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NO_M(btn.AccessibleName); }
                        else if (btn.AccessibleName[0] == 'C') { Streams.Ard_NO_M(btn.AccessibleName + "D"); }
                        else { Streams.Ard_NO(btn.AccessibleName); }
                    }
                    break;
                case "1": //NC
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NC_M(btn.AccessibleName); }
                        else if (btn.AccessibleName[0] == 'C') { Streams.Ard_NC_M(btn.AccessibleName + "D"); }
                        else { Streams.Ard_NC(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NC_M(btn.AccessibleName); }
                        else if (btn.AccessibleName[0] == 'C') { Streams.Ard_NC_M(btn.AccessibleName + "D"); }
                        else { Streams.Ard_NC(btn.AccessibleName); }
                    }
                    break;

                case "2": //CLOCK ON
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_CON(btn.Text.Substring(4), btn.AccessibleName);
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_CON(btn.Text.Substring(4), btn.AccessibleName);
                    }
                    break;

                case "3": //CLOCK OFF
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_COFF(btn.Text.Substring(5), btn.AccessibleName);
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_COFF(btn.Text.Substring(5), btn.AccessibleName);
                    }
                    break;

                case "4": //Coil
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Coil_M(btn.AccessibleName); }
                        else { Streams.Ard_Coil(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Coil_M(btn.AccessibleName); }
                        else { Streams.Ard_Coil(btn.AccessibleName); }
                    }
                    break;
                case "5": // MOV
                    if(btn.HasPrl)
                    {
                        string[] vals = btn.AccessibleName.Split('=');
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (vals[0][0] == 'K' || vals[0][0] == 'F') { Streams.Ard_MOV(vals[0].Substring(1), vals[1]); }
                        else if (vals[0][0] == 'L') { Streams.Ard_MOV(vals[0].Substring(1) + "L", vals[1]);}
                        else { Streams.Ard_MOV(vals[0], vals[1]); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        string[] vals = btn.AccessibleName.Split('=');
                        if (vals[0][0] == 'K' || vals[0][0] == 'F' || vals[0][0] == 'L') { Streams.Ard_MOV(vals[0].Substring(1), vals[1]); }
                        else { Streams.Ard_MOV(vals[0], vals[1]); }
                    }
                    break;
                case "6": // CNTR_U
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_CNTUP(btn.Text.Split('=')[1], btn.AccessibleName, btn.AccessibleName+"L", btn.AccessibleName + "D");
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_CNTUP(btn.Text.Split('=')[1], btn.AccessibleName, btn.AccessibleName + "L", btn.AccessibleName + "D");
                    }
                    break;
                case "7": //CNTR_D
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_CNTD(btn.Text.Split('=')[1], btn.AccessibleName, btn.AccessibleName + "L", btn.AccessibleName + "D");
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_CNTD(btn.Text.Split('=')[1], btn.AccessibleName, btn.AccessibleName + "L", btn.AccessibleName + "D");
                    }
                    break;
                case "8": //SET
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Set_M(btn.AccessibleName); }
                        else { Streams.Ard_Set(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Set_M(btn.AccessibleName); }
                        else { Streams.Ard_Set(btn.AccessibleName); }
                    }
                    break;
                case "9": //RESET
                    if (btn.HasPrl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Reset_M(btn.AccessibleName); }
                        else if (btn.AccessibleName[0] == 'O') { Streams.Ard_Reset(btn.AccessibleName); }
                        else { Streams.Ard_Reset_O(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Reset_M(btn.AccessibleName); }
                        else if (btn.AccessibleName[0] == 'O') { Streams.Ard_Reset(btn.AccessibleName); }
                        else { Streams.Ard_Reset_O(btn.AccessibleName); }
                    }
                    break;
                case "10": // Link
                    break;
                case "11": // Network Start
                    break;
                case "12": // Arithmetic
                    if (btn.HasPrl)
                    {
                        string[] dispVals = btn.AccessibleName.Split('=');
                        string[] Vals = dispVals[0].Split('+','-','*','/');
                        string op = null;
                        if (dispVals[0].Contains('+')) {  op = "+"; }
                        else if (dispVals[0].Contains('-')) {  op = "-"; }
                        else if (dispVals[0].Contains('*')) {  op = "*"; }
                        else if (dispVals[0].Contains('/')) {  op = "/"; }

                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_Arithmetic(Vals[0].Substring(1), op, Vals[1].Substring(1), dispVals[1]);
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(btn.PrlTo);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        string[] dispVals = btn.AccessibleName.Split('=');
                        string[] Vals = dispVals[0].Split('+', '-', '*', '/');
                        string op = null;
                        if (dispVals[0].Contains('+')) {  op = "+"; }
                        else if (dispVals[0].Contains('-')) {  op = "-"; }
                        else if (dispVals[0].Contains('*')) {  op = "*"; }
                        else if (dispVals[0].Contains('/')) {  op = "/"; }

                        Streams.Ard_Arithmetic(Vals[0].Substring(1), op, Vals[1].Substring(1), dispVals[1]);
                    }
                    break;
                default:
                    Debug.WriteLine("Empty");
                    break;
            }
        }


    }
}
