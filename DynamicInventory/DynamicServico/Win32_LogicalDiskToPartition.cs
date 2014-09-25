using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    class Win32_LogicalDiskToPartition
    {
        public string Antecedent;
        public string Dependent;
        public ulong EndingAddress;
        public ulong StartingAddress;

        public Win32_LogicalDiskToPartition()
        {

        }
    }
}
