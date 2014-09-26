using System;
using System.Collections.Generic;
using System.Management;
using System.Reflection;
using System.Linq;

namespace DynamicService
{
    class WmiHelper
    {
        public static IEnumerable<T> WmiSnapshot<T>(string query = "")
        {
            ManagementObjectSearcher searcher = null;

            if (query == String.Empty)
            {
                searcher = new ManagementObjectSearcher(new SelectQuery(Activator.CreateInstance<T>().GetType().Name));
            }
            else
            {
                searcher = new ManagementObjectSearcher(query);
            }

            List<string> properties = new List<string>();

            foreach (ManagementObject managementObject in searcher.Get())
            {
                if (properties.Count == 0)
                {
                    foreach (PropertyData property in managementObject.Properties)
                    {
                        properties.Add(property.Name);
                    }
                }

                var listItem = Activator.CreateInstance<T>();
                var fields = listItem.GetType().GetFields();

                foreach (FieldInfo field in fields)
                {
                    if (properties.Contains(field.Name, StringComparer.OrdinalIgnoreCase))
                    {
                        if (managementObject[field.Name] != null)
                        {
                            field.SetValue(listItem, CimConvert.Cim2SystemValue(managementObject.Properties[field.Name]));
                        }
                    }
                }

                yield return listItem;
            }
        }
    }
}
