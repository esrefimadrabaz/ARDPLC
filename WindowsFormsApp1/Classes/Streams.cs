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
            writer.WriteLine("#define deneme.h");
            writer.WriteLine("#include wire.h");
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
                    writer.WriteLine("int {0};", pins);
                }
                else if (pins.Substring(0,3) == "TON")
                {
                    writer.WriteLine("int TON{0};", pins.Substring(3));
                }
                else if (pins.Substring(0, 4) == "TOFF")
                {
                    writer.WriteLine("int TOFF{0};", pins.Substring(4));
                }
            }
            writer.WriteLine("//End Of Declaration ----------------");
            writer.WriteLine("void setup() {");

            foreach (string pins in Form1.Used_Pins)
            {
                if (pins[0] == 'I')
                {
                    writer.WriteLine("pinMode(I{0}, INPUT;)", pins[1]);
                }
                else if (pins[0] == 'O')
                {
                    writer.WriteLine("pinMode(O{0}, OUTPUT;)", pins[1]);
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
        public static void Ard_NetStart()
        {
            writer.WriteLine("//New Network Start ---------------");
            writer.WriteLine("dugum = true;");
        }

    }
}
