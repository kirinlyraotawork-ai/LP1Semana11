using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringGenerator
{
    
    public class View
    {
        //private readonly Controller controller;
        //private readonly string output; 
        //string output = Generator.Generate(seed);

        /*public View(string seed)
        {
            this.output = output;
        }*/

        public void Show(string output)
        {
            Console.WriteLine(output);
        }
        public void Answer(string answer)
        {
            Console.WriteLine(answer);
        }
    }
}