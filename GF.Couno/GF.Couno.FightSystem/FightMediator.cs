using System;
using System.Threading.Tasks;
using GF.Couno.FightSystem.Entities;
using MediatR;

namespace GF.Couno.FightSystem
{
    public sealed class FightMediator
    {
        private readonly IMediator _mediator;

        internal FightMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<FightInfoResult> StartFightAsync(FighterId player)
        {
            return _mediator.Send(new StartFightRequest(player));
        }

        public Task<FightInfoResult> UseItemAsync(FightId fightId, FighterId player, ItemId item)
        {
            throw new NotImplementedException();
        }
    }
}