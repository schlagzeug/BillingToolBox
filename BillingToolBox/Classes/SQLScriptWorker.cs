using System;
using System.ComponentModel;
using System.IO;
using Microsoft.SqlServer.Management.Smo;

namespace BillingToolBox.Classes
{
    public class SQLScriptWorker
    {
        private const string BddDirectory = @"C:\Work\Products\DailyBuild\Billing\Database\BDD";
        public Server server;
        public FileInfo sqlFile;
        public volatile string statusMessage = string.Empty;

        public void RunScript(FileInfo sqlFile, Server server)
        {
            try
            {
                var script = File.ReadAllText(sqlFile.FullName);
                server.ConnectionContext.ExecuteNonQuery(script);
                statusMessage = string.Format("Success: {0}", sqlFile.FullName.Replace(BddDirectory, string.Empty));
            }
            catch (Exception exception)
            {
                statusMessage = string.Format("Error: {0}: {1}", sqlFile.FullName.Replace(BddDirectory, string.Empty), exception.InnerException);
                //statusMessage = string.Format("Error: {0}: {1} - {2}", sqlFile.FullName.Replace(BddDirectory, string.Empty), exception.Message, exception.InnerException);
            }
        }

        public void RunScript(object sender, DoWorkEventArgs e)
        {
            try
            {
                var script = File.ReadAllText(sqlFile.FullName);
                server.ConnectionContext.ExecuteNonQuery(script);
                statusMessage = string.Format("Success: {0}", sqlFile.FullName.Replace(BddDirectory, string.Empty));
                e.Result = statusMessage;
            }
            catch (Exception exception)
            {
                statusMessage = string.Format("Error: {0}: {1}", sqlFile.FullName.Replace(BddDirectory, string.Empty), exception.InnerException);
                //statusMessage = string.Format("Error: {0}: {1} - {2}", sqlFile.FullName.Replace(BddDirectory, string.Empty), exception.Message, exception.InnerException);
                e.Result = statusMessage;
            }
        }

        public void Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            Tools.ShowErrorPopUp("TestClass Running");
        }
    }
}
