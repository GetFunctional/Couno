using System.Windows.Input;

namespace Couno.Shared.Mvvm
{
    public interface ICommand<in T> : ICommand
    {
        #region - Methoden oeffentlich -

        void Execute(T parameter);

        bool CanExecute(T parameter);

        #endregion
    }
}