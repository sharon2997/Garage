using Ex03.GarageLogic;
using Ex03.GarageLogic.Garage;
using Ex03.GarageLogic.Validation;
using System;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class ChargeByLicenseNumber
    {
        public static void ChargeByLicenseNumberUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine(@"You choose to charge.

Write the license number for the action");
            string licenseNumber = Console.ReadLine();
            Console.WriteLine(@"How long will you want to charge the vehicle? (in minutes)");
            string timeQuantityStr = "";
            float timeQuantityFloat = 0;
            bool isFloat = false;
            while (!isFloat)
            {
                try
                {
                    timeQuantityStr = Console.ReadLine();
                    NumbersValidation.IsFloat(timeQuantityStr, out timeQuantityFloat);
                    isFloat = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            try
            {
                i_Garage.ChargeByLicenseNumber(licenseNumber, timeQuantityStr);
                GarageClient client = i_Garage.GarageClientCollection[licenseNumber];
                Vehicle vehicle = client.Vehicle;
                Console.WriteLine($@"
The vehicle successfully charged
the current battery percentage is: {vehicle.VehicleEnergyType.EnergyPercentageBalance} %
");
            }

            catch (Exception ex)
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
