﻿using System.Diagnostics;

namespace MentalCrash
{
    public static class ItemChecks
    {
        public static string detectType(string data)
        {
            if (IsString(data) == true)
            {
                return "str";
            }
            else if (IsInt(data) == true)
            {
                return "int";
            }
            else if (IsDouble(data) == true)
            {
                return "int"; //since int and doubles are same in this language
            }
            else if (IsCommand(data) == true)
            {
                return "cmd";
            }
            else if (IsBoolean(data) == true)
            {
                return "bool";
            }
            //IsVariable(data);
            return "";
        }
        public static bool IsString(object data)
        {
            try
            {
                string firstElement = data.ToString();
                bool startsWithQuote = firstElement.StartsWith("\"");
                bool endsWithQuote = firstElement.EndsWith("\"");
                bool containsEscapedQuotes = false;
                if (firstElement.Length > 2)
                {
                    string substring = firstElement.Substring(1, firstElement.Length - 2);
                    containsEscapedQuotes = substring.Contains("\"");
                }

                if (startsWithQuote && endsWithQuote && !containsEscapedQuotes)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        public static bool IsCommand(object data)
        {
            return data.ToString().StartsWith(":") && !(data.ToString().StartsWith(": "));
        }
        public static bool IsBoolean(object data)
        {
            return bool.TryParse((string?)data, out _);
        }
        public static bool IsVariable(object data, List<string> variables)
        {
            var foundItem = variables.FirstOrDefault(item => item.StartsWith(data.ToString()));
            if (foundItem != null)
            {
                return true;
            }
            return false;
        }
        public static bool IsInt(object data)
        {
            try
            {
                if (int.TryParse(data.ToString(), out _) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool IsDouble(string data)
        {
            try
            {
                if (double.TryParse(data, out _) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
