using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GF.Couno.CardGameProtoWpf
{
    public class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

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
            if (AreEqual(ref field, value)) return false;

            RaisePropertyChanging(propertyName);
            field = value;
            RaisePropertyChanged(propertyName);

            changedCallback?.Invoke();
            return true;
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            return SetField(ref field, value, propertyName, null);
        }

        protected bool AreEqual<T>(ref T field, T value)
        {
            return EqualityComparer<T>.Default.Equals(field, value);
        }

        protected void RaisePropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void RaisePropertiesChanging(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                RaisePropertyChanging(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames) RaisePropertyChanging(propertyName);
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertiesChanged(params string[] propertyNames)
        {
            if (propertyNames == null || propertyNames.Length == 0)
            {
                RaisePropertyChanged(string.Empty);
                return;
            }

            foreach (var propertyName in propertyNames) RaisePropertyChanged(propertyName);
        }

        protected bool Set<T>(Action<T> setter, T oldvalue, T newvalue,
            [CallerMemberName] string propertyName = null)
        {
            if (!Compare(oldvalue, newvalue)) return false;

            setter(newvalue);
            RaisePropertyChanged(propertyName);
            return true;
        }

        protected bool Compare<T>(T value, T newvalue)
        {
            if (ReferenceEquals(value, newvalue)) return false;
            if (Equals(value, newvalue)) return false;

            return true;
        }
    }
}