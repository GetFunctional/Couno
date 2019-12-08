namespace Couno.Engine
{
    public interface IAbilityToken
    {
        IAbilityToken Ancestor { get; }

        IAbilityToken Descendant { get; }

        void IntroduceDescendant(IAbilityToken descendant);

        Ability Ability { get; }
    }
}