namespace mine.calculator.model
{
    public class CalculationResult : IResult
    {
        public string value => _value.ToString();

        private decimal? _value;

        public CalculationResult(decimal? value)
        {
            _value = value;
        }
    }
}