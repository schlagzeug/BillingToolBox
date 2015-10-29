using System.ComponentModel;
using System.Threading;

namespace BillingToolBox.Classes
{
    public class TestClass
    {
        public TestClass()
        {
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            //while (true)
            //{
                Thread.Sleep(1000);
            //}
        }

        public void Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            Tools.ShowErrorPopUp("TestClass Running");
        }
    }
}
