using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {

            int userInput = 0;
            string player1Username = "";
            string player2Username = "";

            string player1Password;
            string player2Password;
            ProductsRepository productRepository = new ProductsRepository();
            Class1 cl = new Class1();
            List<int> player1ChosenShips = new List<int> { };
            List<int> player2ChosenShips = new List<int> { };
            List<string> player1ShipCoordinates = new List<string> { };
            List<string> player2ShipCoordinates = new List<string> { };
            int ongoingGameId = 0;
            bool playerCoordinatesConfigured = true;
            string playerAttack = "";

            do
            {
                Console.Clear();
                Console.WriteLine("1. Add Player details");
                Console.WriteLine("2. Configure Ships");
                Console.WriteLine("3. Launch Attack");
                Console.WriteLine("4. Quit");

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Menu choice doesn't exist.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    userInput = 1000;
                }

                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Player 1 Username: ");
                        player1Username = Console.ReadLine();


                        if (productRepository.GetPlayerByUsername(player1Username) != null)
                        {
                            Console.WriteLine("This user already exists.");
                            Console.WriteLine("Please enter your password");

                            int maxAttempts = 3;
                            int attempts = 0;
                            bool isPasswordCorrect = false;

                            do
                            {
                                player1Password = Console.ReadLine();

                                try
                                {
                                    if(productRepository.GetPlayerPassword(player1Username) == player1Password)
                                    {
                                        isPasswordCorrect = true;
                                        Console.WriteLine("Password correct");
                                        //-------------------------------------------------------------------------------------------
                                        Console.Clear();
                                        Console.WriteLine("Player 2 Username: ");
                                        player2Username = Console.ReadLine();
                                        
                                        if(productRepository.GetPlayerByUsername(player2Username) != null)
                                        {
                                            Console.WriteLine("This user already exists.");
                                            Console.WriteLine("Please enter your password");

                                            int maxAttemptsP2 = 3;
                                            int attemptsP2 = 0;
                                            bool isPasswordCorrectP2 = false;

                                            do
                                            {
                                                player2Password = Console.ReadLine();

                                                try
                                                {
                                                    if(productRepository.GetPlayerPassword(player2Username) == player2Password)
                                                    {
                                                        isPasswordCorrectP2 = true;
                                                        Console.WriteLine("Password correct");
                                                        //if both players password correct and they are already registered
                                                        productRepository.AddPlayerToGames(player1Username, player2Username);
                                                        ongoingGameId = productRepository.GetGame(player1Username, player2Username);
                                                    }
                                                    else
                                                    {
                                                        attemptsP2++;
                                                        Console.WriteLine($"Incorrect password. Attempts remaining {maxAttemptsP2 - attemptsP2}");
                                                    }
                                                }
                                                catch (Exception ex2)
                                                {
                                                    Console.WriteLine($"An error occured: {ex2.Message}");
                                                    break;
                                                }
                                            } while (!isPasswordCorrectP2 && attemptsP2 < maxAttemptsP2);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter your password: ");
                                            player2Password = Console.ReadLine();

                                            productRepository.AddPlayer(player2Username, player2Password);

                                            productRepository.AddPlayerToGames(player1Username, player2Username);

                                        }
                                    }
                                    else
                                    {
                                        attempts++;
                                        Console.WriteLine($"Incorrect password. Attempts remaining {maxAttempts - attempts}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"An error occured: {ex.Message}");
                                    break;
                                }
                                
                            } while (!isPasswordCorrect && attempts < maxAttempts);

                        }
                        else
                        {
                            //if player username doesnt exist   

                            Console.WriteLine("Enter your password: ");
                            player1Password = Console.ReadLine();
                            Console.ReadKey();

                            productRepository.AddPlayer(player1Username, player1Password);

                            Console.WriteLine("Player 2 username: ");
                            player2Username = Console.ReadLine();

                            if (productRepository.GetPlayerByUsername(player2Username) != null)
                            {
                                Console.WriteLine("This user already exists.");
                                Console.WriteLine("Please enter your password");

                                int maxAttemptsP2 = 3;
                                int attemptsP2 = 0;
                                bool isPasswordCorrectP2 = false;

                                do
                                {
                                    player2Password = Console.ReadLine();
                                    try
                                    {
                                        if (productRepository.GetPlayerPassword(player2Username) == player2Password)
                                        {
                                            isPasswordCorrectP2 = true;
                                            Console.WriteLine("Password correct");
                                            //if both players password correct and they are already registered
                                            productRepository.AddPlayerToGames(player1Username, player2Username);
                                            ongoingGameId = productRepository.GetGame(player1Username, player2Username);
                                        }
                                        else
                                        {
                                            attemptsP2++;
                                            Console.WriteLine($"Incorrect password. Attempts remaining {maxAttemptsP2 - attemptsP2}");
                                        }
                                    }
                                    catch (Exception ex2)
                                    {
                                        Console.WriteLine($"An error occured: {ex2.Message}");
                                        break;
                                    }
                                } while (!isPasswordCorrectP2 && attemptsP2 < maxAttemptsP2);
                            }
                            else
                            {
                                Console.WriteLine("Enter your password: ");
                                player2Password = Console.ReadLine();
                                productRepository.AddPlayer(player2Username, player2Password);
                                productRepository.AddPlayerToGames(player1Username, player2Username);
                                //new user 
                            }
                        }
                        //-------------------------------------------------------------------------------------------
                      
                        break;
                    case 2:
                        
                        if (player1Username != "" && player2Username != "")
                        {
                            Console.Clear();

                            int ongoingGameID = productRepository.GetGame(player1Username, player2Username);
                            
                            var ships = productRepository.ShowShips();
                            int userShipChosen = 0;
                            int userShipChosen1 = 0;
                            var allShipsChosen = false;
                            var allShipsChosen1 = false;
                            bool isPlayerDone = false;
                            do {
                                isPlayerDone = cl.player1ChosenShips(allShipsChosen, userShipChosen, player1ChosenShips, player1ShipCoordinates, player1Username, ongoingGameID);
                            } while (isPlayerDone == false);
                            cl.player1ChosenShips(allShipsChosen1, userShipChosen1, player2ChosenShips, player2ShipCoordinates, player2Username, ongoingGameID);

                            playerCoordinatesConfigured = true;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Please select your player details first in menu option 1.");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        if (playerCoordinatesConfigured ==  true)
                        {
                            int ongoingGameID = productRepository.GetGame(player1Username, player2Username);
                            //If players ships are configured.
                            while(true){
                                cl.playerAttackFunction(player1Username, playerAttack, player2Username, ongoingGameID);
                                if (productRepository.isAllShipsGuessed(player1Username, ongoingGameID) == true)
                                {
                                    Console.WriteLine($"Player {player1Username} has won the game!");
                                    Console.ReadKey();
                                    break;
                                }
                                else
                                {
                                    cl.playerAttackFunction(player2Username, playerAttack, player1Username, ongoingGameID;
                                    if (productRepository.isAllShipsGuessed(player2Username, ongoingGameID) == true)
                                    {
                                        Console.WriteLine($"Player {player2Username} has won the game!");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }
                        }
                        else{
                            Console.WriteLine("Please configure the players ship's first.");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Hello");
                        break;
                    default:
                        Console.WriteLine("Menu choice out of range or doesn't exist.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            } while (userInput != 4);
        }
    }
}
