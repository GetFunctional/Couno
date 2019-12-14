using System.Windows.Input;

namespace Couno.Shared.Mvvm
{
    public interface IDelegateCommand : ICommand
    {
        #region Methoden (oeffentlich)

        void RaiseCanExecuteChanged();

        #endregion
    }
}