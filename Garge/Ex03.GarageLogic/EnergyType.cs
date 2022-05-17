using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public  abstract class EnergyType
    {
        private float m_CurrentAmountOfEnergy;
        private float m_MaxAmountOfEnergy;
        private eEnergyTypes m_EnergyType;
    }
    public enum eEnergyTypes
    {
        Gas,
        Electric
    }
}
