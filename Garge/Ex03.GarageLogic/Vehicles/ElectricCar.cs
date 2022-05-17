using System;

namespace Ex03.GarageLogic
{
    class ElectricCar : Car
    {
        public ElectricCar()
        {
            VehicleEnergyType = new Electric(3.2f);
        }

        public override string ToString()
        {
            return String.Format(@"Car type: Electric Car 
{0}", base.ToString());
        }
    }
}
