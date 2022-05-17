using System;
using static Ex03.GarageLogic.Gas;

namespace Ex03.GarageLogic
{
    public class GasCar : Car
    {
        public GasCar()
        {
            VehicleEnergyType = new Gas(eGasType.Octan95, 45f);
        }

        public override string ToString()
        {
            return String.Format(@"Car type: Gas Car
{0}", base.ToString());
        }
    }
}
