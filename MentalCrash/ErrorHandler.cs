namespace MentalCrash
{
    public static class ErrorHandler
    {
        public static void Error(string message, bool errorText = true)
        {
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
        }
        public static void Error(string message, Exception exception, bool errorText = true)
        {
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
            Console.WriteLine(exception);
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, bool errorText = true)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, Exception exception, bool errorText = true)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
            Console.WriteLine(exception);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, ConsoleColor BackGroundColor, bool errorText = true)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.BackgroundColor = BackGroundColor;
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
            Console.ResetColor();
        }
        public static void Error(string message, ConsoleColor ForeGroundColor, ConsoleColor BackGroundColor, Exception exception, bool errorText = true)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.BackgroundColor = BackGroundColor;
            Console.Write("\n");
            if (errorText)
            {
                Console.Write("\nERROR: ");
            }
            else
            {
                for (int i = 0; i < "ERROR: ".Length; i++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(message);
            Console.WriteLine(exception);
            Console.ResetColor();
        }
        public static void ErrorPosition(int spacing, ConsoleColor ForeGroundColor)
        {
            Console.ForegroundColor = ForeGroundColor;
            Console.Write("\n");
            for (int i = 0; i < spacing + 1 + "ERROR: ".Length; i++)
            {
                Console.Write("-");
            }
            Console.Write("^");
            Console.Write("\n");
            Console.ResetColor();
        }
    }
}
