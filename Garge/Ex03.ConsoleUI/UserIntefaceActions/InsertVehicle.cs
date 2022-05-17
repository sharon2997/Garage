using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Garage;
using GarageLogic;
using Ex03.GarageLogic.Validation;

namespace Ex03.ConsoleUI.UserIntefaceActions
{
    public class InsertVehicle
    {
        private const int k_MinOption = 1;
        private static readonly int sr_MaxOption =  Enum.GetNames(typeof(CreateVehicle.eVehicleTypes)).Length;
        private const int k_MinLicenseType = 1;
        private static readonly int sr_MaxLicenseType = Enum.GetNames(typeof(Motorcycle.eLicenseType)).Length;

        public static void InsertVehicleUI(GarageManagerSystem i_Garage)
        {
            Console.Clear();
            bool isAlreadyExist = false;
            Console.WriteLine("You choose to add a new Vehicle to the garage");
            Console.WriteLine(@"
Enter your Name:
=====================");
            string ownerName = "";
            bool isName = false;
            while (!isName)
            {
                ownerName = Console.ReadLine();
                if (ownerName.Length > 0)
                {
                    isName = true;
                }
                else
                {
                    Console.WriteLine(@"
Please type your name");
                }
            }

            Console.WriteLine(@"
Enter your Phone Number:
=====================");
            bool isPhoneNumber = false;
            string phoneNumberStr = "";
            while (!isPhoneNumber)
            {
                try
                {
                    int phoneNumberInt = 0;
                    phoneNumberStr = Console.ReadLine();
                    NumbersValidation.IsInt(phoneNumberStr, out phoneNumberInt);
                    isPhoneNumber = true;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            printVehicleTypes();
            int vehicleTypeInt = 0;
            ValidInputUI.ValidInput(k_MinOption, sr_MaxOption, out vehicleTypeInt);
            CreateVehicle.eVehicleTypes vehicleType = (CreateVehicle.eVehicleTypes)vehicleTypeInt;
            Console.Clear();
            Console.WriteLine($"You choose --- {vehicleType.ToString()} ---");
            Vehicle vehicleToInsert = CreateVehicle.CreateNewVehicle(vehicleType);
            Console.WriteLine(@"
Enter your license number:
=====================");
            string licenseNumberStr = "";
            bool isLicenseNumber = false;
            while (!isLicenseNumber)
            {
                licenseNumberStr = Console.ReadLine();
                if (licenseNumberStr.Length > 0)
                {
                    isLicenseNumber = true;
                }
                else
                {
                    Console.WriteLine("Please type your License Number");
                }
            }

            vehicleToInsert.LicenseNumber = licenseNumberStr;
            try
            {
                i_Garage.InsertVehicle(ownerName, phoneNumberStr, vehicleToInsert);
            }

            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                isAlreadyExist = true;
            }

            if (!isAlreadyExist)
            {
                Console.WriteLine(@"
Enter your Vehicle Model name:
=====================
");
                vehicleToInsert.ModelName = Console.ReadLine();
                Console.WriteLine(@"
Enter your Vehicle Producer Name for the wheels:
=====================");
                vehicleToInsert.Wheels[0].ProducerName = Console.ReadLine();
            }

            if (vehicleToInsert is Car && !isAlreadyExist)
            {
                Console.WriteLine(@"Choose color for the car:
=====================
1. Red

2. Silver

3. White

4. Black

type the color name
for example type: Black
(pay attention to Capital letters)");
                bool isColor = false;
                while (!isColor)
                {
                    try
                    {
                        string colorChosen = Console.ReadLine();
                        (vehicleToInsert as Car).SetColor(colorChosen);
                        isColor = true;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine(@"How many door would you like for the car:
=====================
----[2]----[3]----[4]----[5]----

type the number 
for example type: 3");
                bool isDoorsNumber = false;
                while (!isDoorsNumber)
                {
                    try
                    {
                        string numberChosen = Console.ReadLine();
                        (vehicleToInsert as Car).SetDoorsNumber(numberChosen);
                        isDoorsNumber = true;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            if (vehicleToInsert is Motorcycle  && !isAlreadyExist)
            {
                Console.WriteLine(@"Write Engine Capacity for the morocycle (in cc):
====================================
");
                bool isEngineCapacity = false;
                while (!isEngineCapacity)
                {
                    try
                    {
                        string engineCapacity = Console.ReadLine();
                        int engineCapacityInt;
                        NumbersValidation.IsInt(engineCapacity, out engineCapacityInt);
                        (vehicleToInsert as Motorcycle).EngineCapacity = engineCapacityInt;
                        isEngineCapacity = true;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.WriteLine(@"Choose License Type for the Motorcycle:
=====================
1. A

2. B1

3. AA

4. BB

type the number
for example if you want AA please type: 3");
                bool isLicenseType = false;
                while (!isLicenseType)
                {
                    try
                    {
                        string licenseTypeStr = Console.ReadLine();
                        int licenseTypeInt = 0;
                        NumbersValidation.IntValid(licenseTypeStr, k_MinLicenseType, sr_MaxLicenseType, out licenseTypeInt);
                        (vehicleToInsert as Motorcycle).LicenseType = (Motorcycle.eLicenseType)licenseTypeInt;
                        isLicenseType = true;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            if (vehicleToInsert is Truck && !isAlreadyExist)
            {
                Console.WriteLine(@"
Does the truck carry poisonous materials?
===============
Write [True]   or  [False]
For example: True
");
                bool valid = false;
                string input = "";
                while (!valid)
                {
                    input = Console.ReadLine();
                    if (input.Equals("True") || input.Equals("False"))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                (vehicleToInsert as Truck).PoisonousMetirials = bool.Parse(input);
                Console.WriteLine(@"Write maximum carring weight for the truck (in kg):
====================================
");
                bool isFloat = false;
                while (!isFloat)
                {
                    try
                    {
                        string carringWeightStr = Console.ReadLine();
                        float carringWeightFloat;
                        NumbersValidation.IsFloat(carringWeightStr, out carringWeightFloat);
                        (vehicleToInsert as Truck).MaximumCarringWeight = carringWeightFloat;
                        isFloat = true;
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            
            Messages.successfullyInsertedMessage();
            Console.ReadLine();
        }

        public static void printVehicleTypes()
        {
            Console.WriteLine(@"
Choose your vehicle type:
====================
1. Gas Motorcycle

2. Electric Motorcycle

3. Gas Car

4.  Electric Car

5.  Gas Truck

 ");
        }
    }
}
