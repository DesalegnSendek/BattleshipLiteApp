using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    public class Program
    {
        static void Main(string[] args)
        {

            WelcomeMessages();
            PlayerInformationModel player =  CreatePlayer("Player 1");
            PlayerInformationModel player2 = CreatePlayer("Player 2");
            PlayerInformationModel Winner = null;

            do {

                DisplayShotGrid(ActivePlayer);
            } while (Winner==null);

            Console.ReadLine();
        }


        private static void DisplayShotGrid(PlayerInformationModel activePlayer)
        {
            string currentRow = "";

            foreach (var gridSpot in activePlayer.ShotGrids)
            {
                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.WriteLine($"{gridSpot.SpotLetter} ");
                }
            }
        }

        private static void WelcomeMessages()
        {
            Console.WriteLine("Welcome to BattleshipLite App");
            Console.WriteLine("Created By Desalegn Sendek");
            Console.WriteLine("February 29/02/2024");
            Console.WriteLine();
        }

        private static PlayerInformationModel CreatePlayer(string PlayerTitle)
        {
            PlayerInformationModel player = new PlayerInformationModel();
            Console.WriteLine($"Player information about {PlayerTitle}");
            //asking their name
            player.UserName = AskForUsersname();

            //load up shot grid
             GameLogic.IntializeGrid(player);

            //ask the user for their 5 ship placements
            PlaceShips(player);

            //clear the screen
            Console.Clear();
     
            return player;
        }

        private static string AskForUsersname()
        {
            Console.Write("What is your Name: ");
            string name = Console.ReadLine();

            return name;
        }

        private static void PlaceShips(PlayerInformationModel model)
        {
            do{
                Console.WriteLine($"Where do you want to place your {model.ShipLocations.Count}th ship: ");
                string Location = Console.ReadLine();

                bool isValid = GameLogic.PlaceShip(model, Location);
                if (isValid == false)
                {
                    Console.WriteLine("It is invalid location please try again...");
                }
            } while (model.ShipLocations.Count < 5);
        }
    }
}
