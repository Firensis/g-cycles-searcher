using GCyclesSearcher.Forms;
using GCyclesSearcher.Models;
using GCyclesSearcher.Users;
using GCyclesSearcher.Workers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCyclesSearcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UsersSystem.Init();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormsSystem.Init();
            Application.Run();
        }


        public static string Join(IEnumerable collection, string separator="")
        {
            string result = "";
            IEnumerator enumer =  collection.GetEnumerator();

            if (!enumer.MoveNext())
            {
                return result;
            }

            result += enumer.Current.ToString();


            while (enumer.MoveNext()) {
                result += separator + enumer.Current;
            }

            return result;
        }
    }
}
