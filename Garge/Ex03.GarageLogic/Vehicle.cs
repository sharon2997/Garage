using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenseNumber;
        float m_EnergyPercentageBalance;
        private List<Wheel> m_Wheels;
        private EnergyType m_VehicleEnergyType;
        //private float m_MaximumTirePresure;

        public Vehicle() 
        {
            this.m_ModelName = string.Empty;
            this.m_LicenseNumber = string.Empty;
            this.m_EnergyPercentageBalance = 0f;
            this.m_Wheels = new List<Wheel>();
            this.m_VehicleEnergyType = null;
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        public float EnergyPercentageBalance
        {
            get
            {
                return m_EnergyPercentageBalance;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        public EnergyType VehicleEnergyType
        {
            get
            {
                return m_EnergyType;
            }

            set
            {
                m_EnergyType = value;
            }
        }
    }
}
