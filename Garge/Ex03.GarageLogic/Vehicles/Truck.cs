using System;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_PoisonousMetirials;
        private float m_MaximumCarringWeight;
        private const int k_NumberOfWheels = 16;
        private const int k_WheelPressure = 26;
        
        public Truck()
        {
            for(int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_WheelPressure));
            }
        }

        public bool PoisonousMetirials
        {
            get
            {
                return m_PoisonousMetirials;
            }

            set
            {
                m_PoisonousMetirials = value;
            }
        }

        public float MaximumCarringWeight
        {
            get
            {
                return m_MaximumCarringWeight;
            }

            set
            {
                m_MaximumCarringWeight = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"
Poisonous Metirials on Truck ? {0}, 
Maximum Carring Weight: {1}", m_PoisonousMetirials, m_MaximumCarringWeight);
        }
    }
}
