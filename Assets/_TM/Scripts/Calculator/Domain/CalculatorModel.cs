using JetBrains.Annotations;
using mine.calculator.utils;

namespace mine.calculator.domain
{
    [UsedImplicitly]
    public class CalculatorModel
    {
        public decimal value1;
        public decimal value2;

        private bool _minusPushed;
        private bool _plusPushed;
        private bool _multiplyPushed;
        private bool _dividePushed;

        public IResult CountResult()
        {
            if (_plusPushed) return new CalculationResult(value1 + value2);
            if (_minusPushed) return new CalculationResult(value1 - value2);
            if (_multiplyPushed) return new CalculationResult(value1 * value2);

            if (_dividePushed)
            {
                if (value2 == 0) return new ErrorResult(Constants.DivisionByZeroNotSupported);

                return new CalculationResult(value1 / value2);
            }

            return new EmptyResult();
        }

        public void SaveButtonsState(int state)
        {
            var values = state.Convert(4);
            _plusPushed = values[0];
            _minusPushed = values[1];
            _multiplyPushed = values[2];
            _dividePushed = values[3];
        }
    }
}