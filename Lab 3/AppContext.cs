using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    internal class AppContext : ApplicationContext
    {
        private static Lazy<AppContext> Lazy = new Lazy<AppContext>(() => new AppContext());
        public static AppContext Current => Lazy.Value;

        public AppContext() { }

        public void ShowForm(Form form)
        {
            form.FormClosed += OnFormClosed;
            form.Show();
        }

        private void OnFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count <= 0)
            {
                ExitThread();
            }
        }
    }
}
