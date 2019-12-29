using System;

namespace CounoGame.Shared.Mvvm.Commands
{
    public class DelegateCommand<T> : DelegateCommandBase<T>
    {
        #region Konstruktoren

        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null, null)
        {
        }

        public DelegateCommand(Action<T> executeMethod, bool useCommandManager)
            : this(executeMethod, null, useCommandManager)
        {
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod, bool? useCommandManager = null)
            : base(executeMethod, canExecuteMethod, useCommandManager)
        {
        }

        #endregion

        #region Methoden (oeffentlich)

        public override void Execute(T parentKategorieKey)
        {
            if (!((CommandBase) this).CanExecute(parentKategorieKey))
                return;
            if (this.ExecuteMethod == null) return;
            this.ExecuteMethod(parentKategorieKey);
        }

        #endregion
        
    }
}