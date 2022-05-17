using Ex03.GarageLogic.Garage;
using System;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class PumpingToMaxByLicenseNumber
    {
        public static void PumpingToMaxByLicenseNumberUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine(@"You choose to pump the wheels to maximum.

Write the license number for the action");
            string licenseNumber = Console.ReadLine();
            try
            {
                i_Garage.PumpingToMaxByLicenseNumber(licenseNumber);
                GarageClient currentClient = i_Garage.GarageClientCollection[licenseNumber];
                float currentAirPressure = currentClient.Vehicle.Wheels[0].CurrentAirPressure;
                Console.WriteLine($@"The pump was success ! 
The air pressure in each wheel is: -- {currentAirPressure} --");
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
