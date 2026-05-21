using System.Collections.Generic;

namespace PlayerManagerMVC
{
    // Application entry point that wires together model, view, and controller.
    // It creates the initial list of players, the controller, and the UI view,
    // then starts the MVC application loop.
    public class Program
    {
        private static void Main()
        {
            // List of player is our model
            List<Player> list = new List<Player>()
            {
                new Player("Pedro", 50),
                new Player("Verde", 42),
            };

            // Create controller
            Controller controller = new Controller(list);

            // Create view
            IView view = new UglyView(controller);

            // Start program
            controller.Run(view);
        }
    }
}
