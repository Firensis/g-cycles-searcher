using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCyclesSearcher.Forms
{
    static class FormsSystem
    {
        private static Form Current { get; set; }
        private static bool inited = false;
        private static bool formChanging = false;

        public static void Init()
        {
            if (inited)
            {
                throw new Exception("Прдпринята попытка повторной инициализации!");
            }
            inited = true;
            Current = new Authorization();
            ShowForm(Current);
        }


        public static void ChangeForm(Form changeTo)
        {
            ShowForm(changeTo);
            ChangeCurrent(changeTo);
        }

        private static void ShowForm(Form toShow)
        {
            toShow.FormClosed += OnFormClosed;
            toShow.Show();
        }

        private static void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!formChanging)
            {
                Application.Exit();
            }
        }

        private static void ChangeCurrent(Form toChange)
        {
            formChanging = true;
            Current.Close();
            formChanging = false;
            Current = toChange;
        }
    }
}
