using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace WindowsFormsApp1
{
    class SaveLoad
    {
        public static StreamReader reader;
        static string path;
        public static int Network_Count { get; set; }
        public static SortedDictionary<int, List<Button>> All_List;
        public static List<string> Pre_Used_Pins;


        public static void Save()    //first line is network_count, then preusedpins, then for each btn = a.desc,a.name,loc.x,loc.y,has.prl,prl.to,network
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.InitialDirectory = "Desktop";
                dialog.DefaultExt = ".lae";
                dialog.FileName = "Untitled";
                dialog.Filter = "Lae Files (*.lae)|*.lae";
                dialog.AddExtension = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("You selected: " + dialog.FileName);
                    path = dialog.FileName;
                    Form1.path = path;
                    File.Create(path).Dispose();

                    Network_Count = Form1.network_count;
                    All_List = Form1.all_list;
                    Pre_Used_Pins = Form1.Pre_Used_Pins;
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.WriteLine(Network_Count);
                        foreach (string foo in Pre_Used_Pins)
                        {
                            writer.Write(foo + ",");
                        }
                        writer.WriteLine();
                        for (int i = 1; i <= Network_Count; i++)
                        {
                            foreach (Button btn in All_List[i])
                            {
                                var Data = (ButtonInfo)btn.Tag;
                                writer.WriteLine(btn.AccessibleDescription);
                                writer.WriteLine(btn.AccessibleName);
                                writer.WriteLine(btn.Text);
                                writer.WriteLine(Data.Has_prl);

                                if (Data.Has_prl)
                                {
                                    writer.WriteLine(Data.prl_to.AccessibleDescription);
                                    writer.WriteLine(Data.prl_to.AccessibleName);
                                    writer.WriteLine(Data.prl_to.Text);
                                }
                            }
                        }
                        writer.Close();
                    }
                }
            }


        }
        public static void Pre_Load()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = "Desktop";
                dialog.Filter = "Lae Files (*.lae)|*.lae";
                dialog.AddExtension = true;
                dialog.DefaultExt = ".lae";
                dialog.CheckFileExists = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.FileName;
                }
                else { path = "x"; }
            }
            if (path == "x") { return; }
            Pre_Used_Pins = new List<string>();
            reader = new StreamReader(path);
            Form1.network_count = Convert.ToInt32(reader.ReadLine());
            foreach (string foo in reader.ReadLine().Split(','))
            {
                Pre_Used_Pins.Add(foo);
            }
            Pre_Used_Pins.RemoveAt(Pre_Used_Pins.Count - 1);
            Form1.Pre_Used_Pins = Pre_Used_Pins;

            reader.Close();
        }

        public static string Init_Load()
        {

            using (StreamReader reader = new StreamReader(path))
            {
                Network_Count = Convert.ToInt32(reader.ReadLine());
                reader.ReadLine();
                All_List = Form1.all_list;
                return path;
            }
        }

    }
}   

