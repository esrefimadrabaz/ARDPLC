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
        static string path = @"C:\Users\Oguz\Desktop\plc0.1\plc0.1.ino";
        public static StreamWriter writer;
        public static void Ard_Init()
        {

            writer = new StreamWriter(path);
            writer.WriteLine("#include \"deneme.h\"");
            writer.WriteLine("#include <Wire.h>");
            writer.WriteLine("bool dugum = true;");
            writer.WriteLine("bool prl;");
            writer.WriteLine("bool next;");
            writer.WriteLine("int K;");
            //writer.Close();
            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    writer.WriteLine("const int I{0} = {0};", pins[1]);
                }
                else if (pins[0] == 'O')
                {
                    writer.WriteLine("const int O{0} = {0};", pins[1]);
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
                        case 'D':
                            switch (pins[2])
                            {
                                case 'F':
                                    writer.WriteLine("float D{0};", pins.Substring(3));
                                    break;
                                case 'K':
                                    writer.WriteLine("int D{0};", pins.Substring(3));
                                    break;
                                case 'L':
                                    writer.WriteLine("long D{0};", pins.Substring(3));
                                    break;
                                default:
                                    writer.WriteLine("int D{0};", pins.Substring(3));
                                    break;
                            }
                            break;
                        default:
                            writer.WriteLine("int D{0};", pins.Substring(2));
                            break;

                    }
                    
                }
                else if (pins.Substring(0,3) == "TON")
                {
                    writer.WriteLine("int TON{0};", pins.Substring(3));
                }
                else if (pins.Substring(0, 4) == "TOFF")
                {
                    writer.WriteLine("int TOFF{0};", pins.Substring(4));
                }
                else if(pins.Substring(0,4) == "CNTR")
                {
                    writer.WriteLine("int CNTR{0};", pins.Substring(4));
                    writer.WriteLine("bool CNTR{0}L;", pins.Substring(4));
                    writer.WriteLine("bool CNTR{0}D;", pins.Substring(4));
                }
            }
            writer.WriteLine("//End Of Declaration ----------------");
            writer.WriteLine("void setup() {");

            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    writer.WriteLine("pinMode(I{0}, INPUT);", pins[1]);
                }
                else if (pins[0] == 'O')
                {
                    writer.WriteLine("pinMode(O{0}, OUTPUT);", pins[1]);
                }
            }
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
        public static void Ard_MOV(string From, string To)
        {
            writer.WriteLine("{0} = {1};", To, From);
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
        public static void Ard_Arithmetic(string PreVal, string Operation, string PostVal, string Result)
        {
            writer.WriteLine("{3} = {0} {1} {2};", PreVal, Operation, PostVal, Result);
        }
        public static void Ard_NetStart()
        {
            writer.WriteLine("//New Network Start ---------------");
            writer.WriteLine("dugum = true;");
        }

    }
}
