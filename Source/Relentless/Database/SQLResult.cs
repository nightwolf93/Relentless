﻿using System;
using System.Data;
using System.Globalization;

namespace Relentless.Database
{
    public class SQLResult : DataTable
    {
        public int Count { get; set; }

        public T Read<T>(int row, string columnName, int number = 0)
        {
            checked
            {
                var val = Rows[row][columnName + (number != 0 ? (1 + number).ToString(CultureInfo.GetCultureInfo("en-US")) : "")];

                if (typeof(T).IsEnum)
                {
                    return (T)Enum.ToObject(typeof(T), val);
                }

                return (T)Convert.ChangeType(val, typeof(T), CultureInfo.GetCultureInfo("en-US"));
            }
        }

        public object[] ReadAllValuesFromField(string columnName)
        {
            object[] obj = new object[Count];

            for (int i = 0; i < Count; i++)
            {
                obj[i] = Rows[i][columnName];
            }

            return obj;
        }
    }
}
