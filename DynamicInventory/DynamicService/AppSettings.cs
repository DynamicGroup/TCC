using System;
using System.IO;
using System.Web.Script.Serialization;

namespace DynamicService
{
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.jsn";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(pSettings));
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName))
                t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + fileName));
            return t;
        }
    }
}
