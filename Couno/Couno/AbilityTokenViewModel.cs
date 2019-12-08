using System.ComponentModel;
using System.Runtime.CompilerServices;
using Couno.Engine;

namespace Couno
{
    public class AbilityTokenViewModel : INotifyPropertyChanged
    {
        public AbilityTokenViewModel(IAbilityToken abilityToken)
        {
            this.AbilityToken = abilityToken;
        }

        public string Name
        {
            get { return this.AbilityToken.Ability.Name; }
        }

        public IAbilityToken AbilityToken { get; }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{this.AbilityToken}";
        }
    }
}