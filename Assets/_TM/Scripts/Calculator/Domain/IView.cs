using System;
using UniRx;

namespace mine.calculator
{
    public interface IView
    {
        public void UpdateResult(IResult result);
        public void UpdateButtons(int state);

        IObservable<string> onValue1Changed { get; }
        IObservable<string> onValue2Changed { get; }

        IObservable<Unit> onPlusBtnChanged { get; }
        IObservable<Unit> onMinusBtnChanged { get; }
        IObservable<Unit> onMultiplyBtnChanged { get; }
        IObservable<Unit> onDivideBtnChanged { get; }
    }
}