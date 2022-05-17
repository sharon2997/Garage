using System;
using static Ex03.GarageLogic.EnergyType;
using static Ex03.GarageLogic.Gas;
namespace Ex03.GarageLogic
{
    class GasTruck : Truck
    {
        public GasTruck()
        {
            VehicleEnergyType = new Gas(eGasType.Soler, 120f);
        }

        public override string ToString()
        {
            return String.Format(@"Truck type: Gas Truck
{0}", base.ToString());
        }
    }
}
