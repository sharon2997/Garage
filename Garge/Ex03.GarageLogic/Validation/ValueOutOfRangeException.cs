using System;

namespace Ex03.GarageLogic.Validation
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MinValue;
        private readonly float r_MaxValue;

        public float LowBound
        {
            get
            {
                return r_MinValue;
            }
        }

        public float HighBound
        {
            get
            {
                return r_MaxValue;
            }
        }

        public ValueOutOfRangeException(float i_LowBound, float i_HighBound) : base($"input is not valid, input should be beetwen {i_LowBound} to { i_HighBound}")
        {
            this.r_MinValue = i_LowBound;
            this.r_MaxValue = i_HighBound;
        }
    }
}
