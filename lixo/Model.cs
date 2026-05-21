using System;

namespace StringGenerator
{
    public class Model
    {
        public string Output { get; }

        public Model(string[] args,int seed, int length = 16)
        {
            Output = Generator.Generate(seed, length);

            if (args[0] == "a")
            {
                new View().ConsoleWrite();
            
                return;
            }

            if (args.Length == 0)
            {
                new View().ConsoleWrite();
            
                return;
            }
        }

    }
}