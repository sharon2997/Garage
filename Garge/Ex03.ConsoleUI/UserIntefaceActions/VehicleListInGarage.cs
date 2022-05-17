using Ex03.GarageLogic.Garage;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class VehicleListInGarage
    {
        private const int k_MinStatusOption = 1;
        private static readonly int sr_MaxStatusOption = Enum.GetNames(typeof(GarageClient.eVehicleStatus)).Length;

        public static void VehicleListInGarageUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            Console.WriteLine($@"
You choose to display list of license numbers that current exist in the garage.

What license numbers would you like us to list?
================================================

1. all license numbers of vehilce that in --IN REPAIR--

2. all license numbers of vehilce that in --FIXED--

3. all license numbers of vehilce that in --PAIDUP--

4. all license numbers

Enter the number of your choice
For example: 2");
            int optionInt = 0;
            ValidInputUI.ValidInput(k_MinStatusOption, sr_MaxStatusOption + 1, out optionInt);
            List<String> LicensesToDisplay = new List<string>();
            Console.Clear();
            switch (optionInt)
            {
                case 1:  
                    LicensesToDisplay = i_Garage.VehicleLicenseNumberInGarage(GarageClient.eVehicleStatus.InRepair);
                    break;
                case 2:
                    LicensesToDisplay = i_Garage.VehicleLicenseNumberInGarage(GarageClient.eVehicleStatus.Fixed);
                    break;
                case 3:
                    LicensesToDisplay = i_Garage.VehicleLicenseNumberInGarage(GarageClient.eVehicleStatus.PaidUp);
                    break;
                case 4:
                    LicensesToDisplay = i_Garage.VehicleLicenseNumberInGarage();
                    break;
            }

            string title = (optionInt == 4) ? @"License Numbers List: 
========================":
           $@"License Numbers List {(GarageClient.eVehicleStatus)optionInt}:
==============================";
            Console.WriteLine(title);
            foreach(string licenseNumber in LicensesToDisplay)
            {
                Console.WriteLine(licenseNumber + "\n");
            }

            Console.WriteLine("Press Enter to continue..");
            Console.ReadLine();
        }
    }
}
