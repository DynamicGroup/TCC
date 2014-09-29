using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    public static class DataValue
    {
        public static object GetDataValue(this object value)
        {
            if (value == null)
            {
                return DBNull.Value;
            }

            if (value is ushort)
            {
                return unchecked((short)(ushort)value);
            }

            if (value is uint)
            {
                return unchecked((int)(uint)value);
            }

            if (value is ulong)
            {
                return unchecked((long)(ulong)value);
            }

            if (value is sbyte)
            {
                return unchecked((byte)(sbyte)value);
            }

            return value;
        }
    }
}
