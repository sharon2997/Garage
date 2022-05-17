using System;
using Ex03.GarageLogic;

namespace GarageLogic
{
    public class CreateVehicle
    {
        public static Vehicle CreateNewVehicle(eVehicleTypes i_VehicleTypeAsInt)
        {
            eVehicleTypes vehicleType = (eVehicleTypes)i_VehicleTypeAsInt;
            Vehicle createdVehicle;

            switch (vehicleType)
            {
                case eVehicleTypes.GasMotor:
                    createdVehicle = new GasMotor();
                    break;
                case eVehicleTypes.ElectricMotor:
                    createdVehicle = new ElectricMotor();
                    break;
                case eVehicleTypes.GasCar:
                    createdVehicle = new GasCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    createdVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.GasTruck:
                    createdVehicle = new GasTruck();
                    break;
                default:
                    throw new ArgumentException("Invalid Vehicle Type");
            }

            return createdVehicle;
        }

        public enum eVehicleTypes
        {
            GasMotor = 1,
            ElectricMotor = 2,
            GasCar = 3,
            ElectricCar = 4,
            GasTruck = 5
        }
    }
}

