using System;
using CounoGame.Shared.Extensions;

namespace CounoGame.Shared.Mvvm.Commands
{
    public abstract class CommandBase<T> : CommandBase, ICommand<T>, IDelegateCommand
    {
        #region - Felder privat -

        protected Func<T, bool> CanExecuteMethod { get; set; }

        #endregion

        #region - Konstruktoren -

        protected CommandBase(bool? useCommandManager = null) : base(useCommandManager)
        {
            this.CanExecuteMethod = null;
        }

        #endregion

        #region - Methoden oeffentlich -

        public override void Execute(object parameter)
        {
            this.Execute(GetGenericParameter(parameter));
        }

        #endregion

        #region - Methoden privat -

        static T GetGenericParameter(object parameter, bool suppressCastException = false)
        {
            parameter = TypeCastExtension.TryCast(parameter, typeof(T));
            if (parameter == null || parameter is T)
            {
                return (T) parameter;
            }

            if (suppressCastException)
            {
                return default(T);
            }

            throw new InvalidCastException(string.Format(
                "CommandParameter: Unable to cast object of type '{0}' to type '{1}'", parameter.GetType().FullName,
                typeof(T).FullName));
        }

        #endregion

        #region ICommand<T> Members

        public virtual bool CanExecute(T parameter)
        {
            if (this.CanExecuteMethod == null)
            {
                return true;
            }

            return this.CanExecuteMethod(parameter);
        }

        public abstract void Execute(T parameter);

        bool System.Windows.Input.ICommand.CanExecute(object parameter)
        {
            return this.CanExecute(GetGenericParameter(parameter, true));
        }

        void System.Windows.Input.ICommand.Execute(object parameter)
        {
            this.Execute(GetGenericParameter(parameter));
        }

        #endregion
    }
}
