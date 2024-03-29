﻿using BattleshipLiteLibrary;
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
            PlayerInformationModel activePlayer =  CreatePlayer("Player 1");
            PlayerInformationModel opponent = CreatePlayer("Player 2");
            PlayerInformationModel Winner = null;

            do {
                // Display Grid from active player on where they fired
                DisplayShotGrid(activePlayer);

                //ask active player to shot  //determine if the shot is valid or not   //determine the shot result
                RecordPlayerShot(activePlayer, opponent);

                //determine if the shot is over
                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);
                //if over, set active player as a winner
                //else swap positions(active player to opponent)
                if (doesGameContinue == true)
                {
                    PlayerInformationModel TempHolder = opponent;
                    opponent = activePlayer;
                    activePlayer = TempHolder;

                    //using tuples
                  //  (activePlayer, opponent) = (opponent, activePlayer);
                }

            } while (Winner==null);

            IdentifyWinner(Winner);

            Console.ReadLine();
        }

        private static void IdentifyWinner(PlayerInformationModel winner)
        {
            Console.WriteLine($"Congratulations dear {winner.UserName} for winning");
            Console.WriteLine($"{winner.UserName} took {GameLogic.GetShotCount(winner)} Shots.");
        }

        private static void RecordPlayerShot(PlayerInformationModel activePlayer, PlayerInformationModel opponent)
        {
            bool isValidShot = false;
            string row = "";
            int column = 0;
            do
            {

                string Shot = askForShot();
                (row, column) =GameLogic.SplitRowColumn(Shot);
                isValidShot = GameLogic.isValidateShot(activePlayer,row, column);

                if(!isValidShot)
                {
                    Console.WriteLine("Please try another valid shot!");
                }
            } while (!isValidShot);

            //derermine shot result
            bool isHit = GameLogic.IdentifyShotResult(opponent, row, column);

            //record result
            GameLogic.MarkShotResult(activePlayer, row, column,isHit );
        }

        private static string askForShot()
        {
            Console.Write("Please enter your shot selection: ");
            string Shot = Console.ReadLine();

            return Shot;
        }

        private static void DisplayShotGrid(PlayerInformationModel activePlayer)
        {
            string currentRow = activePlayer.ShotGrids[0].SpotLetter;
            foreach (var gridSpot in activePlayer.ShotGrids)
            {
                if (gridSpot.SpotLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.SpotLetter;
                }

                if (gridSpot.Status == GridSpotStatus.Empty)
                {
                    Console.Write($"{gridSpot.SpotLetter}{gridSpot.SpotNumber} ");
                }

                else if (gridSpot.Status == GridSpotStatus.Hit)
                {
                    Console.WriteLine("X ");
                }
                  
                else if (gridSpot.Status == GridSpotStatus.Miss)
                {
                    Console.WriteLine("O ");
                }
                else
                {
                    Console.WriteLine(" 0 ");
                }
            }//end of foreach
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
