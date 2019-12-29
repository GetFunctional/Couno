using System.Windows.Input;

namespace CounoGame.Shared.Mvvm.Commands
{
    public interface ICommand<in T> : ICommand
    {
        #region - Methoden oeffentlich -

        void Execute(T parameter);

        bool CanExecute(T parameter);

        #endregion
    }
}