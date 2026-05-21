using System;

namespace StringGenerator
{
    public class Generator
    {
        private const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generate(int seed, int length = 16)
        {
            Random rng = new Random(seed);
            var result = new System.Text.StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                int index = rng.Next(chars.Length);
                result.Append(chars[index]);
            }

            return result.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {/*
            if (args.Length == 0)
            {
                new View().ConsoleWrite();
                return;
            }*/

            int seed = int.Parse(args[0]);
            int length = args.Length > 1 ? int.Parse(args[1]) : 16;

            Controller controller = new Controller(seed, length);

            //um Run
            controller.Run();
        }
    }
}
