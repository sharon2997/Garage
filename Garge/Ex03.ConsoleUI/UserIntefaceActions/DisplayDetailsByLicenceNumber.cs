using Ex03.GarageLogic.Garage;
using System;
using System.Text;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class DisplayDetailsByLicenceNumber
    {
        public static void DisplayDetailsByLicenceNumberUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine(@"You choose to display the vehicle details.

Write the license number of the vehicle you would like us to show
");
            string licenseNumber = Console.ReadLine();
            try
            {
                StringBuilder vehicleData = i_Garage.DisplayDetailsByLicenceNumber(licenseNumber);
                Console.WriteLine(vehicleData);
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
