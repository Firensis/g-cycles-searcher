using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Workers.Visual
{
    partial class VisualManager
    {
        public static class DOTVisualizer
        {
            private const string DOT_EXE_PATH = @".\external\dot.exe";
            private const string TEMP_FILENAME = @".\external\tempgraph";



            public static Image GetImageFromDOT(string dotString)
            {
                File.WriteAllText(TEMP_FILENAME, dotString);

                Process process = GetProcess();

                process.StartInfo.FileName = DOT_EXE_PATH;
                process.StartInfo.Arguments = $"{TEMP_FILENAME} -Tjpg -O";

                process.Start();
                process.WaitForExit();
                Stream bmpStream = File.Open(TEMP_FILENAME + ".jpg", FileMode.Open);

                Image result = Image.FromStream(bmpStream);

                bmpStream.Close();

                File.Delete(TEMP_FILENAME);
                File.Delete(TEMP_FILENAME + ".jpg");

                return result;
            }

            private static Process GetProcess()
            {
                Process process = new Process();

                // Stop the process from opening a new window
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                return process;
            }
        }

    }
}
