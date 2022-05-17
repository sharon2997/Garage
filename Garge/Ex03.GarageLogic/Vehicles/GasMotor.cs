using System;
using static Ex03.GarageLogic.Gas;

namespace Ex03.GarageLogic
{
    class GasMotor : Motorcycle
    {
        public GasMotor()
        {
            VehicleEnergyType = new Gas(eGasType.Octan98, 6f);
        }

        public override string ToString()
        {
            return String.Format(@"Motorcycle type: Gas Motorcycle
{0}", base.ToString());
        }
    }
}
