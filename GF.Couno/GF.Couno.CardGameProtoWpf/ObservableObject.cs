using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GF.Couno.CardGameProtoWpf
{
    public class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region - Methoden privat -

        /// <summary>
        ///     Setzt den Wert einer Eigenschaft. Prüft, ob sich der Wert geändert hat und ruft in diesem Fall die
        ///     Notification-Events auf.
        /// </summary>
        /// <typeparam name="T">Eigenschaften-Typ</typeparam>
        /// <param name="field">Feld der Eigenschaft</param>
        /// <param name="value">Neuer Wert der Eigenschaft</param>
        /// <param name="propertyName">Name der Eigenschaft (wird ab C# 5 vom Compiler gesetzt)</param>
        /// <param name="changedCallback">
        ///     Callback der nach dem Setzen der Eigenschaften aber noch vor dem return der Methode
        ///     ausgeführt wird.
        /// </param>
        /// <returns></returns>
        protected bool SetField<T>(ref T field, T value, string propertyName, Action changedCallback)
        {
            if (this.AreEqual(ref field, value))
            {
                return false;
            }

            this.RaisePropertyChanging(propertyName);
            field = value;
            this.RaisePropertyChanged(propertyName);

            changedCallback?.Invoke();
            return true;
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null) => this.SetField(ref field, value, propertyName, null);

        protected bool AreEqual<T>(ref T field, T value) => EqualityComparer<T>.Default.Equals(field, value);

        protected void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void RaisePropertiesChanging(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                this.RaisePropertyChanging(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanging(propertyName);
            }
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                this.RaisePropertyChanged(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames)
            {
                this.RaisePropertyChanged(propertyName);
            }
        }

        protected bool Set<T>(Action<T> setter, T oldvalue, T newvalue,
            [CallerMemberName] string propertyName = null)
        {
            if (!this.Compare(oldvalue, newvalue))
            {
                return false;
            }

            setter(newvalue);
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        protected bool Compare<T>(T value, T newvalue)
        {
            if (ReferenceEquals(value, newvalue))
            {
                return false;
            }

            if (Equals(value, newvalue))
            {
                return false;
            }

            return true;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        #endregion
    }
}