namespace StringGenerator
{
    public class Controller
    {
        private readonly Model model;
        private readonly View view;

        public Controller(int seed, int length = 16)
        {
            model = new Model(seed, length);
            view = new View();
        }

        public void Run()
        {
            view.Show(model.Output);
        }
    }
}