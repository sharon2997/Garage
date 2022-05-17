using Ex03.GarageLogic.Validation;
using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColors m_Color;
        private eDoorsNumber m_DoorsNumber;
        private const int k_NumberOfWheels = 4;
        private const int k_WheelPressure = 32;

        public Car()
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_WheelPressure));
            }
        }

        public enum eColors
        {
            Red = 1, 
            Silver = 2,
            White = 3,
            Black = 4
        }

        public enum eDoorsNumber
        {
           Two = 2,
           Three = 3,
           Four = 4,
           Five = 5
        }

        public eColors Color
        {
            get
            {
                return m_Color;
            }

            set
            {
                this.m_Color = value;
            }
        }

        public eDoorsNumber DoorsNumber
        {
            get
            {
                return m_DoorsNumber;
            }

            private set
            {
                this.m_DoorsNumber = value;
            }
        }

        public void SetDoorsNumber(string i_DoorsNumberStr)
        {
            bool flag = true;
            int DoorsNumberInt;

            if(NumbersValidation.IsInt(i_DoorsNumberStr, out DoorsNumberInt))
            {
                foreach (int i in Enum.GetValues(typeof(eDoorsNumber)))
                {
                    if (DoorsNumberInt == i)
                    {
                        DoorsNumber = (eDoorsNumber)DoorsNumberInt;
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    throw new ValueOutOfRangeException(2, 5);
                }
            }
        }

        public void SetColor(string i_ColorStr)
        {
            bool flag = true;
            int indexColor = 1;

            foreach (string color in Enum.GetNames(typeof(eColors)))
            {
                if (i_ColorStr.Equals(color))
                {
                    Color = (eColors)indexColor;
                    flag = false;
                    break;
                }

                indexColor++; 
            }

            if (flag)
            {
                throw new FormatException("Invalid input! Please change the input to valid color");
            }
        }

        public override string ToString()
        {
            return base.ToString() + String.Format(@"Car Color: {0}, 
Number of Doors: {1}", m_Color, m_DoorsNumber);
        }
    }
}
