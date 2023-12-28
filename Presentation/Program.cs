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

        static int gettingUserInput(List<int> playerShipsList)
        {

            int userShipChosen = 0;


            if (playerShipsList.Count <= 5)
            {
                Console.WriteLine("\nPlease select a ship by its ID: ");
                userShipChosen = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("List is full.");
            }
           
            return userShipChosen;
        }

        static void Main(string[] args)   
        {
            int userInput = 0;
            string player1Username;  
            string player2Username;   

            string player1Password;
            string player2Password;
            ProductsRepository productRepository = new ProductsRepository();

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
                        Console.Clear();
                        List<int> player1ChosenShips = new List<int> { };
                        var ships = productRepository.ShowShips();
                        int userShipChosen;
                        Console.WriteLine("ID " + " Title" + "    Size");
                        Console.WriteLine("--------------------");
                        foreach (var ship in ships)
                        {
                            Console.WriteLine($"{ship.ID}   | {ship.Title}   | {ship.Size}");
                        }
                        var allShipsChosen = false;
                        do
                        {
                            userShipChosen = gettingUserInput(player1ChosenShips);

                            var userShipByID = productRepository.GetShipByID(userShipChosen);

                            if(userShipByID != null)
                            {
                                //This ship exists
                                if(player1ChosenShips.Count < 1 )
                                {
                                    player1ChosenShips.Add(userShipChosen);
                                    Console.WriteLine($"ship with id {userShipChosen} was added to the list");
                                }
                                else
                                {
                                    if (player1ChosenShips.Count == 5)
                                    {
                                        //All of the ships have been selected
                                        Console.WriteLine("All Ships have been configured.");
                                        allShipsChosen = true;
                                    }
                                    else
                                    {
                                        //More ships need to be selected
                                        userShipChosen = gettingUserInput(player1ChosenShips);
                                        
                                        if (player1ChosenShips.Contains(userShipChosen))
                                        {
                                            Console.WriteLine("this ship is chosen already");
                                        }
                                        else
                                        {
                                            player1ChosenShips.Add(userShipChosen);
                                            Console.WriteLine($"ship with id {userShipChosen} was added to the list");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //This ship doesnt exist
                                Console.WriteLine("This ship doesnt exist, please choose another one.");
                            }
                            /*foreach (var ship in player1ChosenShips)
                            {
                                if(userShipChosen == ship)
                                {
                                    Console.WriteLine("This ship is already chosen. Please select another ship!");
                                }
                                else
                                {
                                    
                                }
                            }*/
                        } while (allShipsChosen == false);

                        Console.WriteLine("nice, now whats next");
                        Console.ReadKey();
                        /*Console.WriteLine(userShipByID.Title);
                            Console.ReadKey();*/
                        break;
                    case 3:
                        Console.WriteLine("Hello");
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
