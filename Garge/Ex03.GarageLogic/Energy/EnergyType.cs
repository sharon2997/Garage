using Ex03.GarageLogic.Validation;
using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        private float m_CurrentAmountOfEnergy;
        private readonly float r_MaxEnergyCapacity;
        private readonly eEnergyTypes r_EnergyTypeOfVehicle;
        private float m_EnergyPercentageBalance;

        public EnergyType(float i_MaxEnergyCapacity, eEnergyTypes i_EnergyTypeOfVehicle)
        {
            this.r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            this.r_EnergyTypeOfVehicle = i_EnergyTypeOfVehicle;
        }

        public float CurrentAmountOfEnergy
        {
            get
            {
                return m_CurrentAmountOfEnergy;
            }

            private set
            {
                if (value <= r_MaxEnergyCapacity)
                {
                    m_CurrentAmountOfEnergy = value;
                    SetRemainingEnergyPercentage();
                }
            }
        }

        public void SetCurrentAmountOfEnergy(string i_InputSetEnergyAmount)
        {
            float amountOfEnergy;

            if (NumbersValidation.FloatValid(i_InputSetEnergyAmount, 0, r_MaxEnergyCapacity, out amountOfEnergy))
            {
                m_CurrentAmountOfEnergy = amountOfEnergy;
                SetRemainingEnergyPercentage();
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return r_MaxEnergyCapacity;
            }
        }

        public eEnergyTypes EnergyTypeOfVehicle
        {
            get
            {
                return r_EnergyTypeOfVehicle;
            }
        }

        public float EnergyPercentageBalance
        {
            get
            {
                return m_EnergyPercentageBalance;
            }
        }

        public void SetRemainingEnergyPercentage()
        {
            m_EnergyPercentageBalance = (m_CurrentAmountOfEnergy / r_MaxEnergyCapacity) * 100;
        }

        public void FillEnergy(string i_QuantityOfEnergy)
        {
            float quantityOfEnergyNum;

            if (NumbersValidation.FloatValid(i_QuantityOfEnergy, 0, r_MaxEnergyCapacity - m_CurrentAmountOfEnergy, out quantityOfEnergyNum))
            {
                m_CurrentAmountOfEnergy += quantityOfEnergyNum;
                SetRemainingEnergyPercentage();
            }
        }

        public override string ToString()
        {
            return String.Format(@"Type of energy: {0}
Current Amount Of Energy: {1} (which is {2}% of the maximum capacity)", 
r_EnergyTypeOfVehicle, m_CurrentAmountOfEnergy, m_EnergyPercentageBalance);
        }

        public enum eEnergyTypes
        {
            Gas,
            Electric
        }
    }
}
