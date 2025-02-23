using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Countdown to End of Day");

        while (true)
        {
            // Get the current time in UTC
            DateTime now = DateTime.UtcNow;

            // Calculate the end of the current day (23:59:59 UTC)
            DateTime endOfDay = new DateTime(now.Year, now.Month, now.Day, 23, 59, 59, DateTimeKind.Utc);

            // Calculate the time remaining
            TimeSpan timeRemaining = endOfDay - now;

            // Display the countdown in the console
            Console.Clear();
            Console.WriteLine($"Time Remaining: {timeRemaining.ToString(@"hh\:mm\:ss")}");

            // Draw circles for hours, minutes, and seconds
            DrawCircle("Hours", timeRemaining.Hours, 24);
            DrawCircle("Minutes", timeRemaining.Minutes, 60);
            DrawCircle("Seconds", timeRemaining.Seconds, 60);

            // Wait for 1 second before updating the countdown
            Thread.Sleep(1000);
        }
    }

    static void DrawCircle(string label, int value, int maxValue)
    {
        // Unicode characters for drawing circles
        char filledCircle = '●'; // Filled circle
        char emptyCircle = '○';  // Empty circle

        // Calculate the percentage filled
        double percentage = (double)value / maxValue;

        // Draw the circle
        Console.WriteLine($"{label}:");
        for (int i = 0; i < 10; i++)
        {
            if (i < percentage * 10)
                Console.Write(filledCircle); // Filled part
            else
                Console.Write(emptyCircle);  // Empty part
        }
        Console.WriteLine("\n");
    }
}
