using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CounoGame.Shared.Mvvm.Commands
{
    public abstract class CommandBase : ICommand
    {
        private readonly bool _useCommandManager;

        protected CommandBase(bool? useCommandManager = null)
        {
            this._useCommandManager = useCommandManager ?? DefaultUseCommandManager;
        }

        private static bool DefaultUseCommandManager { get; } = true;

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._useCommandManager)
                {
                    CommandManagerExtensions.Subscribe(value);
                }
                else
                {
                    canExecuteChanged += value;
                }
            }
            remove
            {
                if (this._useCommandManager)
                {
                    CommandManagerExtensions.Unsubscribe(value);
                }
                else
                {
                    canExecuteChanged -= value;
                }
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        #endregion

        public void RaiseCanExecuteChanged()
        {
            if (this._useCommandManager)
            {
                CommandManagerExtensions.InvalidateRequerySuggested();
            }
            else
            {
                if (canExecuteChanged != null)
                {
                    canExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        private event EventHandler canExecuteChanged;

        #region Nested type: CommandManagerExtensions

        private static class CommandManagerExtensions
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            internal static void Subscribe(EventHandler canExecuteChangedHandler)
            {
                CommandManager.RequerySuggested += canExecuteChangedHandler;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            internal static void Unsubscribe(EventHandler canExecuteChangedHandler)
            {
                CommandManager.RequerySuggested -= canExecuteChangedHandler;
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            internal static void InvalidateRequerySuggested()
            {
                CommandManager.InvalidateRequerySuggested();
            }
        }

        #endregion
    }
}