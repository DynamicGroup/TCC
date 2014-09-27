using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;

namespace DynamicService
{
    static class CimConvert
    {
        private readonly static IDictionary<CimType, Type> Cim2TypeTable = new Dictionary<CimType, Type>
        {
            {CimType.Boolean, typeof (bool)},
            {CimType.Char16, typeof (string)},
            {CimType.DateTime, typeof (DateTime)},
            {CimType.Object, typeof (object)},
            {CimType.Real32, typeof (decimal)},
            {CimType.Real64, typeof (decimal)},
            {CimType.Reference, typeof (object)},
            {CimType.SInt16, typeof (short)},
            {CimType.SInt32, typeof (int)},
            {CimType.SInt8, typeof (sbyte)},
            {CimType.String, typeof (string)},
            {CimType.UInt8, typeof (byte)},
            {CimType.UInt16, typeof (ushort)},
            {CimType.UInt32, typeof (uint)},
            {CimType.UInt64, typeof (ulong)},
            {CimType.SInt64, typeof (long)}
        };

        public static Type Cim2SystemType(this PropertyData data)
        {
            Type type = null;
            try
            {
                type = Cim2TypeTable[data.Type];
                return type;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return type;
            }
        }

        public static object Cim2SystemValue(this PropertyData data)
        {
            object obj = new object();
            string campo = String.Empty;
            try
            {
                campo = string.Format("Campo: {0}", data.Name);
                if (data.Type == CimType.DateTime)
                {
                    obj = ManagementDateTimeConverter.ToDateTime(data.Value.ToString());
                }
                else if (data.IsArray)
                {
                    var strings = ((IEnumerable)data.Value).Cast<object>().Select(x => x == null ? x : x.ToString()).ToArray();
                    obj = ConvertArr(strings, Cim2SystemType(data));
                }
                else
                {
                    obj = Convert.ChangeType(data.Value, Cim2SystemType(data));
                }

                return obj;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(campo + e.Message + e.StackTrace);
                return obj;
            }
        }

        private static Array ConvertArr(this object[] arr, Type type)
        {
            Array array = Array.CreateInstance(type, arr.Length);
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    array.SetValue(Convert.ChangeType(arr[i], type), i);
                }
                return array;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return array;
            }
        }
    }
}
