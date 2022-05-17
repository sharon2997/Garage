using System;

namespace Ex03.GarageLogic
{
    public class Gas : EnergyType
    {
        private readonly eGasType r_GasType;

        public Gas(eGasType i_GasType, float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity, eEnergyTypes.Gas)
        {
            r_GasType = i_GasType;
        }

        public eGasType GasType
        {
            get
            {
                return r_GasType;
            }
        }

        public void FillGas(String i_GasQuantity)
        {
            FillEnergy(i_GasQuantity);
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(
               "{0}GasType: {1}",
               Environment.NewLine, r_GasType);
        }

        public enum eGasType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}
