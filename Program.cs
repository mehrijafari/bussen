using System;
using System.Security.Cryptography.X509Certificates;

namespace slutprojekt
{
    class Buss
    {

        public int[] seats = new int[25]; //vektor med 25 platser på bussen
        public int nr_of_passengers = 0; // variabel som sparar info om hur många passagerare som är på bussen


        public void Run()
        {
            Console.WriteLine("Welcome to the awesome Buss-simulator!");
            
            int menu = 0; // variabel som sparar info om användarens menyval
            do // loop som låter användaren göra olika menyval 
            {
                Console.WriteLine("\n***********************************");
                Console.WriteLine("Choose an alternative");
                Console.WriteLine("Enter a number then press enter:");
                Console.WriteLine("***********************************");
                Console.WriteLine("\n--------------------------");
                Console.WriteLine("1) Add passenger to the bus");
                Console.WriteLine("2) Display all the ages currently on the bus");
                Console.WriteLine("3) Display the total age of the people on the bus");
                Console.WriteLine("4) Exit the program");
                Console.WriteLine("--------------------------");
                try // testar om användaren skriver in ett heltal
                {
                    menu = Convert.ToInt32(Console.ReadLine());
       
                    switch (menu)
                    {
                            case 1: add_passenger();
                                break;
                            case 2: print_buss();
                                break;
                            case 3: Calc_total_age();
                                break;
                            case 4: 
                                break;
                    }
                    
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("\nChoose an alternative by entering a number then pressing enter"); //ber användaren skriva in ett heltal då den har skrivit in något annat
                    Console.WriteLine("\nPress enter to return to the menu");
                    Console.ReadKey();
                    Console.Clear();
                }
                
            } while (menu != 4 ); // avslutar menyvals-loopen om användaren väljer menyval 4

        }
        //Metoder för betyget E

        public void add_passenger() // Lägg till passagerare
        {    
            Console.Clear();
            int boarding_bus; // variabel som sparar info om hur många som går på bussen denna omgång

            Console.WriteLine("How many passengers are boarding the bus?");
            Console.WriteLine("\nEnter a number then press enter: ");
            Console.WriteLine();
            try // testar om användaren skriver in ett heltal
            {
                boarding_bus = Convert.ToInt32(Console.ReadLine());
                nr_of_passengers = nr_of_passengers + boarding_bus; // lägger till antalet som går på bussen i variabeln som sparar info om hur många som är på bussen
            

                for (int i = 0; i < nr_of_passengers; i++) // loop som låter användaren skriva in ålder på passagerarna som går på bussen
                {

                    if (seats[i] != 0) // om sätet ärr upptaget fortsätter loopen
                    {
                        continue;

                    }
                    else if (boarding_bus > seats.Length) // om mer än 25 passagerare försöker gå på bussen avsluta loopen
                    {
                        Console.WriteLine("\nThere is only room for 25 people on this bus");
                        nr_of_passengers = nr_of_passengers - boarding_bus; 
                        break;
                    }
                    else if (nr_of_passengers > seats.Length) // om man försöker lägga till mer passagerare än vad som får plats på bussen avsluta loopen
                    {
                        Console.WriteLine("\nThere aren't enough seats on the bus.");
                        nr_of_passengers -= boarding_bus;
                        Console.WriteLine("\nThere are " +  (seats.Length - nr_of_passengers) + " seats left on this bus. Try adding fewer passengers.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nEnter the age of the passanger then press enter:"); // ber användaren skriva in åldern på passageraren
                    }
                    
                      int passenger_age = Convert.ToInt32(Console.ReadLine()); // skapar variabel som sparar passagerarnas ålder, läser av användarens inmatning
                      seats[i] = passenger_age; // sparar passagerarnas ålder i vektorn
                }
                if (nr_of_passengers == 1) // om det bara är 1 person på bussen
                {
                    Console.WriteLine("There is " + nr_of_passengers + " person on this bus right now.");
                }
                else // om det är fler än 1 person på bussen 
                {
                    Console.WriteLine("\nThere are " + nr_of_passengers + " people on this bus right now");
                }
            }
            catch (FormatException) // ber användaren skriva in heltal då hen skrev in något annat
            {
                Console.WriteLine("\nPlease, only type in numbers.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nThere is only room for 25 people on this bus, try to add fewer passengers");
            }
            Console.WriteLine("\nPress enter to return to the menu");
            Console.ReadKey();
            Console.Clear();


        }

        public void print_buss() //Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
        {
            Console.Clear ();

            if (nr_of_passengers == 0) // om det inte är någon på bussen
            {
                Console.WriteLine("There are no people on this bus.");
                Console.WriteLine("Add some passengers to the bus to display all the ages");
            }
            else // om det finns passagerare på bussen 
            {
                Console.WriteLine("\nHere are all the ages of the passengers on the bus: ");
                for (int i = 0; i < seats.Length; i++) // loop som skriver ut hur många som är på bussen 
                {
                    if (seats[i] == 0) // om sätet är tomt fortsätter loopen
                    {
                        continue;
                    }
                    else // om det finns passagerare på bussen 
                    {
                        Console.WriteLine(seats[i]);
                    }

                }
            }
            Console.WriteLine("\nPress enter to return to the menu");
            Console.ReadKey();
            Console.Clear();
        }

        public int Calc_total_age() //Beräkna den totala åldern. 
        {    
            Console.Clear();
            int sum = seats.Sum(); // skapar variabel som sparar totalålder av alla på bussen, anropar metoden Sum som räknar ut totalåldern på passagerarna
            if (sum == 0) // om totalåldern är 0 år
            {
                Console.WriteLine("There are no passangers on this bus");
                Console.WriteLine("Add some passengers to the bus to calculate their total age");
            }
            else // skriv ut totalåldern på passagerarna
            {
                Console.WriteLine("\nThe total age of all the passengers on the bus is " + sum + " years.");
            }
         
            Console.WriteLine("\nPress enter to return to the menu");
            Console.ReadKey();
            Console.Clear();

            return sum;
        }

        



    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Följande rad skapar en buss:
            var minbuss = new Buss();
            //Följande rad anropar metoden Run() som finns i vårt nya buss-objekt.
            minbuss.Run();
            //När metoden Run() tar slut så kommer koden fortsätta här. Då är programmet slut
            Console.WriteLine("Exiting the program.");
            Console.Write("\nPress any key to continue . . . ");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}