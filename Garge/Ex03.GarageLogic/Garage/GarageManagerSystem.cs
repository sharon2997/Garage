using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Garage.GarageClient;
using Ex03.GarageLogic.Validation;

namespace Ex03.GarageLogic.Garage
{
    public class GarageManagerSystem
    {
        private Dictionary<String, GarageClient> m_GarageClientCollection;

        public GarageManagerSystem()
        {
            this.m_GarageClientCollection = new Dictionary<string, GarageClient>();
        }

        public Dictionary<String, GarageClient> GarageClientCollection
        {
            get
            {
                return m_GarageClientCollection;
            }

            set
            {
                m_GarageClientCollection = value;
            }
        }

        public void DisplayDetailsByLicenceNumber()
        {
            throw new NotImplementedException();
        }

        public void InsertVehicle(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            if (IsInGarage(i_Vehicle.LicenseNumber))
            {
                GarageClient existClient = m_GarageClientCollection[i_Vehicle.LicenseNumber];
                existClient.VehicleStatus = eVehicleStatus.InRepair;
                throw new ArgumentException("The Vehicle is already in the garage, moved to InRepair status");
            }

            GarageClient newClient = new GarageClient(i_OwnerName, i_OwnerPhone, i_Vehicle);
            m_GarageClientCollection.Add(i_Vehicle.LicenseNumber, newClient);
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            return m_GarageClientCollection.ContainsKey(i_LicenseNumber);
        }

        public List<string> VehicleLicenseNumberInGarage()
        {
            List<string> LicenseNumbersList = new List<string>(m_GarageClientCollection.Keys);

            return LicenseNumbersList;
        }

        //with filter:
        public List<string> VehicleLicenseNumberInGarage(eVehicleStatus i_Status)
        {
            List<string> LicenseNumbersList = new List<string>();

            foreach (GarageClient client in m_GarageClientCollection.Values)
            {
                if(i_Status.Equals(client.VehicleStatus))
                {
                    LicenseNumbersList.Add(client.Vehicle.LicenseNumber);
                }               
            }

            return LicenseNumbersList;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"This License Number: {i_LicenseNumber} does not belong to any vehicle in the garage"); 
            }

            GarageClient existClient = m_GarageClientCollection[i_LicenseNumber];
            existClient.VehicleStatus = i_Status;
        }

        public void PumpingToMaxByLicenseNumber(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"This License Number: {i_LicenseNumber} does not belong to any vehicle in the garage");
            }

            GarageClient existClient = m_GarageClientCollection[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            foreach(Wheel wheel in clientVehicle.Wheels)
            {
                wheel.PumpingAirToMax();
            }
        }

        public void FillGasByLicenseNumber(string i_LicenseNumber, Gas.eGasType i_GasType, string i_QuantityGas)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"This License Number: {i_LicenseNumber} does not belong to any vehicle in the garage");
            }

            if (!isGasVehicle(i_LicenseNumber))
            {
                throw new ArgumentException($"Pay attention this is an electric car, impossible to refuel with gas");
            }

            if(isCorrcetGasType(i_LicenseNumber, i_GasType))
            {
                GarageClient client = m_GarageClientCollection[i_LicenseNumber];
                Vehicle vehicle = client.Vehicle;
                Gas.eGasType currentGasType = (vehicle.VehicleEnergyType as Gas).GasType;
                throw new ArgumentException($@"Pay attention this is not the correct gas ytpe for your vehicle.
Notice your gas type is: -- {currentGasType} --");
            }

            int quantityInt = 0;
            NumbersValidation.IsInt(i_QuantityGas, out quantityInt);
            GarageClient existClient = m_GarageClientCollection[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            EnergyType fuelTank = clientVehicle.VehicleEnergyType;
            (fuelTank as Gas).FillGas(i_QuantityGas);
        }

        private bool isCorrcetGasType(string i_LicenseNumber, Gas.eGasType i_GasType)
        {
            bool isCorrect = true;
            GarageClient client = m_GarageClientCollection[i_LicenseNumber];
            Vehicle clientVehicle = client.Vehicle;
            Gas.eGasType currentGasType = (clientVehicle.VehicleEnergyType as Gas).GasType;

            if (currentGasType != i_GasType)
            {
                isCorrect = false;
            }

            return isCorrect;
        }

        private bool isGasVehicle(string i_LicenseNumber)
        {
            bool isGas = false;
            GarageClient client = m_GarageClientCollection[i_LicenseNumber];
            Vehicle clientVehicle = client.Vehicle;
            EnergyType energy = clientVehicle.VehicleEnergyType;

            if(energy.EnergyTypeOfVehicle == EnergyType.eEnergyTypes.Gas)
            {
                isGas = true;
            }

            return isGas;
        }

        public void ChargeByLicenseNumber(string i_LicenseNumber, string i_TimeQuantity)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"This License Number: {i_LicenseNumber} does not belong to any vehicle in the garage");
            }

            if (isGasVehicle(i_LicenseNumber))
            {
                throw new ArgumentException($"pay attention this is an gas car, impossible to charge");
            }

            GarageClient existClient = m_GarageClientCollection[i_LicenseNumber];
            Vehicle clientVehicle = existClient.Vehicle;
            EnergyType battery = clientVehicle.VehicleEnergyType;
            battery.FillEnergy(i_TimeQuantity);
        }

        public StringBuilder DisplayDetailsByLicenceNumber(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new ArgumentException($"This License Number: {i_LicenseNumber} does not belong to any vehicle in the garage");
            }

            GarageClient client = m_GarageClientCollection[i_LicenseNumber];
            StringBuilder details = new StringBuilder("");
            string newLine = Environment.NewLine;
            details.Append($"VEHICLE DETAILS:{newLine}");
            details.Append($"====================={newLine}");
            details.Append(client.Vehicle.ToString());

            return details;
        }

        public bool IsEmpty()
        {
            bool isEmpty = true;

            if(m_GarageClientCollection.Count != 0)
            {
                isEmpty = false;
            }

            return isEmpty;
        }
    }
}
