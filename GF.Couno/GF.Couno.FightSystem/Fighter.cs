using System.Collections.Generic;
using GF.Couno.FightSystem.Components;
using GF.Couno.FightSystem.Ecs;
using GF.Couno.FightSystem.Entities;

namespace GF.Couno.FightSystem
{
    internal sealed class Fighter : IEntity
    {
        private readonly ComponentRepository _componentRepository = new ComponentRepository();
        public IExternalComponentRepository Components
        {
            get { return _componentRepository; }
        }

        public Fighter(FighterId fighterId) : this(fighterId, new List<IComponent>())
        {
        }

        public Fighter(FighterId fighterId, IList<IComponent> fighterComponents)
        {
            FighterId = fighterId;
            _componentRepository.AddComponents(fighterComponents);
        }

        public FighterId FighterId { get; }
    }
}