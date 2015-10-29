using System.Collections.Generic;

namespace BillingToolBox.Classes
{
    class CommandsAndArgs
    {
        public Dictionary<string, List<string>> CommandTable = new Dictionary<string, List<string>>();
        private const string CMD = "CMD--";
        private const string ARG = "ARG--";

        public void PopulateCommandTable()
        {
            CommandTable = new Dictionary<string, List<string>>();

            foreach (var command in BillingToolBoxSettings.Default.CommandTable)
            {
                if (command.Contains(ARG))
                {
                    string cmd = command.Substring(0, command.IndexOf(ARG));
                    string arg = command.Substring(command.IndexOf(ARG));
                    cmd = cmd.Replace(CMD, string.Empty);
                    arg = arg.Replace(ARG, string.Empty);
                    string[] args = arg.Split(',');
                    List<string> listArgs = new List<string>(args);
                    CommandTable.Add(cmd, listArgs);
                }
                else if (command.Contains(CMD))
                {
                    string cmd = command.Replace(CMD, string.Empty);
                    CommandTable.Add(cmd, new List<string>());
                }
            }
        }

        public void SaveCommandTable()
        {
            BillingToolBoxSettings.Default.CommandTable.Clear();
            foreach (var commandSet in CommandTable)
            {
                string settingString = CMD + commandSet.Key;
                if (commandSet.Value.Count > 0)
                {
                    commandSet.Value.Sort();
                    settingString += ARG;
                    foreach (var args in commandSet.Value)
                    {
                        settingString += args + ",";
                    }
                }
                if (settingString.EndsWith(",")) 
                    settingString = settingString.TrimEnd(',');
                BillingToolBoxSettings.Default.CommandTable.Add(settingString);
            }
            BillingToolBoxSettings.Default.Save();
        }
    }
}
