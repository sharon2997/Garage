using System;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;
        private const int k_WheelPressure = 30;
       
        public Motorcycle()
        {
            Wheel frontWheel = new Wheel(k_WheelPressure);
            Wheel backWheel = new Wheel(k_WheelPressure);
            base.Wheels.Add(frontWheel);
            base.Wheels.Add(backWheel);
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                this.m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }

        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"Motor License Type: {0}, 
 Engine Capacity: {1}", m_LicenseType, m_EngineCapacity);
        }

        public enum eLicenseType
        {
            A,
            B1,
            AA,
            BB
        }
    }
}
