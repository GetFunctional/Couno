using System.Windows.Input;

namespace CounoGame.Shared.Mvvm.Commands
{
    public interface IDelegateCommand : ICommand
    {
        #region Methoden (oeffentlich)

        void RaiseCanExecuteChanged();

        #endregion
    }
}