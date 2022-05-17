using Ex03.GarageLogic.Validation;
using System;

namespace Ex03.ConsoleUI
{
    public class ValidInputUI
    {
        public static void ValidInput(int i_Min, int i_Max, out int io_InputInt)
        {
            bool tryAgain = true;

            io_InputInt = 0;
            while (tryAgain)
            {
                try
                {
                    string inputStr = Console.ReadLine();
                    NumbersValidation.IntValid(inputStr, i_Min, i_Max, out io_InputInt);
                    tryAgain = false;
                }

                catch (Exception exeption)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }
    }
}
