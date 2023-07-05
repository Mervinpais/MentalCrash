namespace MentalCrash
{
    public static class ErrorHandler
    {
        public static void Error(string message)
        {
            Console.WriteLine("ERROR: " + message);
        }
        public static void Error(string message, Exception exception)
        {
            Console.WriteLine("ERROR: " + message);
            Console.WriteLine(exception);
        }
        public static void Error(string message, ConsoleColor ForeGroundColor)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.WriteLine("ERROR: " + message);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, Exception exception)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.WriteLine("ERROR: " + message);
            Console.WriteLine(exception);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, ConsoleColor BackGroundColor)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.BackgroundColor = BackGroundColor;
            Console.WriteLine("ERROR: " + message);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, ConsoleColor BackGroundColor, Exception exception)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.BackgroundColor = BackGroundColor;
            Console.WriteLine("ERROR: " + message);
            Console.WriteLine(exception);
            Console.ResetColor();
        }
    }
}
