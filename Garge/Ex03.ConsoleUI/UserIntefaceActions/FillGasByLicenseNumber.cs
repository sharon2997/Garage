using Ex03.GarageLogic.Garage;
using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Validation;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class FillGasByLicenseNumber
    {
        private const int k_MinGasOption = 1;
        private static readonly int sr_MaxGasOption = Enum.GetNames(typeof(Gas.eGasType)).Length;

        public static void FillGasByLicenseNumberUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine(@"You choose to refuel.

Write the license number for the action");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(@"Please choose your Gas Type: 
1. Soler

2. Octan95

3. Octan96

4. Octan98");
            int gasChoiceInt = 0;
            ValidInputUI.ValidInput(k_MinGasOption, sr_MaxGasOption, out gasChoiceInt);
            Gas.eGasType gasChoice = (Gas.eGasType)gasChoiceInt;
            Console.WriteLine(@"How much would you like to refuel?");
            string quantityToRefuelStr = "";
            int quantityToRefuelInt = 0;
            bool isInt = false;
            while (!isInt)
            {
                try
                {
                    quantityToRefuelStr = Console.ReadLine();
                    NumbersValidation.IsInt(quantityToRefuelStr, out quantityToRefuelInt);
                    isInt = true;
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                i_Garage.FillGasByLicenseNumber(licenseNumber, gasChoice, quantityToRefuelStr);
                GarageClient client = i_Garage.GarageClientCollection[licenseNumber];
                Vehicle vehicle = client.Vehicle;
                Console.WriteLine($@"The vehicle successfully refueled
the current gas quantity is: {vehicle.VehicleEnergyType.CurrentAmountOfEnergy}
");
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          

            finally
            {
                Console.WriteLine("Press Enter to continue..");
                Console.ReadLine();
            }
        }
    }
}
