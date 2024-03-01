using BattleshipLiteLibrary.Models;
using BattleshipLiteLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
    public static class GameLogic
    {
        public static int GetShotCount(PlayerInformationModel winner)
        {
           
            return GameLogic.GetShotCount(winner);
        }

        public static bool IdentifyShotResult(PlayerInformationModel opponent, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static void IntializeGrid(PlayerInformationModel model)
        {
            List<string> Letters = new List<string>()
            {
                "A","B","C","D","E"
            };

            List<int> Numbers = new List<int>()
            {
                1,2,3,4,5
            };

            foreach (string Letter in Letters)
            { 
                foreach (int Num in Numbers)
                {
                    AddGridSpot(model,Letter,Num);
                }
            }
        }

        public static bool isValidateShot(PlayerInformationModel activePlayer, string row, int column)
        {
            throw new NotImplementedException();
        }

        public static void MarkShotResult(PlayerInformationModel activePlayer, string row, int column, bool isHit)
        {
            throw new NotImplementedException();
        }

        public static bool PlaceShip(PlayerInformationModel model, string location)
        {
            return true;
        }

        public static bool PlayerStillActive(PlayerInformationModel player)
        {
            bool isActive = false;

            foreach (var ship in player.ShipLocations)
            {
                if(ship.Status != GridSpotStatus.Sunk)
                isActive = true;
            }

            return isActive;
        }

        public static (string row, int column) SplitRowColumn(string shot)
        {
            throw new NotImplementedException();
        }

        private static void AddGridSpot (PlayerInformationModel model, string Letter, int Number) 
        {
            GridSpotModel Spot = new GridSpotModel
            {
                SpotLetter = Letter,
                SpotNumber = Number,
                Status = GridSpotStatus.Empty
            };
            model.ShotGrids.Add(Spot);
        }

    }
}
