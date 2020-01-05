using GF.Couno.Core.EffectSystem;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.FightSystem
{
    public interface IFightParticipant
    {
        PowerResources PowerResources { get; }

        LastingEffects Effects { get; }
    }
}