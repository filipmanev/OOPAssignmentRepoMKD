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
        public int gettingUserInput(List<int> playerShipsList, string playerPlaying)
        {
            int userShipChosen = 0;
            if (playerShipsList.Count < 5)
            {
                Console.Clear();
                shipsList();
                Console.WriteLine($"\n{playerPlaying}: Please select a ship by its ID: ");
                userShipChosen = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                userShipChosen = 69;
            }
            return userShipChosen;
        }
        public bool player1ChosenShips(bool allShipsChosen, int userShipChosen, List<int> player1ChosenShips, List<string> player1ShipCoordinates, string playerPlaying, int ongoingGame)
        {
            do
            {
                userShipChosen = gettingUserInput(player1ChosenShips, playerPlaying);
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
                        mainLoopFunction(allShipsChosen, userShipChosen, player1ChosenShips, player1ShipCoordinates, playerPlaying, ongoingGame);
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
            //userShipChosen = 0;
            //llShipsChosen = false;
            return true;
        }
        public void mainLoopFunction(bool allShipsChosen, int userShipChosen, List<int> player1ChosenShips, List<string> player1ShipCoordinates, string playerPlaying, int ongoingGame)
        {
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<char> orientation = new List<char> { 'h', 'v' };
            List<string> shipFinalCoordinates = new List<string> { };
            List<string> shipFinalCoordinatesToSend = new List<string> { };
            string shipFinalCoordinatesToSendString = "";
            List<string> coordinatesInSQL = productRepository.checkCollision(playerPlaying);
            int shipSize = productRepository.GetShipByIDSize(userShipChosen);

            player1ChosenShips.Add(userShipChosen);
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

                            while (isFinishedOrientation == true)
                            {
                                if (orientation.Contains(orientationForShip))
                                {
                                    string currentShip = rowForShip + columnForShip.ToString() + orientationForShip;
                                    player1ShipCoordinates.Add(currentShip);
                                    isFinishedOrientation = false;
                                    string finalCoordinate = "";
                                    finalCoordinate = "";
                                    shipFinalCoordinates = new List<string>();
                                    shipFinalCoordinatesToSend = new List<string>();
                                    shipFinalCoordinatesToSendString = "";
                                    int rowSize = letters.IndexOf(rowForShip);
                                    int finishIndexForShip = rowSize + shipSize;
                                    int columnSize = numbers.IndexOf(columnForShip);
                                    int finishIndexForShipColumn = columnSize + shipSize;

                                    foreach (var coordinate in player1ShipCoordinates)
                                    {
                                        if (orientationForShip == 'h')
                                        {
                                            if (finishIndexForShip > letters.Count)
                                            {
                                                Console.WriteLine("Please select different coordinates. Ship does not fit.");
                                                if (player1ChosenShips.Count > 0)
                                                {
                                                    player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                }
                                                //player1ShipCoordinates.RemoveAt(player1ShipCoordinates.Count - 1);
                                                Console.ReadKey();
                                                return;
                                            }
                                            else
                                            {
                                                int startingIndex = letters.IndexOf(rowForShip);
                                                int finishIndex = startingIndex + shipSize;

                                                for (int h = startingIndex; h < finishIndex; h++)
                                                {
                                                    finalCoordinate = letters[h].ToString() + columnForShip.ToString();
                                                    shipFinalCoordinates.Add(finalCoordinate);
                                                }
                                                shipFinalCoordinatesToSend = shipFinalCoordinates;
                                                shipFinalCoordinatesToSendString = string.Join(",", shipFinalCoordinatesToSend);
                                                string coordinatesHitting = "";
                                                if (coordinatesInSQL != null)
                                                {
                                                    foreach (var coor in shipFinalCoordinatesToSend)
                                                    {
                                                        if (coordinatesInSQL.Contains(coor))
                                                        {
                                                            coordinatesHitting = coordinatesHitting + coor;
                                                            Console.WriteLine($"Coordinate {coor} is hitting another ship. Please change the coordinates");
                                                            shipFinalCoordinates = new List<string>();
                                                            player1ShipCoordinates = new List<string>();
                                                            if (player1ChosenShips.Count >= 1)
                                                            {
                                                                player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                            }
                                                            Console.ReadKey();
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            if (coor == shipFinalCoordinatesToSend[shipFinalCoordinatesToSend.Count - 1])
                                                            {
                                                                productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine(coordinatesHitting);
                                                    Console.ReadKey();
                                                    //player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("There are no coordinates");
                                                    productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);
                                                    //shipFinalCoordinates = new List<string>();
                                                    player1ShipCoordinates = new List<string>();
                                                }
                                                Console.ReadKey();
                                            }
                                        }
                                        else if (orientationForShip == 'v')
                                        {
                                            if (finishIndexForShipColumn > numbers.Count)
                                            {
                                                Console.WriteLine("Please select different coordinates. Ship does not fit.");
                                                if (player1ChosenShips.Count > 0)
                                                {
                                                    player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                }
                                                //player1ShipCoordinates.RemoveAt(player1ShipCoordinates.Count - 1);
                                                Console.ReadKey();
                                                return;
                                            }
                                            else
                                            {
                                                /*productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);

                                                shipFinalCoordinates = new List<string>();
                                                player1ShipCoordinates = new List<string>();
*/
                                                int startingIndex = numbers.IndexOf(columnForShip);
                                                int finishIndex = startingIndex + shipSize;

                                                for (int v = startingIndex; v < finishIndex; v++)
                                                {
                                                    finalCoordinate = rowForShip.ToString() + numbers[v].ToString();
                                                    shipFinalCoordinates.Add(finalCoordinate);
                                                }
                                                shipFinalCoordinatesToSend = shipFinalCoordinates;
                                                shipFinalCoordinatesToSendString = string.Join(",", shipFinalCoordinatesToSend);

                                                string coordinatesHitting = "";
                                                if (coordinatesInSQL != null)
                                                {
                                                    foreach (var coor in shipFinalCoordinatesToSend)
                                                    {
                                                        if (coordinatesInSQL.Contains(coor))
                                                        {
                                                            coordinatesHitting = coordinatesHitting + coor;
                                                            Console.WriteLine($"Coordinate {coor} is hitting another ship. Please change the coordinates");

                                                            shipFinalCoordinates = new List<string>();
                                                            player1ShipCoordinates = new List<string>();
                                                            if (player1ChosenShips.Count >= 1)
                                                            {
                                                                player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                            }
                                                            Console.ReadKey();
                                                            return;
                                                        }
                                                        else
                                                        {
                                                            if (coor == shipFinalCoordinatesToSend[shipFinalCoordinatesToSend.Count - 1])
                                                            {
                                                                productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);
                                                                return;
                                                            }
                                                        }
                                                    }
                                                    Console.WriteLine(coordinatesHitting);
                                                    //player1ChosenShips.RemoveAt(player1ChosenShips.Count - 1);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("There are no coordinates");
                                                    productRepository.addShipToConfig(shipFinalCoordinatesToSendString, playerPlaying, ongoingGame, userShipChosen);
                                                    //shipFinalCoordinates = new List<string>();
                                                    player1ShipCoordinates = new List<string>();
                                                }
                                                Console.ReadKey();
                                            }
                                        }
                                    }
                                    Console.ReadKey();
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
        public void playerAttackFunction(string playerPlaying, string playerAttack,string opponent, int ongoingGameID)
        {

            int userAttackCount = 0;
            Console.Clear();
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            bool isFinished = false;
            char rowAttack;
            int columnAttack;
            bool chosen = false;
            
            do
            {
                Console.WriteLine($"Player {playerPlaying} is attacking: ");

                Console.WriteLine("Enter the Row for the attack: ");
                char rowAttackCheck = Console.ReadLine()[0];
                if (letters.Contains(rowAttackCheck))
                {
                    Console.Clear();
                    rowAttack = rowAttackCheck;
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the Column for the attack: ");
                            int columnAttackCheck = Convert.ToInt32(Console.ReadLine());
                            if (numbers.Contains(columnAttackCheck))
                            {
                                // theattack is valid
                                columnAttack = columnAttackCheck;
                                playerAttack = rowAttack + columnAttack.ToString();
                                userAttackCount++;
                                chosen = true;
                                Console.Clear();
                                //WORKING FINCTION WITH PARAMETER
                                //playerAttackCheck(playerPlaying, playerAttack, opponent, ongoingGameID);

                                //TEST FUNCTION WITH PARAMETERS
                                playerAttackCheck("james", playerAttack, "filip", 40);
                            }
                            else
                            {
                                Console.WriteLine("Input out of range. Please enter the correct Column.");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    } while (chosen == false);
                }
                else
                {
                    Console.WriteLine("Input out of range. Please enter the correct Row.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (isFinished == false);
            Console.WriteLine(playerAttack);
            Console.ReadLine();
        }
        public void playerAttackCheck(string playerPlaying, string playerAttack, string opponent, int ongoingGameID)
        {
            string coordinatesString = productRepository.GetCoordinatesForShips(ongoingGameID, playerPlaying).Replace(" ", "");
            List<string> allCoordinatesIndividually =  coordinatesString.Split(',').ToList();

            if (allCoordinatesIndividually.Contains(playerAttack))
            {
                Console.WriteLine("HIT!!!!!!");
                productRepository.addAttack(playerAttack, true, ongoingGameID, playerPlaying);
            }
            else
            {
                Console.WriteLine("MIS");
                productRepository.addAttack(playerAttack, false, ongoingGameID, playerPlaying);
            }

            Console.ReadLine();
        }
    }
}
