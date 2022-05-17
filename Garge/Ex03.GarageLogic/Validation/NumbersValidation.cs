using System;

namespace Ex03.GarageLogic.Validation
{
    public class NumbersValidation
    {
        public static bool IsInt(string i_Input, out int io_ValidInt)
        {
            bool valid = true;

            valid = Int32.TryParse(i_Input, out io_ValidInt);
            if (!valid)
            {
                throw new FormatException("Invalid input! Please change the input to Integer");
            }

            return valid;
        }

        public static bool IsFloat(string i_Input, out float io_ValidFloat)
        {
            bool valid = true;

            valid = Single.TryParse(i_Input, out io_ValidFloat);
            if (!valid)
            {
                throw new FormatException("Invalid input! Please change the input to Float number");
            }

            return valid;
        }

        public static bool FloatValid(string i_Input, float i_LowBound, float i_HighBound, out float io_ValidFloat)
        {
            bool valid = false;

            valid = Single.TryParse(i_Input, out io_ValidFloat);
            if (valid)
            {
                if(!(io_ValidFloat >= i_LowBound && io_ValidFloat <= i_HighBound))
                {
                    valid = false;
                    throw new ValueOutOfRangeException(i_LowBound, i_HighBound);
                }
            }
            else
            {
                throw new FormatException("Invalid input! please change the input to Float");
            }

            return valid;
        }

        public static bool IntValid(string i_Input, int i_LowBound, int i_HighBound, out int io_ValidInt)
        {
            bool valid = false;

            valid = Int32.TryParse(i_Input, out io_ValidInt);
            if (valid)
            {
                if (!(io_ValidInt >= i_LowBound && io_ValidInt <= i_HighBound))
                {
                    valid = false;
                    throw new ValueOutOfRangeException(i_LowBound, i_HighBound);
                }
            }
            else
            {
                throw new FormatException("Invalid input! please change the input to Integer");
            }

            return valid;
        }
    }
}
