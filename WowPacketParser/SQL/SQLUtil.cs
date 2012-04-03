﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace WowPacketParser.SQL
{
    public static class SQLUtil
    {
        public const string CommaSeparator = ", ";

        public static string AddBackQuotes(string str)
        {
            return "`" + str + "`";
        }

        public static string AddQuotes(string str)
        {
            return "'" + str + "'";
        }

        /// <summary>
        /// Escapes a SQL string
        /// </summary>
        public static string EscapeString(string str)
        {
            str = str.Replace("'", "''");
            str = str.Replace("\"", "\\\"");
            return str;
        }

        /// <summary>
        /// Replaces the last entry of a given character by some other char
        /// Useful when replacing comma by semicolon
        /// </summary>
        /// <param name="str"></param>
        /// <param name="oldChar"></param>
        /// <param name="newChar"></param>
        /// <returns></returns>
        public static StringBuilder ReplaceLast(this StringBuilder str, char oldChar, char newChar)
        {
            for (int i = str.Length - 1; i > 0; i--)
                if (str[i] == oldChar)
                {
                    str[i] = newChar;
                    break;
                }
            return str;
        }

        /// <summary>
        /// Escapes and quotes a string
        /// </summary>
        public static string Stringify(object str)
        {
            if (str == null)
                str = String.Empty;
            return AddQuotes(EscapeString(str.ToString()));
        }

        /// <summary>
        /// Converts an int to a hex string.
        /// </summary>
        public static string Hexify(int n)
        {
            return "0x" + n.ToString("X");
        }

        /// <summary>
        /// Converts an uint to a hex string.
        /// </summary>
        public static string Hexify(uint n)
        {
            return "0x" + n.ToString("X");
        }

        /// <summary>
        /// "Modifies" any value to be used in SQL data
        /// </summary>
        /// <param name="value">Any value (string, number, enum, ...)</param>
        /// <param name="isFlag">If set to true the value, "0x" will be append to value</param>
        /// <param name="noQuotes">If value is a string and this is set to true, value will not be 'quoted' (SQL variables)</param>
        /// <returns></returns>
        public static object ToSQLValue(object value, bool isFlag = false, bool noQuotes = false)
        {
            //if (value == null)
            //    return value; // mhmmm

            if (value is string && !noQuotes)
                value = Stringify(value);

            if (value is bool)
                value = value.Equals(true) ? 1 : 0;

            if (value is Enum) // A bit hackish but oh well...
            {
                try
                {
// ReSharper disable PossibleInvalidCastException
                    value = (uint)value;
// ReSharper restore PossibleInvalidCastException
                }
                catch (InvalidCastException)
                {
                    value = (int)value;
                }
            }

            if (value is int && isFlag)
                value = Hexify((int)value);

            if (value is uint && isFlag)
                value = Hexify((uint)value);

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Query result</param>
        /// <returns></returns>
        public static Dictionary<T, object> ToDict<T>(this MySqlDataReader data)
        {
            //var pkType = data.GetFieldType(0);
            var dict = new Dictionary<T, object>();

            var objs = new object[20];
            int quant = data.GetValues(objs);

            for (int i = 0; i < quant; i++)
            {
                Console.WriteLine(objs[i]);
            }

            return dict;
        }
    }
}
