using System;

namespace Ex03.GarageLogic
{
    public class ElectricMotor : Motorcycle
    {
        public ElectricMotor()
        {
            VehicleEnergyType = new Electric(1.8f);
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: Electric Motorcycle
{0}", base.ToString());
        }
    }
}
