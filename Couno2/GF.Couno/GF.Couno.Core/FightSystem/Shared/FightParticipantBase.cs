using GF.Couno.Core.EffectSystem;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.FightSystem.Shared
{
    public abstract class FightParticipantBase : IFightParticipant
    {
        protected FightParticipantBase() : this(new ParticipantCards())
        {
            
        }
        
        protected FightParticipantBase(ParticipantCards participantCards) : this(participantCards, new PowerResources())
        {
        }

        protected FightParticipantBase(ParticipantCards participantCards, PowerResources powerResources) : this(
            participantCards, powerResources, new LastingEffects())
        {
        }

        protected FightParticipantBase(ParticipantCards participantCards, PowerResources powerResources,
            LastingEffects effects)
        {
            this.ParticipantCards = participantCards;
            this.PowerResources = powerResources;
            this.Effects = effects;
        }

        public ParticipantCards ParticipantCards { get; }

        #region IFightParticipant Members

        public PowerResources PowerResources { get; }
        public LastingEffects Effects { get; }

        #endregion
    }
}