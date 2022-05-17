using System;

namespace Ex03.GarageLogic
{
    class Electric : EnergyType
    {
        public Electric(float i_MaxEnergyCapacity) : base(i_MaxEnergyCapacity, eEnergyTypes.Electric)
        {
        
        }

        public void Recharge(String i_TimeQuantity)
        {
            FillEnergy(i_TimeQuantity);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
