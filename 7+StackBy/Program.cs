using System;
using System.IO;
using System.Windows.Forms;

namespace Win7_Plus_StackBy
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                string path = args[0];

                if (Directory.Exists(path))
                {
                    Application.Run(new StackbyGen(path));
                    return;
                }

            }

            Application.Run(new StackbyGen());


        }
    }
}
