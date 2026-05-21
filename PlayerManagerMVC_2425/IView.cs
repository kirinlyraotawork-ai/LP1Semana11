using System.Collections.Generic;

namespace PlayerManagerMVC
{
    // View interface for the application: defines how the controller interacts
    // with any concrete UI implementation.
    public interface IView
    {
        // Display the main menu and return the user's selected option.
        int MainMenu(PlayerOrder playerOrder);

        // Inform the user that the selected option is invalid.
        void InvalidOption();

        // Show a collection of player objects to the user.
        void ShowPlayers(IEnumerable<Player> players);

        // Ask the user for a new player's name and score.
        (string, int) AskForPlayer();

        // Ask the user for a minimum score filter value.
        int AskForMinimumScore();

        // Ask the user which ordering should be applied to the player list.
        PlayerOrder AskPlayerOrder();
    }
}