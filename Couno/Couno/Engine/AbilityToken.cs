namespace Couno.Engine
{
    public sealed class AbilityToken : IAbilityToken
    {
        public AbilityToken(Ability ability)
        {
            this.Ability = ability;
        }

        #region IAbilityToken Members

        public Ability Ability { get; }

        #endregion

        public override string ToString()
        {
            return this.Ability.ToString();
        }
    }
}