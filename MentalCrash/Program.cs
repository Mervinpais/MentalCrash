#pragma warning disable IDE0057 // Use range operator
#pragma warning disable IDE0090 // Use 'new(...)'
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
                Console.WriteLine("\n-====INTERPERATOR====-\n");
            }
            while (true)
            {
                Console.Write(">");
                string line = Console.ReadLine();
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

        public static object Interperator(string command, List<string> args_list, out object output)
        {
            int total_length = command.ToCharArray().Length;
            int current_cycle = 0;
            foreach (char c in command)
            {
                if (c == ' ' || c == '\n')
                {
                    continue;
                }
                if (c == 'p')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    Console.WriteLine(args_list[0]);
                    args_list.RemoveAt(0);
                    continue;
                }
                else if (c == 'i')
                {
                    Console.Write("input>");
                    string input = Console.ReadLine();
                    int inputLength = input.Length;
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    Console.Write(new string(' ', inputLength + 7));
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(input);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine("\n");
                    output = input;
                }
                else if (c == 'f')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    string func_name = "";
                    string func_code = "";
                    try
                    {
                        func_name = args_list[0].Trim();
                        func_code = args_list[1];
                    }
                    catch
                    { }
                    string foundItem = functions.FirstOrDefault(item => item.StartsWith(func_name + ">"));
                    if (foundItem != null)
                    {
                        int index = functions.IndexOf(foundItem);
                        List<string> arg_lists = new(foundItem.Substring(func_name.Length + 2).Split("|"));
                        string commands = arg_lists[0].Split(" ")[0];
                        string arguments = arg_lists[0].Substring(commands.Length + 1);
                        Interperator(commands, new List<string>(arguments.Split("|")), out _);
                    }
                    else
                    {
                        functions.Add(func_name + "> " + func_code);
                    }
                }
                if (c == 'V')
                {
                    if (args_list.Count == 0)
                    {
                        Console.WriteLine("Error; No Data Left In Tape, " + current_cycle.ToString() + " out of " + total_length.ToString() + " commands have been processed, fix the error and re-run the program");
                        break;
                    }
                    string var_name = "";
                    string var_code = "";
                    try
                    {
                        var_name = args_list[0].Trim();
                        var_code = args_list[1];
                    }
                    catch
                    { }
                    string foundItem = variables.FirstOrDefault(item => item.StartsWith(var_name + ">"));
                    if (foundItem != null)
                    {
                        int index = variables.IndexOf(foundItem);
                        Console.WriteLine(variables[index].Substring((var_name + "> ").Length));
                    }
                    else
                    {
                        if (var_code.StartsWith(":"))
                        {
                            variables.Add(var_name + "> " + Convert.ToString(Interperator(var_code, null, out _)));
                        }
                        else
                        {
                            variables.Add(var_name + "> " + var_code);
                        }
                    }
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
                        condition = args_list[0].Trim();
                        ifTrueCode = args_list[1];
                        ifFalseCode = args_list[2];
                    }
                    catch
                    { }
                    List<string> ifTrueCodeL = new List<string>(ifTrueCode.Split(" "));
                    List<string> ifFalseCodeL = new List<string>(ifFalseCode.Split(" "));
                    ifTrueCodeL.RemoveAt(0);
                    ifFalseCodeL.RemoveAt(0);

                    string LHS_condition = condition.Split(" ")[0];
                    string RHS_condition = condition.Split(" ")[2];
                    string Operator = condition.Split(" ")[1];

                    if (LHS_condition.StartsWith(":"))
                    {
                        LHS_condition = Convert.ToString(Interperator(LHS_condition, null, out _));
                    }
                    if (Operator == "==")
                    {
                        if (string.Equals(LHS_condition, RHS_condition))
                        {
                            Interperator(ifTrueCode.Split(" ")[0], ifTrueCodeL, out _);
                        }
                        else
                        {
                            Interperator(ifFalseCode.Split(" ")[0], ifFalseCodeL, out _);
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
            return null;
        }
    }
}