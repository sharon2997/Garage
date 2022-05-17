using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColors m_Color;
        private eDoorsNumber m_DoorsNumber;

        public enum eColors
        {
            Red, 
            Silver,
            White,
            Black
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

            set
            {
                this.m_DoorsNumber = value;
            }
        }


    }
}
