using System;
using mine.calculator.domain;
using UniRx;
using VContainer;
using VContainer.Unity;

namespace mine.calculator.presenter
{
    public class CalculatorPresenter : IStartable, IDisposable
    {
        private readonly CompositeDisposable _disposables = new CompositeDisposable();


        private IView _view;
        private CalculatorModel _model;

        [Inject]
        public void Construct(IView view, CalculatorModel model)
        {
            _view = view;
            _model = model;
        }

        public void Start()
        {
            _disposables.Add(_view.onValue1Changed.Subscribe(value => ChangeValue(out _model.value1, value)));
            _disposables.Add(_view.onValue2Changed.Subscribe(value => ChangeValue(out _model.value2, value)));
            _disposables.Add(_view.onPlusBtnChanged.Subscribe(value => UpdateState(1)));
            _disposables.Add(_view.onMinusBtnChanged.Subscribe(value => UpdateState(2)));
            _disposables.Add(_view.onMultiplyBtnChanged.Subscribe(value => UpdateState(4)));
            _disposables.Add(_view.onDivideBtnChanged.Subscribe(value => UpdateState(8)));
        }

        private void ChangeValue(out decimal changedValue, string value)
        {
            try
            {
                changedValue = decimal.Parse(value);
            }
            catch (Exception e)
            {
                changedValue = 0;
            }

            CountAndUpdateResult();
        }

        private void UpdateState(int state)
        {
            _model.SaveButtonsState(state);
            _view.UpdateButtons(state);
            CountAndUpdateResult();
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void CountAndUpdateResult()
        {
            var result = _model.CountResult();
            _view.UpdateResult(result);
        }
    }
}