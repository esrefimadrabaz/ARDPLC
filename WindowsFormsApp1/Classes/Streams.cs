using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class Streams
    {
        
        static string SavePath;
        public static StreamWriter writer;
        static string headerName;
        public static void Ard_Init()
        {
            Init_Files();
            SavePath = Form1.path.Substring(0, Form1.path.Length-4) + "\\" + headerName + ".ino";
            writer = new StreamWriter(SavePath);
            writer.WriteLine("#include " + "\"" + headerName + ".h\"");
            writer.WriteLine("#include <Wire.h>");

            /*
            writer.WriteLine("bool dugum = true;");
            writer.WriteLine("bool prl;");
            writer.WriteLine("bool next;");
            */

            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    char newpin = '0';
                    if (Convert.ToInt32(pins[1]) < 3) { newpin = Convert.ToChar(Convert.ToInt32(pins[1]) + 2); }
                    else if (Convert.ToInt32(pins[1]) == 3) { newpin = '7'; }
                    else if (Convert.ToInt32(pins[1]) == 4) { newpin = '8'; }
                    writer.WriteLine("const int I{0} = {0};", newpin);
                }
                else if (pins[0] == 'O')
                {
                    string newpin = "0";
                    if (Convert.ToInt32(pins[1]) == 0) { newpin = "5"; }
                    else if (Convert.ToInt32(pins[1]) == 1) { newpin = "6"; }
                    else if (Convert.ToInt32(pins[1]) == 2) { newpin = "9"; }
                    else if (Convert.ToInt32(pins[1]) == 3) { newpin = "10"; }
                    else if (Convert.ToInt32(pins[1]) == 3) { newpin = "11"; }
                    writer.WriteLine("const int O{0} = {0};", newpin);
                }
                else if (pins[0] == 'M')
                {
                    writer.WriteLine("bool {0};", pins);
                }
                else if (pins[0] == 'D')
                {
                    switch (pins[1])
                    {
                        case 'F':
                            writer.WriteLine("float D{0};", pins.Substring(2));
                            break;
                        case 'L':
                            writer.WriteLine("long D{0};", pins.Substring(2));
                            break;
                        default:
                            writer.WriteLine("int D{0};", pins.Substring(2));
                            break;

                    }
                }
                else if(pins[0] == 'A')
                {
                    break;
                }
                else if (pins.Substring(0,3) == "TON")
                {
                    writer.WriteLine("unsigned int TON{0};", pins.Substring(3));
                }
                else if (pins.Substring(0, 4) == "TOFF")
                {
                    writer.WriteLine("unsigned int TOFF{0};", pins.Substring(4));
                }
                else if (pins.Substring(0, 3) == "TRO")
                {
                    writer.WriteLine("unsigned int TRO{0};", pins.Substring(3));
                    writer.WriteLine("bool TRB{0};", pins.Substring(3));
                }
                else if(pins.Substring(0,4) == "CNTR")
                {
                    writer.WriteLine("unsigned int CNTR{0};", pins.Substring(4));
                    writer.WriteLine("bool CNTR{0}L;", pins.Substring(4));
                    writer.WriteLine("bool CNTR{0}D;", pins.Substring(4));
                }               
            }
            writer.WriteLine("//End Of Declaration ----------------");

            writer.WriteLine("void setup() {");
            writer.WriteLine("DDRD = DDRD | 0b01100000;"); 
            writer.WriteLine("DDRB = DDRB | 0b00001110;"); 
            writer.WriteLine("DDRC = DDRC | 0b00000000;"); //analog pins
            writer.WriteLine("}");
            writer.WriteLine("//End of Setup Func ------------------");

            writer.WriteLine("void loop() {");
        }

        public static void Ard_End()
        {
            writer.WriteLine("}");
            writer.WriteLine("//end of script ---------------");
            writer.Close();
        }

        public static void Ard_NC(string Pin)
        {

            writer.WriteLine("NC({0});", Pin);
        }
        public static void Ard_NC_M(string Pin)
        {

            writer.WriteLine("NC_M({0});", Pin);
        }
        public static void Ard_NO(string Pin)
        {

            writer.WriteLine("NO({0});", Pin);
        }
        public static void Ard_NO_M(string Pin)
        {

            writer.WriteLine("NO_M({0});", Pin);
        }
        public static void Ard_Coil(string Pin)
        {

            writer.WriteLine("Coil({0});", Pin);
        }
        public static void Ard_Coil_M(string Pin)
        {

            writer.WriteLine("Coil_M({0});", Pin);
        }
        public static void Ard_CON(string interval, string timer)
        {
            writer.WriteLine("cON({0}, {1});", interval, timer);
        }
        public static void Ard_COFF(string interval, string timer)
        {
            writer.WriteLine("cOFF({0}, {1});", interval, timer);
        }
        public static void Ard_CRTO(string interval, string timer, string rtn)
        {
            writer.WriteLine("cRTO({0}, {1}, {2});", interval, timer, rtn);
        }
        public static void Ard_MOV(string From, string To)
        {
            writer.WriteLine("if (dugum){");
            writer.WriteLine("{0} = {1};", To, From);
            writer.WriteLine("}");
        }
        public static void Ard_CNTUP(string preset, string CNTR, string CNTLAST, string DONE)
        {
            writer.WriteLine("CNTU({0},{1},{2},{3});", preset, CNTR, CNTLAST, DONE);
        }
        public static void Ard_CNTD(string preset, string CNTR, string CNTLAST, string DONE)
        {
            writer.WriteLine("CNTD({0},{1},{2},{3});", preset, CNTR, CNTLAST, DONE);
        }
        public static void Ard_Set(string pin)
        {
            writer.WriteLine("Set({0});", pin);
        }
        public static void Ard_Set_M(string pin)
        {
            writer.WriteLine("Set_M({0});", pin);
        }
        public static void Ard_Reset(string pin)
        {
            writer.WriteLine("Reset({0});", pin);
        }
        public static void Ard_Reset_O(string pin)
        {
            writer.WriteLine("Reset_O({0});", pin);
        }
        public static void Ard_Reset_M(string pin)
        {
            writer.WriteLine("Reset_M({0});", pin);
        }
        public static void Ard_Reset_T(string pin)
        {
            writer.WriteLine("Reset_T({0});", pin);
        }
        public static void Ard_Arithmetic(string PreVal, string Operation, string PostVal, string Result)
        {
            writer.WriteLine("if (dugum){");
            writer.WriteLine("{3} = ({0}){1}({2});", PreVal, Operation, PostVal, Result);
            writer.WriteLine("}");
        }
        public static void Ard_CMP(string first, string last, string MF, string MM, string ML)
        {
            writer.WriteLine("CMP({0},{1},{2},{3},{4});", first, last, MF, MM, ML);
        }
        public static void Ard_ZCMP(string first, string middle, string last, string MF, string MM, string ML)
        {
            writer.WriteLine("ZCMP({0},{1},{2},{3},{4},{5});", first, middle, last, MF, MM, ML);
        }
        public static void Ard_ADC(string pin, string destination)
        {
            writer.WriteLine("ADC({0},{1});", pin, destination);
        }
        public static void Ard_PWM(string pin, string value)
        {
            writer.WriteLine("PWM({0},{1});", pin, value);
        }
        public static void Ard_NetStart()
        {
            writer.WriteLine("//New Network Start ---------------");
            writer.WriteLine("dugum = true;");
        }



        private static void Init_Files()
        {
            headerName = Form1.path.Split('\\').Last();
            headerName = headerName.Substring(0, headerName.Length - 4);

            string newPath = Form1.path.Substring(0, Form1.path.Length - 4);
            string Funcs = Properties.Resources.Funcs;
            Directory.CreateDirectory(newPath);

            File.Create(newPath + "\\" + headerName + ".h" ).Dispose();

            File.Create(newPath + "\\"+ headerName + ".ino").Dispose();
            using (StreamWriter DispWriter = new StreamWriter(newPath + "\\" + headerName + ".h"))
            {
                DispWriter.WriteLine(Funcs);
                DispWriter.Close();
            }

        }

    }
}
