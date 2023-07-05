using System.Diagnostics;

namespace MentalCrash
{
    public static class ItemChecks
    {
        public static bool IsString(string data)
        {
            try
            {
                string firstElement = data;
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
        public static bool IsBoolean(object data)
        {
            return bool.TryParse((string?)data, out _);
        }
        public static bool IsInt(string data)
        {
            try
            {
                if (int.TryParse(data, out _) == true)
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
