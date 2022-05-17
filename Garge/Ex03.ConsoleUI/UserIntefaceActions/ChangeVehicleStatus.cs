using System;
using Ex03.GarageLogic.Garage;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class ChangeVehicleStatus
    {
        private const int k_MinStatusOption = 1;
        private static readonly int sr_MaxStatusOption = Enum.GetNames(typeof(GarageClient.eVehicleStatus)).Length;

        public static void ChangeVehicleStatusUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine(@"You choose to change status of existing Vehicle in the garage.

Write the license number of the vehicle you would like to update");
            string licenseNumber = Console.ReadLine();
            try
            {
                GarageClient currentClient = i_Garage.GarageClientCollection[licenseNumber];
                GarageClient.eVehicleStatus oldStatus = currentClient.VehicleStatus;
                Console.WriteLine($@"

What is the desired status of the vehicle?
================================================

1. --IN REPAIR--

2. --FIXED--

3. --PAIDUP--


Enter the number of your choice
For example: 3");
                int userChoiceInt = 0;
                ValidInputUI.ValidInput(k_MinStatusOption, sr_MaxStatusOption, out userChoiceInt);
                GarageClient.eVehicleStatus status = (GarageClient.eVehicleStatus)userChoiceInt;
                i_Garage.ChangeVehicleStatus(licenseNumber, status);
                Console.WriteLine($"The vehicle moved from status {oldStatus} to {status}");
            }

            catch
            {
                Console.WriteLine($"This License Number: {licenseNumber} does not belong to any vehicle in the garage");
            }
            
            finally
            {
                Console.WriteLine("Press Enter to continue..");
                Console.ReadLine();
            } 
        }
    }
}
