using GF.Couno.Core.EffectSystem;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.FightSystem.Player
{
    public abstract class FightParticipantBase : IFightParticipant
    {
        protected FightParticipantBase() : this(new PowerResources() )
        {
            
        }

        protected FightParticipantBase(PowerResources powerResources) : this(powerResources, new LastingEffects())
        {

        }

        protected FightParticipantBase(PowerResources powerResources, LastingEffects effects)
        {
            this.PowerResources = powerResources;
            this.Effects = effects;
        }

        public PowerResources PowerResources { get; }
        public LastingEffects Effects { get; }
    }
}