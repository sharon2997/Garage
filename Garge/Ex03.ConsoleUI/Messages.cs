using System;

namespace Ex03.ConsoleUI
{
    public class Messages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine(@"Welcome To < Garage Managing System >,

Please press any key to continue...");
        }

        public static void ExitMessage()
        {
            Console.WriteLine(@"Thank you for using the < Garage Managing System >,

see you next time...");
        }

        public static void MainMenuMessage()
        {
            Console.WriteLine(@"MAIN MENU:
=============================================================
what would you like to do? 
Choose ONE of the option below by typing number beetwen 1 to 8
=============================================================
1. Insert new vehicle to garage

2. Dispaly list of all license numbers in the garage

3. Change Vehicle Status

4. Pumping all wheels of vehicle to maximum

5. Fuel vehicle with gas

6. Charge vehicle battery 

7. Disple vehicle details

8. Exit from the < Garage Managing System >
");
        }

        public static void successfullyInsertedMessage()
        {
            Console.WriteLine(@"
The vehicle was successfully inserted !");
        }
    }
}
