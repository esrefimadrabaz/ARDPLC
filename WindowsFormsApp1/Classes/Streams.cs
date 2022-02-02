using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
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
        //public static Dictionary<string, StringBuilder> Sbuilders = new Dictionary<string, StringBuilder>();
        public static void Ard_Init()
        {
            Init_Files(); //creates the header file inside another folder for .ino

            Debug.WriteLine("=====Header File Created=====");

            SavePath = Form1.path.Substring(0, Form1.path.Length-4) + "\\" + headerName + ".ino";
            //Sbuilders.Add("Main", new StringBuilder());

            writer = new StreamWriter(SavePath);
            
            writer.WriteLine("#include " + "\"" + headerName + ".h\"");
            writer.WriteLine("#include <Wire.h>");

            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    break;
                }
                else if (pins[0] == 'O')
                {
                    break;
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
            Ard_EXTI_Init();
            writer.WriteLine("}");
            writer.WriteLine("//End of Setup Func ------------------");

            writer.WriteLine("void loop() {");
            writer.WriteLine("IO_Scan();");

            Debug.WriteLine("=====Starting the logic cycle.=====");

        }

        public static void Ard_End()
        {
            writer.WriteLine("//end of script ---------------");
            writer.WriteLine("IO_Write();");
            writer.WriteLine("}");
            writer.Close();
        }

        public static void Ard_NC_M(string Pin)
        {

            writer.WriteLine("NC_M({0});", Pin);
        }
        public static void Ard_NO_M(string Pin)
        {

            writer.WriteLine("NO_M({0});", Pin);
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
        public static void Ard_Set_M(string pin)
        {
            writer.WriteLine("Set_M({0});", pin);
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
        public static void Ard_EXTI_Init()
        {
            foreach(string Temp in Form1.Used_Pins)
            {
                if (Temp.Contains("EXTI"))
                {
                    string mode = null;
                    if(Temp.Substring(5) == "R") { mode = "Rising"; }
                    if (Temp.Substring(5) == "F") { mode = "Falling"; }
                    if (Temp.Substring(5) == "C") { mode = "Change"; }
                    writer.WriteLine(Temp.Substring(4) + "," + Temp.Substring(0,5) + "," + mode);
                }
            }
        }
        public static void Ard_EXTI_Def()
        {

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
