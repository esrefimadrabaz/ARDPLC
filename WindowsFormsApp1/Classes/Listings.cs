﻿using System;
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
     0 = NO     1 = NC      2 = CLOCK_ON       3 = CLOCK_OFF        4 = COIL    5 = MOV      10 = LINK       11 = NETWORK_START      99 = down       98 = up
    */

    class Listings
    {
        public static void Compile()
        {
            Streams.Ard_Init();
            foreach (string nets in Form1.all_list.Keys)
            {
                Streams.Ard_NetStart();
                Debug.WriteLine(nets);
                foreach (Button x in Form1.all_list[nets])
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

        public static void Sort(Button btn)
        {
            var Data = (ButtonInfo)btn.Tag;
            switch(btn.AccessibleDescription)
            {
                case "0": //NO
                    if (Data.Has_prl)
                    {

                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') {Streams.Ard_NO_M(btn.AccessibleName);}
                        else {Streams.Ard_NO(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");

                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NO_M(btn.AccessibleName); }
                        else { Streams.Ard_NO(btn.AccessibleName); }
                    }
                    break;
                case "1": //NC
                    if (Data.Has_prl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NC_M(btn.AccessibleName); }
                        else { Streams.Ard_NC(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_NC_M(btn.AccessibleName); }
                        else { Streams.Ard_NC(btn.AccessibleName); }
                    }
                    break;

                case "2": //CLOCK ON
                    if (Data.Has_prl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_CON(btn.Text.Substring(4), btn.AccessibleName);
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_CON(btn.Text.Substring(4), btn.AccessibleName);
                    }
                    break;

                case "3": //CLOCK OFF
                    if (Data.Has_prl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        Streams.Ard_COFF(btn.Text.Substring(5), btn.AccessibleName);
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        Streams.Ard_COFF(btn.Text.Substring(5), btn.AccessibleName);
                    }
                    break;

                case "4": //Coil
                    if (Data.Has_prl)
                    {
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (btn.AccessibleName[0] == 'M') { Streams.Ard_Coil_M(btn.AccessibleName); }
                        else { Streams.Ard_Coil(btn.AccessibleName); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
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
                    if(Data.Has_prl)
                    {
                        string[] vals = btn.AccessibleName.Split('=');
                        Streams.writer.WriteLine("");
                        Streams.writer.WriteLine("if(dugum) {prl = true;}");
                        if (vals[0][0] == 'K') { Streams.Ard_MOV(vals[0].Substring(1), vals[1]); }
                        else { Streams.Ard_MOV(vals[0], vals[1]); }
                        Streams.writer.WriteLine("if (prl)  {dugum=true;}");
                        Sort(Data.prl_to);
                        Streams.writer.WriteLine("if (next) { dugum = true; }");
                        Streams.writer.WriteLine("prl,next = false;");
                    }
                    else
                    {
                        string[] vals = btn.AccessibleName.Split('=');
                        if (vals[0][0] == 'K') { Streams.Ard_MOV(vals[0].Substring(1), vals[1]); }
                        else { Streams.Ard_MOV(vals[0], vals[1]); }
                    }
                    break;
                case "10": // Link
                    break;
                case "11": // Network Start
                    break;
                default:
                    Debug.WriteLine("Empty");
                    break;
            }
        }


    }
}
