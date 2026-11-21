using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_4
{
    /// <summary>
    /// AppContext is an internal class that refers to how the application handles closing and the form's main "head".
    /// </summary>
    /// 
    /// <remarks>
    /// This is based off the idea of passing the "head" along to the next form to ensure it doesnt either terminate early
    /// or never terminate and is the first time I've utilized it before.
    /// </remarks>
    internal class AppContext : ApplicationContext
    {
        /// <value>Property <c>Lazy</c> delays the intial intiliazation until it is needed, functioning as a stopper until the new form is loaded</value>
        private static Lazy<AppContext> Lazy = new Lazy<AppContext>(() => new AppContext());
        /// <value>Property <c>Current</c> represents current "head" of the application.</value>
        public static AppContext Current => Lazy.Value;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AppContext() { }

        /// <summary>
        /// Binds the close function to newly created forms and then displays it.
        /// </summary>
        /// <param name="form">Input form to show</param>
        public void ShowForm(Form form)
        {
            //Bind OnFormClosed function to event FormClosed
            form.FormClosed += OnFormClosed;

            //Display the new form
            form.Show();
        }

        /// <summary>
        /// Checks if there any open forms within context and if there is not then it exits the application by
        /// leaving the thread currently running letting cleanup occur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormClosed(object sender, EventArgs e)
        {
            //Check forms open
            if (Application.OpenForms.Count <= 0)
            {
                ExitThread();
            }
        }
    }
}
