#pragma warning disable IDE0057 // Use range operator
#pragma warning disable IDE0090 // Use 'new(...)'
#nullable disable

using System.Diagnostics;

namespace MentalCrash
{
    public class Program
    {
        public static List<string> functions = new List<string>();
        public static List<string> variables = new List<string>();
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                if (File.Exists(args[0]))
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    foreach (string line in lines)
                    {
                        if (line == null || line == "") continue;
                        string command;
                        string arguments = "";
                        List<string> args_list = new List<string>();
                        if (line.Contains(' '))
                        {
                            command = line.Split(" ")[0];
                            int isFirst = -1;
                            foreach (string e in line.Split(" "))
                            {
                                isFirst++;
                                if (isFirst == 0) continue;
                                arguments += e + " ";

                            }
                            args_list.AddRange(arguments.Split("|"));
                        }
                        else
                        {
                            command = line;
                            //args_list.Add("<null>");
                        }
                        Interperator(command, args_list, out _);
                    }
                }
                else
                {
                    string command;
                    string arguments = "";
                    List<string> args_list = new List<string>();
                    if (string.Join(' ', args).Contains(' '))
                    {
                        command = string.Join(' ', args).Split(" ")[0];
                        int isFirst = -1;
                        foreach (string e in string.Join(' ', args).Split(" "))
                        {
                            isFirst++;
                            if (isFirst == 0) continue;
                            arguments += e + " ";

                        }
                        args_list.AddRange(arguments.Split("|"));
                    }
                    else
                    {
                        command = string.Join(' ', args);
                    }
                    Interperator(command, args_list, out _);
                }
            }
            Console.WriteLine("\n═══INTERPERATOR═══\n");
            while (true)
            {
                Console.Write(">");
                string line = Console.ReadLine();
                string command;
                string arguments = "";
                List<string> args_list = new List<string>();
                if (line == null || line == "") { continue; }
                if (line != null)
                {
                    if (line.Contains(' '))
                    {
                        command = line.Split(" ")[0];
                        int isFirst = -1;
                        foreach (string e in line.Split(" "))
                        {
                            isFirst++;
                            if (isFirst == 0) continue;
                            arguments += e + " ";

                        }
                        args_list.AddRange(arguments.Split("|"));
                    }
                    else
                    {
                        command = line;
                        //args_list.Add("<null>");
                    }
                    Interperator(command, args_list, out _);
                }
            }
        }

        public static object Interperator(string command, List<string> args_list, out object output)
        {
            List<string> cleanedOut = new List<string>(args_list);
            args_list.Clear();
            foreach (string item in cleanedOut)
            {
                args_list.Add(item.TrimStart().TrimEnd());
            }
            int total_length = command.ToCharArray().Length;
            int current_cycle = 0;

            // Start of execution
            foreach (char c in command)
            {
                if (c == ' ' || c == '\n')
                {
                    continue;
                }
                else if (c == '!' && command == "!")
                {
                    string line = command + " " + string.Join(" ", args_list.ToArray());
                    output = null;
                    return null;
                }
                else if (c == 'w') //with x, its like the using directive
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }

                    string fileName = args_list[0];
                    if (!ItemChecks.IsString(fileName))
                    {
                        Console.WriteLine($"Error; Not a valid string");
                        continue;
                    }
                    else
                    {
                        string substring = args_list[0].Substring(1, args_list[0].Length - 2);
                        string cleanedString = substring.Replace("\"\"", "\"");
                        fileName = cleanedString;
                    }

                    if (!File.Exists(fileName))
                    {
                        Console.WriteLine($"Error; File doesnt exist \'{fileName}\'");
                        continue;
                    }
                    foreach (string line in File.ReadAllLines(fileName))
                    {
                        if (line == null || line == "") continue;
                        string command1;
                        string arguments = "";
                        List<string> args_list1 = new List<string>();
                        if (line.Contains(' '))
                        {
                            command1 = line.Split(" ")[0];
                            int isFirst = -1;
                            foreach (string e in line.Split(" "))
                            {
                                isFirst++;
                                if (isFirst == 0) continue;
                                arguments += e + " ";

                            }
                            args_list1.AddRange(arguments.Split("|"));
                        }
                        else
                        {
                            command1 = line;
                            //args_list.Add("<null>");
                        }
                        Interperator(command1, args_list1, out _);
                    }
                }
                if (c == 'p')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }

                    if (ItemChecks.IsString(args_list[0]))
                    {
                        string substring = args_list[0].Substring(1, args_list[0].Length - 2);
                        string cleanedString = substring.Replace("\"\"", "\"");
                        Console.WriteLine(cleanedString);
                    }
                    else if (ItemChecks.IsInt(args_list[0]))
                    {
                        Console.WriteLine(args_list[0]);
                    }
                    string foundItem = variables.FirstOrDefault(item => item.StartsWith(args_list[0]));
                    if (foundItem != null)
                    {
                        string varData = foundItem.Substring(foundItem.IndexOf('>') + 1).Trim();
                        if (ItemChecks.IsString(varData))
                        {
                            varData = varData.Substring(1, varData.Length - 2);
                        }
                        Console.WriteLine(varData);
                    }

                    args_list.RemoveAt(0);
                    current_cycle++;
                    continue;
                }
                else if (c == 'i')
                {
                    if (args_list.Count > 0)
                    {
                        string line = args_list[0];
                        string message = line;
                        int style = 0;
                        int type = 1; //Default
                        if (line.Contains("[") & line.Contains("]"))
                        {
                            message = line.Substring(0, line.IndexOf("["));
                            type = Convert.ToInt32(line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1));
                        }
                        if (line.Contains("(") & line.Contains(")"))
                        {
                            style = Convert.ToInt32(line.Substring(line.IndexOf("(") + 1, line.IndexOf(")") - line.IndexOf("(") - 1));
                        }
                        message = message.Trim();

                        if (type == 0) ; //Nothing Lol
                        else if (type == 1) Console.Write($"{message}");
                        else if (type == 2) Console.Write($"{message}\n");
                        else break;

                        if (style == 0) ; //Nothing Lol
                        else if (style == 1) Console.Write($">");
                        else if (style == 2) Console.Write($">>>");
                        else if (style == 3) Console.Write($":");
                        else if (style == 4) Console.Write($":>");
                        else if (style == 5) Console.Write($":>>>");
                        else if (style == 6) Console.Write($"$");
                        else if (style == 7) Console.Write($"$:");
                        else if (style == 8) Console.Write($"-");
                        else break;

                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("input>");
                    }
                    string input = Console.ReadLine();
                    int inputLength = input.Length;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', inputLength + 7 + 10));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(input);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("\n");
                    output = input;
                    args_list.RemoveAt(0);
                    return input;
                }
                else if (c == 'F')
                {
                    /*
                     FORMAT;
                        Declaring;
                            F <functionName> [<typeOfVariable> <nameOfVariable, ...] (<command> <arguments>)
                        Invoking;
                            F <functionName> [<typeOfVariable> <nameOfVariable, ...] (<value1>, <value2>, ...)
                     */
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error: No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed. Fix the error and re-run the program.");
                        break;
                    }
                    string line = args_list[0].Trim();
                    string func_name = "";
                    string func_params = "";
                    string func_code = "";

                    bool paramsAvailable = false;
                    try
                    {
                        func_name = line.Substring(0, line.IndexOf('['));
                        func_params = line.Substring(line.IndexOf('['), line.IndexOf(']') - line.IndexOf('[') + 1);
                        func_code = line.Substring(line.IndexOf('('), line.IndexOf(')') - line.IndexOf('(') + 1);
                        paramsAvailable = true;
                    }
                    catch
                    {
                        func_name = line.Substring(0, line.IndexOf('('));
                        func_code = line.Substring(line.IndexOf('('), line.IndexOf(')') - line.IndexOf('(') + 1);
                        Debug.WriteLine($"Function \'{func_name}\' doesn't need parameters.");
                    }

                    func_name = func_name.Trim();
                    func_code = func_code.Trim();
                    func_params = func_params.Trim();

                    func_code = func_code.Substring(1, func_code.Length - 2);
                    if (paramsAvailable)
                    {
                        func_params = func_params.Substring(1, func_params.Length - 2);
                    }

                    string foundItem = functions.FirstOrDefault(item => item.StartsWith(func_name + $" [{func_params}] " + ">"));
                    if (foundItem != null)
                    {
                        int index = functions.IndexOf(foundItem);
                        List<string> arg_lists = new List<string>(
                            foundItem.Substring(func_name.Length + func_params.Length + 6).Split(",")
                            );
                        string commands = arg_lists[0].Split(" ")[0];
                        string arguments = arg_lists[0].Substring(commands.Length + 1);

                        for (int i = 1; i < arg_lists.Count; i++)
                        {
                            arguments = arguments + "|" + arg_lists[i];
                        }
                        List<string> argumentsList = new List<string>();
                        if (func_code != null && paramsAvailable)
                        {
                            for (int i = 0; i < arg_lists.Count; i++)
                            {
                                commands = "V" + commands;
                            }
                            bool error = false;
                            for (int i = 0; i < arg_lists.Count; i++)
                            {
                                //argumentsList.Add(func_params.Split(',')[i] + "|" + func_code.Split(',')[i]);
                                argumentsList.Add(func_params.Split(',')[i].Trim());
                                try
                                {
                                    argumentsList.Add(func_code.Split(',')[i].Trim());
                                }
                                catch //If there is no value for a param
                                {
                                    Console.WriteLine($"Error; Value for param \'{func_params.Split(',')[i].Trim()}\' is Missing, all params must be set to a value if the function is invoked");
                                    error = true;
                                    break;
                                }
                            }
                            if (error)
                            {
                                break;
                            }
                        }
                        Debug.WriteLine(arguments);
                        Debug.WriteLine("\n" + commands);
                        output = "";
                        return Interperator(commands, argumentsList, out _);
                    }
                    else
                    {
                        functions.Add(func_name + $" [{func_params}] " + "> " + func_code);
                    }
                }

                if (c == 'V')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    string var_type = "";
                    string var_name = "";
                    string var_code = "";
                    try
                    {
                        var_type = args_list[0].Trim().Split(" ")[0];
                        var_name = args_list[0].Trim().Split(" ")[1];
                        var_code = args_list[1];
                    }
                    catch
                    { }
                    if (var_code != "")
                    {
                        if (var_type == "str")
                        {
                            if (!ItemChecks.IsString(var_code))
                            {
                                Console.WriteLine("Error: Not a string");
                                continue;
                            }
                        }
                        else if (var_type == "int")
                        {
                            if (!ItemChecks.IsInt(var_code))
                            {
                                Console.WriteLine("Error: Not an Int");
                                continue;
                            }
                        }
                    }
                    string foundItem = variables.FirstOrDefault(item => item.StartsWith(var_name + ">"));
                    if (foundItem != null)
                    {
                        variables.Remove(foundItem);
                    }
                    if (var_code.StartsWith(":"))
                    {
                        variables.Add(var_name + " (" + var_type + ")> " + Convert.ToString(Interperator(var_code, null, out _)));
                    }
                    else
                    {
                        variables.Add(var_name + " (" + var_type + ")> " + var_code);
                    }
                    args_list.RemoveRange(0, 2);
                    string Item2 = args_list[0];
                    string Item2_data = "";
                    try
                    {
                        if (args_list.Count > 1)
                        {
                            Item2_data = args_list[1];
                        }
                        else
                        {
                            Item2_data = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        Item2_data = "";
                    }
                    List<string> restOfArgs = new();
                    for (int i = 2; i < args_list.Count; i++)
                    {
                        string item = args_list[i];
                        restOfArgs.Add(item);
                    }
                    args_list.Clear();
                    args_list.Add(Item2);
                    if (Item2_data != "")
                    {
                        args_list.Add(Item2_data);
                    }
                    args_list.Add(var_name);
                    args_list.AddRange(restOfArgs);
                }
                if (c == 'I')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    string condition = "";
                    string ifTrueCode = "";
                    string ifFalseCode = "";

                    try
                    {
                        string firstElement = args_list[0];
                        string substring = firstElement.Substring(1, firstElement.Length - 2);
                        bool startsWithQuote = firstElement.StartsWith("[");
                        bool endsWithQuote = firstElement.EndsWith("]");
                        bool containsEscapedQuotes = substring.Contains("[");
                        bool containsEscapedQuotes2 = substring.Contains("]");

                        if (startsWithQuote && endsWithQuote &&
                            !(containsEscapedQuotes && containsEscapedQuotes2) ||
                            !(containsEscapedQuotes || containsEscapedQuotes2))
                        {
                            string ifBlock = substring;
                            if (!substring.Contains(','))
                            {
                                condition = ifBlock;
                            }
                            else
                            {
                                condition = ifBlock.Split(',')[0];
                                ifTrueCode = ifBlock.Split(',')[1];
                                ifFalseCode = ifBlock.Split(',')[2];
                            }
                        }
                    }
                    catch
                    { }
                    List<string> ifTrueCodeL = new List<string>(ifTrueCode.Split(" ")[1..]);
                    List<string> ifFalseCodeL = new List<string>(ifFalseCode.Split(" ")[1..]);
                    ifTrueCodeL.RemoveAt(0);
                    ifFalseCodeL.RemoveAt(0);

                    string LHS_condition = condition.Split(" ")[0];
                    string RHS_condition = condition.Split(" ")[2];
                    string Operator = condition.Split(" ")[1];

                    if (LHS_condition.StartsWith(":"))
                    {
                        LHS_condition = Convert.ToString(Interperator(LHS_condition.Substring(1), new List<string>(new string[] { " " }), out _));
                    }
                    if (Operator == "==")
                    {
                        if (string.Equals(LHS_condition, RHS_condition))
                        {
                            Interperator(ifTrueCode.Trim().Split(" ")[0], ifTrueCodeL, out _);
                        }
                        else
                        {
                            Interperator(ifFalseCode.Trim().Split(" ")[0], ifFalseCodeL, out _);
                        }
                    }
                    else if (Operator == "!=")
                    {
                        if (!string.Equals(LHS_condition, RHS_condition))
                        {
                            Interperator(ifTrueCode.Split(" ")[0], ifTrueCodeL, out _);
                        }
                        else
                        {
                            Interperator(ifFalseCode.Split(" ")[0], ifFalseCodeL, out _);
                        }
                    }
                    args_list.RemoveAt(0);
                }
                if (c == 'a' || c == 's' || c == 'm' || c == 'd')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    if (!args_list[0].StartsWith("[") && !args_list[0].EndsWith("]"))
                    {
                        Console.WriteLine("Error; Data not valid");
                        break;
                    }
                    string data = args_list[0].TrimEnd().TrimStart();
                    data = data.Substring(1, data.Length - 2);
                    List<double> numbers = new List<double>();

                    if (c == 'a')
                    {
                        foreach (string e in data.Split(","))
                        {
                            numbers.Add(Convert.ToDouble(e.Trim()));
                        }
                        double sum = 0;
                        foreach (double n in numbers)
                        {
                            sum += n;
                        }
                        Console.WriteLine(sum);
                        args_list.RemoveAt(0);
                    }
                    else if (c == 's')
                    {
                        int count = 0;
                        foreach (string e in data.Split(","))
                        {
                            if (count == 0)
                            {
                                count++; continue;
                            }
                            numbers.Add(Convert.ToDouble(e.Trim()));
                            count++;
                        }
                        double difference = Convert.ToDouble(data.Split(",")[0]);
                        foreach (double n in numbers)
                        {
                            difference -= n;
                        }
                        Console.WriteLine(difference);
                        args_list.RemoveAt(0);
                    }
                    else if (c == 'm')
                    {
                        int count = 0;
                        foreach (string e in data.Split(","))
                        {
                            if (count == 0)
                            {
                                count++; continue;
                            }
                            numbers.Add(Convert.ToDouble(e.Trim()));
                            count++;
                        }
                        double product = Convert.ToDouble(data.Split(",")[0]);
                        foreach (double n in numbers)
                        {
                            product *= n;
                        }
                        Console.WriteLine(product);
                        args_list.RemoveAt(0);
                    }
                    else if (c == 'd')
                    {
                        int count = 0;
                        foreach (string e in data.Split(","))
                        {
                            if (count == 0)
                            {
                                count++; continue;
                            }
                            numbers.Add(Convert.ToDouble(e.Trim()));
                            count++;
                        }
                        double quotient = Convert.ToDouble(data.Split(",")[0]);
                        foreach (double n in numbers)
                        {
                            try
                            {
                                quotient /= n;
                            }
                            catch (DivideByZeroException)
                            {
                                Console.WriteLine("Error; You cant divide by Zero");
                                break;
                            }
                        }
                        Console.WriteLine(quotient);
                        args_list.RemoveAt(0);
                    }
                }
                else if (c == '.')
                {
                    current_cycle++; //Because the '.' doesnt automatically increment the current_cycle variable, cause the program closes before updating
                    if (current_cycle < total_length)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Warning: The program has been terminated at cycle " + current_cycle + " with the command \'.\',Only " + current_cycle + " out of " + total_length + " have been executed.");
                    }
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Program Exited Successfully");
                    Console.ResetColor();
                    Environment.Exit(-1);
                }
                current_cycle++;
            }
            output = "";
            return "";
        }
    }
}