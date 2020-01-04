using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.FightSystem.Ai
{
    public sealed class AiFightParticipant : IFightParticipant
    {
        public AiFightParticipant() : this(new PowerResources())
        {

        }

        public AiFightParticipant(PowerResources powerResources)
        {
            this.PowerResources = powerResources;
        }

        public PowerResources PowerResources { get; }
    }
}
