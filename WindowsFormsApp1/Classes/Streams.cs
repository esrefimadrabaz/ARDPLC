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
        public static string builder = "Main";
        static string headerName;
        public static Dictionary<string, StringBuilder> Sbuilders = new Dictionary<string, StringBuilder>();
        public static void Ard_Init()
        {
            Init_Files(); //creates the header file inside another folder for .ino

            Debug.WriteLine("=====Header File Created=====");

            SavePath = Form1.path.Substring(0, Form1.path.Length-4) + "\\" + headerName + ".ino";
            Sbuilders.Add("Main", new StringBuilder());

            Sbuilders[builder].AppendLine("#include " + "\"" + headerName + ".h\"");
            Sbuilders[builder].AppendLine("#include <Wire.h>");

            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    continue;
                }
                else if (pins[0] == 'O')
                {
                    continue;
                }
                else if (pins[0] == 'M')
                {
                    Sbuilders[builder].AppendFormat("bool {0};", pins).AppendLine();
                }
                else if (pins[0] == 'D')
                {
                    switch (pins[1])
                    {
                        case 'F':
                            Sbuilders[builder].AppendFormat("float D{0};", pins.Substring(2)).AppendLine();
                            break;
                        case 'L':
                            Sbuilders[builder].AppendFormat("long D{0};", pins.Substring(2)).AppendLine();
                            break;
                        default:
                            Sbuilders[builder].AppendFormat("int D{0};", pins.Substring(2)).AppendLine();
                            break;

                    }
                }
                else if (pins[0] == 'A')
                {
                    continue;
                }
                else if (pins.Substring(0, 3) == "TON")
                {
                    Sbuilders[builder].AppendFormat("int TON{0};", pins.Substring(3)).AppendLine();
                }
                else if (pins.Substring(0, 4) == "TOFF")
                {
                    Sbuilders[builder].AppendFormat("int TOFF{0};", pins.Substring(4)).AppendLine();
                }
                else if (pins.Substring(0, 3) == "TRO")
                {
                    Sbuilders[builder].AppendFormat("int TRO{0};", pins.Substring(3)).AppendLine();
                    Sbuilders[builder].AppendFormat("bool TRB{0};", pins.Substring(3)).AppendLine();
                }
                else if (pins.Substring(0, 4) == "CNTR")
                {
                    Sbuilders[builder].AppendFormat("int CNTR{0};", pins.Substring(4)).AppendLine();
                    Sbuilders[builder].AppendFormat("bool CNTR{0}L;", pins.Substring(4)).AppendLine();
                    Sbuilders[builder].AppendFormat("bool CNTR{0}D;", pins.Substring(4)).AppendLine();
                }
                else if (pins.StartsWith("STF"))
                {
                    Ard_STFDefine(pins);
                }
            }

            Sbuilders[builder].AppendLine("//End Of Declaration ----------------");

            Sbuilders[builder].AppendLine("void setup() {");
            Sbuilders[builder].AppendLine("DDRD = DDRD | 0b01100000;"); 
            Sbuilders[builder].AppendLine("DDRB = DDRB | 0b00001110;"); 
            Sbuilders[builder].AppendLine("DDRC = DDRC | 0b00000000;"); //analog pins
            Ard_EXTI_Init();
            Sbuilders[builder].AppendLine("}");
            Sbuilders[builder].AppendLine("//End of Setup Func ------------------");

            Sbuilders[builder].AppendLine("void loop() {");
            Sbuilders[builder].AppendLine("IO_Scan();");

            Debug.WriteLine("=====Starting the logic cycle.=====");

        }

        public static void Ard_End()
        {
            Sbuilders[builder].AppendLine("//end of loop ---------------");
            Sbuilders[builder].AppendLine("IO_Write();");
            Sbuilders[builder].AppendLine("}");

            Ard_EXTI_Def();
            using (StreamWriter writer = new StreamWriter(SavePath))
            {
                writer.WriteLine(Sbuilders[builder]);
            }
            Sbuilders.Clear();
        }
        public static void Ard_STFDefine(string A_Name)
        {
            string Input = null;
            int length = SavePath.Length - (((SavePath.Split('\\').Last().Length - 4) * 2) + 5);
            string path = SavePath.Substring(0, length);
            using (StreamReader Reader = new StreamReader(path + A_Name + ".st"))
            {
                Input = Reader.ReadToEnd();
            }
            STFCompiler sTF = new STFCompiler();
            sTF.Input = Input;
            Sbuilders[builder].AppendLine(sTF.Translate());
        }
        public static void Ard_STFUse(string Name)
        {
            string fName = Name.Substring(4, Name.Length - 4);
            Sbuilders[builder].AppendLine(fName + "();\n");
        }
        public static void Ard_NC_M(string Pin)
        {

            Sbuilders[builder].AppendFormat("NC_M({0});", Pin).AppendLine();
        }
        public static void Ard_NO_M(string Pin)
        {

            Sbuilders[builder].AppendFormat("NO_M({0});", Pin).AppendLine();
        }
        public static void Ard_Coil_M(string Pin)
        {

            Sbuilders[builder].AppendFormat("Coil_M({0});", Pin).AppendLine();
        }
        public static void Ard_CON(string interval, string timer)
        {
            Sbuilders[builder].AppendFormat("cON({0}, {1});", interval, timer).AppendLine();
        }
        public static void Ard_COFF(string interval, string timer)
        {
            Sbuilders[builder].AppendFormat("cOFF({0}, {1});", interval, timer).AppendLine();
        }
        public static void Ard_CRTO(string interval, string timer, string rtn)
        {
            Sbuilders[builder].AppendFormat("cRTO({0}, {1}, {2});", interval, timer, rtn).AppendLine();
        }
        public static void Ard_MOV(string From, string To)
        {
            Sbuilders[builder].AppendLine("if (dugum){");
            Sbuilders[builder].AppendFormat("{0} = {1};", To, From).AppendLine();
            Sbuilders[builder].AppendLine("}");
        }
        public static void Ard_CNTUP(string preset, string CNTR, string CNTLAST, string DONE)
        {
            Sbuilders[builder].AppendFormat("CNTU({0},{1},{2},{3});", preset, CNTR, CNTLAST, DONE).AppendLine();
        }
        public static void Ard_CNTD(string preset, string CNTR, string CNTLAST, string DONE)
        {
            Sbuilders[builder].AppendFormat("CNTD({0},{1},{2},{3});", preset, CNTR, CNTLAST, DONE).AppendLine();
        }
        public static void Ard_Set_M(string pin)
        {
            Sbuilders[builder].AppendFormat("Set_M({0});", pin).AppendLine();
        }
        public static void Ard_Reset_O(string pin)
        {
            Sbuilders[builder].AppendFormat("Reset_O({0});", pin).AppendLine();
        }
        public static void Ard_Reset_M(string pin)
        {
            Sbuilders[builder].AppendFormat("Reset_M({0});", pin).AppendLine();
        }
        public static void Ard_Reset_T(string pin)
        {
            Sbuilders[builder].AppendFormat("Reset_T({0});", pin).AppendLine();
        }
        public static void Ard_Arithmetic(string PreVal, string Operation, string PostVal, string Result)
        {
            Sbuilders[builder].AppendLine("if (dugum){");
            Sbuilders[builder].AppendFormat("{3} = ({0}){1}({2});", PreVal, Operation, PostVal, Result).AppendLine();
            Sbuilders[builder].AppendLine("}");
        }
        public static void Ard_CMP(string first, string last, string MF, string MM, string ML)
        {
            Sbuilders[builder].AppendFormat("CMP({0},{1},{2},{3},{4});", first, last, MF, MM, ML).AppendLine();
        }
        public static void Ard_ZCMP(string first, string middle, string last, string MF, string MM, string ML)
        {
            Sbuilders[builder].AppendFormat("ZCMP({0},{1},{2},{3},{4},{5});", first, middle, last, MF, MM, ML).AppendLine();
        }
        public static void Ard_ADC(string pin, string destination)
        {
            Sbuilders[builder].AppendFormat("ADC_Alt({0},{1});", pin, destination).AppendLine();
        }
        public static void Ard_PWM(string pin, string value)
        {
            Sbuilders[builder].AppendFormat("PWM({0},{1});", pin[1], value).AppendLine();
        }
        public static void Ard_Serial(string function, int value, string format)
        {
            if (function == "begin")
            {
                Sbuilders[builder].AppendFormat("Serial.{0}(9600);", function).AppendLine();
            }
            else if (function != "print")
            {
                Sbuilders[builder].AppendFormat("Serial.{0}();", function).AppendLine();
            }
            else
            {
                Sbuilders[builder].AppendFormat("Serial.{0}(D{1}, {2});", function, value.ToString(), format).AppendLine();
            }

        }
        public static void Ard_NetStart()
        {
            Sbuilders[builder].AppendLine("//New Network Start ---------------");
            Sbuilders[builder].AppendLine("dugum = true;");
        }
        public static void Ard_EXTI_Init()
        {
            foreach(string Temp in Form1.Used_Pins)
            {
                if (Temp.Contains("EXTI"))
                {
                    string mode = null;
                    if(Temp.Substring(5) == "R") { mode = "RISING"; }
                    if (Temp.Substring(5) == "F") { mode = "FALLING"; }
                    if (Temp.Substring(5) == "C") { mode = "CHANGE"; }
                    string param = Temp.Substring(4, 1) + "," + Temp.Substring(0, 5) + "," + mode;

                    Sbuilders[builder].AppendLine("attachInterrupt(" + param + ");");
                    Sbuilders.Add(Temp.Substring(0, 5), new StringBuilder());
                }
            }
        }
        public static void Ard_EXTI_Def()
        {
            foreach(string key in Sbuilders.Keys)
            {
                if(key == "Main") { continue; }
                Sbuilders["Main"].AppendLine("void " + key + "(){" );
                Sbuilders["Main"].AppendLine("dugum = true;");
                Sbuilders["Main"].AppendLine(Sbuilders[key].ToString());
                Sbuilders["Main"].AppendLine("}");
            }
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
