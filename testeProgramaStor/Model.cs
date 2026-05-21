using System;

namespace StringGenerator
{
    public class Model
    {
        public string Output { get; }

        public Model(int seed, int length = 16)
        {
            Output = Generator.Generate(seed, length);
        }
    }
}