using System.Collections.Generic;

namespace PlayerManagerMVC
{
    // Controller in the MVC pattern: handles commands from the view, updates
    // the player model list, and coordinates sorting and filtering logic.
    public class Controller
    {
        private List<Player> list;
        private IView view;
        private IComparer<Player> compareByName;
        private IComparer<Player> compareByNameReverse;
        private PlayerOrder playerOrder;

        // Set up the controller with an initial player list and default ordering.
        public Controller(List<Player> list)
        {
            this.list = list;

            compareByName = new CompareByName(true);
            compareByNameReverse = new CompareByName(false);
            playerOrder = PlayerOrder.ByScore;
        }

        // Run the main menu loop, receive user input from the view, and
        // dispatch actions until the user chooses to exit.
        public void Run(IView view)
        {
            int input;
            this.view = view;
            do
            {
                // 1 -> Insert player
                // 2 -> List all players
                // 3 -> List players w/ score > x
                // 4 -> Change player sorting criteria
                // 0 -> Exit
                input = view.MainMenu(playerOrder);

                switch (input)
                {
                    case 0:
                        break;
                    case 1:
                        InsertPlayer();
                        break;
                    case 2:
                        SortPlayers();
                        view.ShowPlayers(list);
                        break;
                    case 3:
                        SortPlayers();
                        ShowPlayersWithScore();
                        break;
                    case 4:
                        ChangePlayerOrder();
                        break;
                    default:
                        view.InvalidOption();
                        break;
                }
            }
            while (input != 0);
        }

        // Ask the view for a new player ordering option and validate it.
        private void ChangePlayerOrder()
        {
            do
            {
                playerOrder = view.AskPlayerOrder();

                if (playerOrder < PlayerOrder.ByScore
                    || playerOrder > PlayerOrder.ByNameReverse)
                {
                    view.InvalidOption();
                }
                else
                {
                    break;
                }
            }
            while (true);
        }

        // Sort the player list using the currently selected order strategy.
        private void SortPlayers()
        {
            switch (playerOrder)
            {
                case PlayerOrder.ByScore:
                    list.Sort();
                    break;
                case PlayerOrder.ByName:
                    list.Sort(compareByName);
                    break;
                case PlayerOrder.ByNameReverse:
                    list.Sort(compareByNameReverse);
                    break;
            }
        }

        // Ask the view for player data, create a new Player model, and add it
        // to the list.
        private void InsertPlayer()
        {
            // Ask view to give us information for creating a new player
            (string name, int score) = view.AskForPlayer();

            // Create new player
            Player p = new Player(name, score);

            // Insert new player in player list
            list.Add(p);
        }

        // Get the minimum score from the view and display only players with a
        // score greater than that threshold.
        private void ShowPlayersWithScore()
        {
            // Ask view for minimum score
            int minScore = view.AskForMinimumScore();

            // Create collection with players above minimum score
            IEnumerable<Player> players =
                GetPlayersWithScoreGreaterThan(minScore);

            // Ask view to show players
            view.ShowPlayers(players);
        }

        // Return an enumerable sequence of players whose score exceeds the given
        // minimum.
        private IEnumerable<Player> GetPlayersWithScoreGreaterThan(int minScore)
        {
            foreach (Player p in list)
            {
                if (p.Score > minScore)
                    yield return p;
            }
        }
    }
}