using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.FightSystem.Player
{
    public sealed class PlayerFightParticipant : IFightParticipant
    {
        public PlayerFightParticipant() : this(new PowerResources())
        {

        }

        public PlayerFightParticipant(PowerResources powerResources)
        {
            this.PowerResources = powerResources;
        }

        public PowerResources PowerResources { get; }
    }
}
