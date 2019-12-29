using System;

namespace CounoGame.Shared.Mvvm.Commands
{
    public abstract class DelegateCommandBase<T> : CommandBase<T>
    {
        #region Felder (privat)

        protected Action<T> ExecuteMethod { get; set; }

        #endregion

        #region Konstruktoren

        protected DelegateCommandBase(Action<T> executeMethod)
            : this(executeMethod, null, null)
        {
        }

        protected DelegateCommandBase(Action<T> executeMethod, bool useCommandManager)
            : this(executeMethod, null, useCommandManager)
        {
        }

        protected DelegateCommandBase(Action<T> executeMethod, Func<T, bool> canExecuteMethod, bool? useCommandManager = null)
            : base(useCommandManager)
        {
            this.Init(executeMethod, canExecuteMethod);
        }

        #endregion

        #region Methoden (privat)

        void Init(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if (executeMethod == null && canExecuteMethod == null)
                throw new ArgumentNullException("executeMethod");
            this.ExecuteMethod = executeMethod;
            this.CanExecuteMethod = canExecuteMethod;
        }

        #endregion
    }
}