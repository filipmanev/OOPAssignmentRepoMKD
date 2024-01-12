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

        public void gridDisplay(int ongoingGameID, string playerPlaying)
        {
            //attackOrShip check if its a 0 it will display the grid with all of the ship, if its 1 it will display X and O for the attacks
            int rows = 8; // ↑↓
            int columns = 7; // <--->
            string currentCol = "";
            string coordinates = productRepository.GetCoordinatesForShips(ongoingGameID, playerPlaying, false).Replace(" ", "");
            List<string> coordinatesList = coordinates.Split(',').ToList();

            Console.Write("   ");
            for (char col = 'A'; col < 'A' + columns; col++)
            {
                Console.Write(" " + col);
            }
            Console.WriteLine();

            for (int row = 1; row <= rows; row++)
            {
                Console.Write(row.ToString().PadLeft(2) + " ");
                for (int col = 1; col <= columns; col++)
                {
                    if (col == 1)
                    {
                        currentCol = "a" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 2)
                    {
                        currentCol = "b" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 3)
                    {
                        currentCol = "c" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 4)
                    {
                        currentCol = "d" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 5)
                    {
                        currentCol = "e" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 6)
                    {
                        currentCol = "f" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                        }
                        else
                        {
                            Cell(1);

                        }
                    }
                    else if (col == 7)
                    {
                        currentCol = "g" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            Cell(0);
                            Console.Write("|");
                        }
                        else
                        {
                            Cell(1);
                            Console.Write("|");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void displayAttacks(int ongoingGameID, string playerPlaying)
        {
            int rows = 8; // ↑↓
            int columns = 7; // <--->
            string currentCol = "";
            List<string> coordinatesList = productRepository.attacks(playerPlaying, ongoingGameID); //all of the attacks done by the player

            Console.Write("   ");
            for (char col = 'A'; col < 'A' + columns; col++)
            {
                Console.Write(" " + col);
            }
            Console.WriteLine();

            for (int row = 1; row <= rows; row++)
            {
                Console.Write(row.ToString().PadLeft(2) + " ");
                for (int col = 1; col <= columns; col++)
                {
                    if (col == 1)
                    {
                        currentCol = "a" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 2)
                    {
                        currentCol = "b" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 3)
                    {
                        currentCol = "c" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 4)
                    {
                        currentCol = "d" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 5)
                    {
                        currentCol = "e" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);
                        }
                    }
                    else if (col == 6)
                    {
                        currentCol = "f" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                        }
                        else
                        {
                            Cell(1);

                        }
                    }
                    else if (col == 7)
                    {
                        currentCol = "g" + row;
                        if (coordinatesList.Contains(currentCol))
                        {
                            if (productRepository.attackStatus(ongoingGameID, playerPlaying, currentCol) == true)
                            {
                                Cell(2);
                            }
                            else
                            {
                                Cell(3);
                            }
                            Console.Write("|");
                        }
                        else
                        {
                            Cell(1);
                            Console.Write("|");
                        }
                    }
                }
                Console.WriteLine();
            }
        }
        public void Cell(int ship)
        {
            if(ship == 0)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("S");
                Console.ResetColor();
            }
            else if(ship == 1)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("O");
                Console.ResetColor();
            }else if(ship == 2)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("X");
                Console.ResetColor();
            }else if(ship == 3)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("M");
                Console.ResetColor();
            }
        }
        public int gettingUserInput(List<int> playerShipsList, string playerPlaying)
        {
            int userShipChosen = 0;
            if (playerShipsList.Count < 5)
            {
                Console.Clear();
                shipsList();
                do
                {
                    Console.WriteLine($"\n{playerPlaying}: Please select a ship by its ID: ");
                    string userShipChosenString = Console.ReadLine();

                    if (!int.TryParse(userShipChosenString, out userShipChosen))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }
                    else
                    {
                        break;
                    }
                } while (!int.TryParse(Console.ReadLine(), out userShipChosen));
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
            List<string> coordinatesInSQL = productRepository.checkCollision(playerPlaying, ongoingGame);
            int shipSize = productRepository.GetShipByIDSize(userShipChosen);
            player1ChosenShips.Add(userShipChosen);
            Console.Clear();
            gridDisplay(ongoingGame, playerPlaying);
            Console.WriteLine($"\nPlacing ship with size {productRepository.GetShipByIDSize(userShipChosen)}");
            bool isFinishedRow = true;
            bool isFinishedColumn = true;
            bool isFinishedOrientation = true;
            while (isFinishedRow == true)
            {
                char rowForShip;

                do
                {
                    Console.WriteLine("Please select the Row where to place the boat: ");
                    char.TryParse(Console.ReadLine(), out rowForShip);

                    if (rowForShip == '\0')
                    {
                        Console.WriteLine("Invalid input. Please enter a single character");
                    }
                } while (rowForShip == '\0');
                /*Console.WriteLine("Please select the Row where to place the boat: ");
                char rowForShip = Console.ReadLine()[0];*/
                if (letters.Contains(rowForShip))
                {
                    while (isFinishedColumn == true)
                    {
                        int columnForShip;

                        do
                        {
                            Console.WriteLine("Please select the Column where to place the boat: ");
                            string input = Console.ReadLine();

                            if (!int.TryParse(input, out columnForShip))
                            {
                                Console.WriteLine("Invalid input. Please enter a single character");
                            }
                            else
                            {
                                break;
                            }
                        } while (!int.TryParse(Console.ReadLine(), out columnForShip));

                        isFinishedRow = false;
                        if (numbers.Contains(columnForShip))
                        {
                            while (isFinishedOrientation == true)
                            {
                                Console.WriteLine("Do you want to place it horizontal(H) or vertical(V)");
                                ConsoleKeyInfo keyInfo = Console.ReadKey();
                                char orientationForShip = keyInfo.KeyChar;
                                isFinishedColumn = false;
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
            Console.Clear();
            List<char> letters = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            bool isFinished = false;
            char rowAttack;
            int columnAttack;
            List<string> attacksPlayed = new List<string> { };
            do
            {
                Console.Clear();
                //displayAttacks(ongoingGameID, playerPlaying, false);
                displayAttacks(ongoingGameID, playerPlaying);
                Console.WriteLine();
                Console.WriteLine($"Player {playerPlaying} is attacking: ");
                Console.WriteLine("Enter the Row for the attack: ");
                char rowAttackCheck = Console.ReadLine()[0];
                if (letters.Contains(rowAttackCheck))
                {
                    Console.Clear();
                    rowAttack = rowAttackCheck;
                    try
                    {
                        Console.Clear();
                        //displayAttacks(ongoingGameID, playerPlaying, false);
                        displayAttacks(ongoingGameID, playerPlaying);
                        Console.WriteLine();
                        Console.WriteLine("Enter the Column for the attack: ");
                        int columnAttackCheck = Convert.ToInt32(Console.ReadLine());
                        if (numbers.Contains(columnAttackCheck))
                        {
                            columnAttack = columnAttackCheck;
                            playerAttack = rowAttack + columnAttack.ToString();
                            if (productRepository.isAttackGuessed(playerPlaying, ongoingGameID, playerAttack) == true)
                            {
                                Console.WriteLine("That attack already exists. Please try again.");
                                Console.ReadKey();
                            }
                            else
                            {
                                attacksPlayed.Add(playerAttack);
                                Console.Clear();
                                isFinished = true;
                                playerAttackCheck(playerPlaying, playerAttack, opponent, ongoingGameID);
                            }
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
                }
                else
                {
                    Console.WriteLine("Input out of range. Please enter the correct Row.");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (isFinished == false);
            Console.ReadLine();
        }
        public void playerAttackCheck(string playerPlaying, string playerAttack, string opponent, int ongoingGameID)
        {
            string coordinatesString = productRepository.GetCoordinatesForShips(ongoingGameID, playerPlaying, true).Replace(" ", "");
            List<string> allCoordinatesIndividually =  coordinatesString.Split(',').ToList();
            
            if (allCoordinatesIndividually.Contains(playerAttack))
            {
                Console.WriteLine($"Coordinate {playerAttack} is a hit!");
                productRepository.addAttack(playerAttack, true, ongoingGameID, playerPlaying);
                //displayAttacks(ongoingGameID, playerPlaying, false);
                displayAttacks(ongoingGameID, playerPlaying);
            }
            else
            {
                Console.WriteLine($"Coordinate {playerAttack} is a miss.");
                productRepository.addAttack(playerAttack, false, ongoingGameID, playerPlaying);
                //displayAttacks(ongoingGameID, playerPlaying, false);
                displayAttacks(ongoingGameID, playerPlaying);
            }
        }
    }
}
