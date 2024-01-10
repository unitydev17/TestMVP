using mine.calculator;
using mine.calculator.model;
using mine.calculator.presenter;
using mine.calculator.view;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<CalculatorView>().As<IView>();
        builder.Register<CalculatorModel>(Lifetime.Scoped);
        builder.Register<CalculatorPresenter>(Lifetime.Scoped).AsImplementedInterfaces();
    }
}