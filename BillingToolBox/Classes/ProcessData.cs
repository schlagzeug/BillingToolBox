using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Management;

namespace BillingToolBox.Classes
{
    public class ProcessData : IComparable<ProcessData>
    {
        public ProcessData(Process x)
        {
            ID = x.Id;
            ProcessName = x.ProcessName;
            Location = Tools.GetMainModuleFilepath(ID);
            Description = Tools.GetFileVersionDescription(Location);
        }

        public int ID { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public int CompareTo(ProcessData other)
        {
            return string.Compare(this.ProcessName, other.ProcessName);
        }
    }
}
