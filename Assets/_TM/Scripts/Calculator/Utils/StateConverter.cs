namespace mine.calculator.util
{
    public static class StateConverter
    {
        public static bool[] Convert(this int value, int size)
        {
            var result = new bool[size];
            for (var i = 0; i < size; i++)
            {
                result[i] = (value & (1 << i)) != 0;
            }

            return result;
        }

        public static int Convert(params bool[] values)
        {
            var result = 0;
            for (var i = 0; i < values.Length; i++)
            {
                result |= values[i] ? 1 << i : 0;
            }

            return result;
        }
    }
}