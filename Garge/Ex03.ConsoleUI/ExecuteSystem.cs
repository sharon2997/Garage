using System;
using Ex03.GarageLogic.Garage;
using Ex03.ConsoleUI.UserIntefaceActions;

namespace Ex03.ConsoleUI
{
    public class ExecuteSystem
    {
        private const int k_MinOptionToChoose = 1;
        private static readonly int sr_MaxOptionToChoose = Enum.GetNames(typeof(eActions)).Length;
        private static GarageManagerSystem s_Garage;

        public static void Run()
        {
            s_Garage = new GarageManagerSystem();
            Messages.WelcomeMessage();
            Console.ReadLine();
            while (SystemProcess()) ;
            Messages.ExitMessage();
        }

        public static bool SystemProcess()
        {
            bool inProcess = true;

            Console.Clear();
            Messages.MainMenuMessage();
            int choosenMenuOptionInt = 0;
            ValidInputUI.ValidInput(k_MinOptionToChoose, sr_MaxOptionToChoose, out choosenMenuOptionInt);
            bool isEmpty = s_Garage.IsEmpty();
            if (isEmpty && (eActions)choosenMenuOptionInt != eActions.InsertVehicle && (eActions)choosenMenuOptionInt != eActions.Exit)
            {
                Console.WriteLine(@"garage is empty, in order to execute this action you first should insert a vehicle to garage 
please press any key to continue");
                Console.ReadLine();
                Console.Clear();
            }

            switch ((eActions)choosenMenuOptionInt)
            {
                case eActions.InsertVehicle:
                    InsertVehicle.InsertVehicleUI(s_Garage);
                    break;
                case eActions.VehicleLicenseNumberInGarage:
                    if (!isEmpty)
                    {
                        VehicleListInGarage.VehicleListInGarageUI(s_Garage);
                    }

                    break;
                case eActions.ChangeVehicleStatus:
                    if (!isEmpty)
                    {
                        ChangeVehicleStatus.ChangeVehicleStatusUI(s_Garage);
                    }

                    break;
                case eActions.PumpingToMaxByLicenseNumber:
                    if (!isEmpty)
                    {
                        PumpingToMaxByLicenseNumber.PumpingToMaxByLicenseNumberUI(s_Garage);
                    }

                    break;
                case eActions.FillGasByLicenseNumber:
                    if (!isEmpty)
                    {
                        FillGasByLicenseNumber.FillGasByLicenseNumberUI(s_Garage);
                    }

                    break;
                case eActions.ChargeByLicenseNumber:
                    if (!isEmpty)
                    {
                        ChargeByLicenseNumber.ChargeByLicenseNumberUI(s_Garage);
                    }

                    break;
                case eActions.DisplayDetailsByLicenceNumber:
                    if (!isEmpty)
                    {
                        DisplayDetailsByLicenceNumber.DisplayDetailsByLicenceNumberUI(s_Garage);
                    }

                    break;
                case eActions.Exit:
                    inProcess = false;
                    break;
            }
           
            return inProcess;
        }

        public enum eActions
        {
            InsertVehicle = 1,
            VehicleLicenseNumberInGarage = 2,
            ChangeVehicleStatus = 3,
            PumpingToMaxByLicenseNumber = 4,
            FillGasByLicenseNumber = 5,
            ChargeByLicenseNumber = 6,
            DisplayDetailsByLicenceNumber = 7,
            Exit = 8
        }
    }    
}
