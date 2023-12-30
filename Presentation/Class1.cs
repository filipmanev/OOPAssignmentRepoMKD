using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Class1
    {
        ProductsRepository productRepository = new ProductsRepository();
        public void shipsList()
        {
            var ships = productRepository.ShowShips();

            Console.WriteLine("ID " + " Title" + "    Size");
            Console.WriteLine("--------------------");
            foreach (var ship in ships)
            {
                Console.WriteLine($"{ship.ID}   | {ship.Title}   | {ship.Size}");
            }
        }

        public int gettingUserInput(List<int> playerShipsList)
        {
            int userShipChosen = 0;
            if (playerShipsList.Count < 5)
            {
                Console.Clear();
                shipsList();

                Console.WriteLine("\nPlease select a ship by its ID: ");
                userShipChosen = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                userShipChosen = 69;
            }
            return userShipChosen;
        }

        public void gridDisplay()
        {
            int rows = 8;
            int columns = 7;

            Console.Write("  ");
            for (char col = 'A'; col < 'A' + columns; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();

            for (int row = 1; row <= rows; row++)
            {
                Console.Write(row.ToString().PadLeft(2) + " ");

                for (int col = 1; col <= columns; col++)
                {
                    Console.Write("O ");
                }
                Console.WriteLine();
            }
        }

        public void player1ChosenShips(int userShipChosen, List<int> player1ChosenShips, bool allShipsChosen,List<string> player1ShipCoordinates, string playerPlaying, int ongoingGame)
        {
            do
            {
                userShipChosen = gettingUserInput(player1ChosenShips);

                if (userShipChosen == 69)
                {
                    allShipsChosen = true;
                }

                var userShipByID = productRepository.GetShipByID(userShipChosen);

                if (userShipByID != null)
                {
                    if (player1ChosenShips.Contains(userShipChosen))
                    {
                        Console.WriteLine("This ship is chosen already. Please chose another one.");
                        Console.ReadKey();
                    }
                    else
                    {
                        List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g'};
                        List<int> numbers = new List<int> {1,2,3,4,5,6,7,8};
                        List<char> orientation = new List<char> {'h', 'v'};
                        List<string> shipFinalCoordinates = new List<string> { };
                        List<string> shipFinalCoordinatesToSend = new List<string> { };
                        string shipFinalCoordinatesToSendString = "";

                        player1ChosenShips.Add(userShipChosen);

                        //Input coordinates here
                        Console.Clear();

                        gridDisplay();

                        Console.WriteLine($"\nPlacing ship with size {productRepository.GetShipByIDSize(userShipChosen)}");
                        bool isFinishedRow = true;
                        bool isFinishedColumn = true;
                        bool isFinishedOrientation = true;

                        while (isFinishedRow == true)
                        {
                            Console.WriteLine("Please select the Row where to place the boat: ");
                            char rowForShip = Console.ReadLine()[0];

                            if (letters.Contains(rowForShip))
                            {
                                while (isFinishedColumn == true)
                                {
                                    Console.WriteLine("Please select the Column where to place the boat: ");
                                    int columnForShip = Convert.ToInt32(Console.ReadLine());
                                    isFinishedRow = false;

                                    if (numbers.Contains(columnForShip))
                                    {
                                        Console.WriteLine("Do you want to place it horizontal(H) or vertical(V)");
                                        char orientationForShip = Console.ReadLine()[0];
                                        isFinishedColumn = false;

                                        while(isFinishedOrientation == true)
                                        {
                                            if (orientation.Contains(orientationForShip))
                                            {
                                                string currentShip = rowForShip + columnForShip.ToString() + orientationForShip;
                                                player1ShipCoordinates.Add(currentShip);
                                                isFinishedOrientation = false;
                                                int shipSize = productRepository.GetShipByIDSize(userShipChosen);
                                                string finalCoordinate = "";


                                                finalCoordinate = "";
                                                shipFinalCoordinates = new List<string>();
                                                shipFinalCoordinatesToSend = new List<string>();
                                                shipFinalCoordinatesToSendString = "";

                                                foreach (var coordinate in player1ShipCoordinates)
                                                {
                                                    if (orientationForShip == 'h')
                                                    {
                                                        int startingIndex = letters.IndexOf(rowForShip);
                                                        int finishIndex = startingIndex + shipSize;

                                                        for (int h = startingIndex; h < finishIndex; h++)
                                                        {
                                                            finalCoordinate = letters[h].ToString() + columnForShip.ToString();
                                                            shipFinalCoordinates.Add(finalCoordinate);
                                                        }
                                                        shipFinalCoordinatesToSend = shipFinalCoordinates;
                                                        shipFinalCoordinatesToSendString = string.Join(",",shipFinalCoordinatesToSend);

                                                        productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);

                                                        shipFinalCoordinates = new List<string>();
                                                    }
                                                    else if(orientationForShip == 'v')
                                                    {
                                                        int startingIndex = numbers.IndexOf(columnForShip);
                                                        int finishIndex = startingIndex + shipSize;

                                                        for (int v = startingIndex; v < finishIndex; v++)
                                                        {
                                                            finalCoordinate = rowForShip.ToString() + numbers[v].ToString();
                                                            shipFinalCoordinates.Add(finalCoordinate);
                                                        }
                                                        shipFinalCoordinatesToSend = shipFinalCoordinates;
                                                        shipFinalCoordinatesToSendString = string.Join(",",shipFinalCoordinatesToSend);

                                                        productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);

                                                        shipFinalCoordinates = new List<string>();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Input out of range. Please check the grid.");
                                                Console.ReadKey();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input out of range. Please check the grid.");
                                        Console.ReadKey();
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Input out of range. Please check the grid.");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                else if (userShipChosen == 69)
                {
                    allShipsChosen = true;
                    Console.WriteLine($"All ships have been placed for player '{playerPlaying}'");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("This ship doesnt exist, please choose another one.");
                    Console.ReadKey();
                    //This ship doesnt exist
                    
                }
            } while (allShipsChosen == false);
        }

    }
}
