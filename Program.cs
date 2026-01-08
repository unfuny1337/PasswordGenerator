using System;
using System.Drawing;
using System.Text;

namespace PasswordGenerator
{
    public class MainClass
    {
        const string avaliable = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtVvYyWwXxYyZz1234567890!@#$%^&*()-+=_";
        public static void Main()
        {
            while (true)
            {
                var filepath = $"{AppContext.BaseDirectory}\\saved.txt";

                WriteClass.WriteLine("Enter password's length", ConsoleColor.Green);
                var answer = Console.ReadLine();

                if (answer == "quit")
                {
                    Environment.Exit(0);
                }

                if (int.TryParse(answer, out int result))
                {
                    File.AppendAllText(filepath, DateTime.Now.ToString() + "\n");
                    for (int i = 0; i < int.Parse(answer); i++)
                    {
                        Random random = new Random();
                        int ind = random.Next(0, avaliable.Length);
                        char randomlet = avaliable[ind];

                        File.AppendAllText($"{AppContext.BaseDirectory}\\saved.txt", randomlet.ToString());
                    }
                    File.AppendAllText(filepath, "\n\n");
                    WriteClass.WriteLine($"Your password has been saved: {filepath}\n",ConsoleColor.Blue);
                }
                else
                {
                    WriteClass.WriteLine("You didn't enter a number!", ConsoleColor.Red);
                }
                Task.Delay(1000).Wait();
            }
        }
    }
}